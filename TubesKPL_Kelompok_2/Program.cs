using System;
using System.Collections.Generic;

class Program
{
    private const string GameFile = "Data/games.json";

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
        var repo = new Repository<Game>();
        var games = repo.Load(GameFile);
        GameService gameService = new GameService(games);
        AdminService adminService = new AdminService(games);

        Page currentPage = Page.RoleMenu;
        Game? selectedGame = null;
        User admin = new User("admin", UserRole.Admin);
        User player = new User("budi", UserRole.User);
        User? currentUser = null;

        while (true)
        {
            Console.Clear();

            switch (currentPage)
            {
                case Page.RoleMenu:
                    Menu.ShowRoleMenu();
                    int roleInput = Menu.GetInput();

                    if (roleInput == 0)
                        return;

                    if (roleInput == 1)
                    {
                        currentUser = player;
                        currentPage = Page.Store;
                    }
                    else if (roleInput == 2)
                    {
                        currentUser = admin;
                        currentPage = Page.AdminMenu;
                    }
                    else
                    {
                        Menu.ShowMessage("Input tidak valid");
                    }
                    break;

                case Page.Store:
                    if (currentUser == null || currentUser.Role != UserRole.User)
                    {
                        currentPage = Page.RoleMenu;
                        break;
                    }

                    Menu.ShowStore(games, currentUser);
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
                                Menu.ShowMessage(currentUser.Wallet.ChangeState(WalletAction.Activate));
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
                                    Menu.ShowMessage(currentUser.Wallet.TopUp(amount));
                                }
                            }
                            else
                            {
                                selectedGame = gameService.getGameById(storeInput);
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

                    Menu.ShowGameDetail(selectedGame);
                    int detailInput = Menu.GetInput();

                    if (detailInput == 1)
                    {
                        string message = gameService.buyGame(selectedGame, currentUser.Wallet);
                        repo.Save(GameFile, games);
                        Menu.ShowMessage(message);
                        currentPage = Page.Library;
                    }
                    else if (detailInput == 2)
                    {
                        string message = gameService.addToCart(selectedGame);
                        repo.Save(GameFile, games);
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

                    var cartGames = gameService.getCartGames();
                    int totalPrice = gameService.getTotalCartPrice();

                    Menu.ShowCart(cartGames, totalPrice);
                    int cartInput = Menu.GetInput();

                    if (cartInput == 1)
                    {
                        string message = gameService.checkoutCart(currentUser.Wallet);
                        repo.Save(GameFile, games);
                        Menu.ShowMessage(message);
                        currentPage = Page.Library;
                    }
                    else if (cartInput == 2)
                    {
                        currentPage = Page.Store;
                    }
                    else
                    {
                        Menu.ShowMessage("Input tidak valid");
                    }
                    break;

                case Page.Library:
                    var ownedGames = gameService.getOwnedGames();
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
                            selectedGame = gameService.getGameById(libraryInput);

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
                    if (selectedGame == null)
                    {
                        currentPage = Page.Library;
                        break;
                    }

                    Menu.ShowLibraryDetail(selectedGame);
                    int libraryDetailInput = Menu.GetInput();

                    if (libraryDetailInput == 1)
                    {
                        currentPage = Page.Library;
                    }
                    else if (libraryDetailInput == 2)
                    {
                        string message = gameService.requestRefund(selectedGame);
                        repo.Save(GameFile, games);
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
                            repo.Save(GameFile, games);
                            Menu.ShowMessage(message);
                        }
                    }
                    else if (adminInput == 2)
                    {
                        currentPage = Page.AdminRefundList;
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
                            selectedGame = gameService.getGameById(refundListInput);

                            if (selectedGame.Status != GameStatus.PendingRefund)
                            {
                                Menu.ShowMessage("Game tidak dalam status pending refund");
                            }
                            else
                            {
                                currentPage = Page.AdminRefundDecision;
                            }
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
                        repo.Save(GameFile, games);
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
