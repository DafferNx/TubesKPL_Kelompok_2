using System;
using System.Collections.Generic;

class Program
{
    private enum Page
    {
        RoleMenu,
        Store,
        Detail,
        Cart,
        Library,
        LibraryDetail,
        AdminMenu,
        AdminRefundList,
        AdminRefundDecision
    }

    static void Main()
    {
        DatabaseHelper.InitializeDatabase();

        GameService gameService = new GameService();
        AdminService adminService = new AdminService();

        Page currentPage = Page.RoleMenu;
        Game? selectedGame = null;
        User? currentUser = null;

        while (true)
        {
            Console.Clear();

            switch (currentPage)
            {
                case Page.RoleMenu:
                    Menu.ShowRoleMenu();
                    string username = Menu.GetTextInput("Username (0 untuk exit): ");

                    if (username == "0")
                        return;

                    string password = Menu.GetTextInput("Password: ");

                    try
                    {
                        currentUser = DatabaseHelper.Login(username, password);

                        if (currentUser.Role == UserRole.Admin)
                        {
                            currentPage = Page.AdminMenu;
                        }
                        else
                        {
                            currentPage = Page.Store;
                        }
                    }
                    catch (Exception ex)
                    {
                        Menu.ShowMessage(ex.Message);
                    }
                    break;

                case Page.Store:
                    if (currentUser == null || currentUser.Role != UserRole.User)
                    {
                        currentPage = Page.RoleMenu;
                        break;
                    }

                    currentUser = DatabaseHelper.GetUserByUsername(currentUser.Username);
                    List<Game> storeGames = gameService.getAllGames(currentUser.Id);
                    Menu.ShowStore(storeGames, currentUser);
                    int storeInput = Menu.GetInput();

                    if (storeInput == 0)
                    {
                        currentUser = null;
                        currentPage = Page.RoleMenu;
                    }
                    else if (storeInput >= 1)
                    {
                        try
                        {
                            if (storeInput == 11)
                            {
                                currentPage = Page.Library;
                            }
                            else if (storeInput == 12)
                            {
                                currentPage = Page.Cart;
                            }
                            else if (storeInput == 13)
                            {
                                string message = currentUser.Wallet.ChangeState(WalletAction.Activate);
                                DatabaseHelper.UpdateWallet(currentUser);
                                Menu.ShowMessage(message);
                            }
                            else if (storeInput == 14)
                            {
                                string amountText = Menu.GetTextInput("Jumlah top up: ");
                                if (!int.TryParse(amountText, out int amount))
                                {
                                    Menu.ShowMessage("Jumlah top up tidak valid");
                                }
                                else
                                {
                                    string message = currentUser.Wallet.TopUp(amount);
                                    DatabaseHelper.UpdateWallet(currentUser);
                                    Menu.ShowMessage(message);
                                }
                            }
                            else
                            {
                                selectedGame = gameService.getGameById(currentUser.Id, storeInput);
                                currentPage = Page.Detail;
                            }
                        }
                        catch (Exception ex)
                        {
                            Menu.ShowMessage(ex.Message);
                        }
                    }
                    else
                    {
                        Menu.ShowMessage("Input tidak valid");
                    }
                    break;

                case Page.Detail:
                    if (currentUser == null || selectedGame == null)
                    {
                        currentPage = Page.Store;
                        break;
                    }

                    selectedGame = gameService.getGameById(currentUser.Id, selectedGame.Id);
                    Menu.ShowGameDetail(selectedGame);
                    int detailInput = Menu.GetInput();

                    if (detailInput == 1)
                    {
                        string message = gameService.buyGame(currentUser, selectedGame);
                        Menu.ShowMessage(message);
                        currentPage = Page.Library;
                    }
                    else if (detailInput == 2)
                    {
                        string message = gameService.addToCart(currentUser.Id, selectedGame);
                        Menu.ShowMessage(message);
                        currentPage = Page.Cart;
                    }
                    else if (detailInput == 3)
                    {
                        currentPage = Page.Store;
                    }
                    else
                    {
                        Menu.ShowMessage("Input tidak valid");
                    }
                    break;

                case Page.Cart:
                    if (currentUser == null)
                    {
                        currentPage = Page.RoleMenu;
                        break;
                    }

                    currentUser = DatabaseHelper.GetUserByUsername(currentUser.Username);
                    var cartGames = gameService.getCartGames(currentUser.Id);
                    int totalPrice = gameService.getTotalCartPrice(currentUser.Id);

                    Menu.ShowCart(cartGames, totalPrice);
                    int cartInput = Menu.GetInput();

                    if (cartInput == 1)
                    {
                        string message = gameService.checkoutCart(currentUser);
                        Menu.ShowMessage(message);
                        currentPage = Page.Library;
                    }
                    else if (cartInput == 2)
                    {
                        string gameIdText = Menu.GetTextInput("ID game yang dihapus dari cart: ");
                        if (!int.TryParse(gameIdText, out int gameId))
                        {
                            Menu.ShowMessage("ID game tidak valid");
                        }
                        else
                        {
                            try
                            {
                                Game cartGame = gameService.getGameById(currentUser.Id, gameId);
                                string message = gameService.removeFromCart(currentUser.Id, cartGame);
                                Menu.ShowMessage(message);
                            }
                            catch (Exception ex)
                            {
                                Menu.ShowMessage(ex.Message);
                            }
                        }
                    }
                    else if (cartInput == 3)
                    {
                        currentPage = Page.Store;
                    }
                    else
                    {
                        Menu.ShowMessage("Input tidak valid");
                    }
                    break;

                case Page.Library:
                    if (currentUser == null)
                    {
                        currentPage = Page.RoleMenu;
                        break;
                    }

                    var ownedGames = gameService.getOwnedGames(currentUser.Id);
                    Menu.ShowLibrary(ownedGames);
                    int libraryInput = Menu.GetInput();

                    if (libraryInput == 0)
                    {
                        currentPage = Page.Store;
                    }
                    else
                    {
                        try
                        {
                            selectedGame = gameService.getGameById(currentUser.Id, libraryInput);

                            if (selectedGame.Status != GameStatus.Owned && selectedGame.Status != GameStatus.PendingRefund)
                            {
                                Menu.ShowMessage("Game tidak ada di library");
                            }
                            else
                            {
                                currentPage = Page.LibraryDetail;
                            }
                        }
                        catch (Exception ex)
                        {
                            Menu.ShowMessage(ex.Message);
                        }
                    }
                    break;

                case Page.LibraryDetail:
                    if (currentUser == null || selectedGame == null)
                    {
                        currentPage = Page.Library;
                        break;
                    }

                    selectedGame = gameService.getGameById(currentUser.Id, selectedGame.Id);
                    Menu.ShowLibraryDetail(selectedGame);
                    int libraryDetailInput = Menu.GetInput();

                    if (libraryDetailInput == 1)
                    {
                        currentPage = Page.Library;
                    }
                    else if (libraryDetailInput == 2)
                    {
                        string message = gameService.requestRefund(currentUser.Id, selectedGame);
                        Menu.ShowMessage(message);
                        currentPage = Page.Library;
                    }
                    else
                    {
                        Menu.ShowMessage("Input tidak valid");
                    }
                    break;

                case Page.AdminMenu:
                    if (currentUser == null || currentUser.Role != UserRole.Admin)
                    {
                        currentPage = Page.RoleMenu;
                        break;
                    }

                    Menu.ShowAdminMenu();
                    int adminInput = Menu.GetInput();

                    if (adminInput == 0)
                    {
                        currentUser = null;
                        currentPage = Page.RoleMenu;
                    }
                    else if (adminInput == 1)
                    {
                        string name = Menu.GetTextInput("Nama game: ");
                        string priceText = Menu.GetTextInput("Harga game: ");

                        if (!int.TryParse(priceText, out int price))
                        {
                            Menu.ShowMessage("Harga game tidak valid");
                        }
                        else
                        {
                            string message = adminService.AddGame(name, price);
                            Menu.ShowMessage(message);
                        }
                    }
                    else if (adminInput == 2)
                    {
                        currentPage = Page.AdminRefundList;
                    }
                    else if (adminInput == 3)
                    {
                        string usernameToBan = Menu.GetTextInput("Username user yang wallet-nya diban: ");
                        string message = adminService.BanWallet(usernameToBan);
                        Menu.ShowMessage(message);
                    }
                    else if (adminInput == 4)
                    {
                        string usernameToUnban = Menu.GetTextInput("Username user yang wallet-nya di-unban: ");
                        string message = adminService.UnbanWallet(usernameToUnban);
                        Menu.ShowMessage(message);
                    }
                    else
                    {
                        Menu.ShowMessage("Input tidak valid");
                    }
                    break;

                case Page.AdminRefundList:
                    var pendingRefundGames = adminService.GetPendingRefundGames();
                    Menu.ShowPendingRefunds(pendingRefundGames);
                    int refundListInput = Menu.GetInput();

                    if (refundListInput == 0)
                    {
                        currentPage = Page.AdminMenu;
                    }
                    else
                    {
                        try
                        {
                            selectedGame = adminService.GetPendingRefundGameById(refundListInput);
                            currentPage = Page.AdminRefundDecision;
                        }
                        catch (Exception ex)
                        {
                            Menu.ShowMessage(ex.Message);
                        }
                    }
                    break;

                case Page.AdminRefundDecision:
                    if (selectedGame == null)
                    {
                        currentPage = Page.AdminRefundList;
                        break;
                    }

                    Menu.ShowRefundDecision(selectedGame);
                    int refundDecisionInput = Menu.GetInput();

                    if (refundDecisionInput == 0)
                    {
                        currentPage = Page.AdminRefundList;
                    }
                    else if (refundDecisionInput == 1 || refundDecisionInput == 2)
                    {
                        bool approve = refundDecisionInput == 1;
                        string message = adminService.ProcessRefund(selectedGame, approve);
                        Menu.ShowMessage(message);
                        currentPage = Page.AdminRefundList;
                    }
                    else
                    {
                        Menu.ShowMessage("Input tidak valid");
                    }
                    break;
            }
        }
    }
}
