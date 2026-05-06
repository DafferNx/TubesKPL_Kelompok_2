using System;
using System.Collections.Generic;

class Program
{
    private enum Page
    {
        Store,
        Detail,
        Cart,
        Library,
        LibraryDetail
    }

    static void Main()
    {
        Console.WriteLine("=== SETIM ===");

        var repo = new Repository<Game>();
        var games = repo.Load("games.json");
        GameService service = new GameService(games);

        Page currentPage = Page.Store;
        Game? selectedGame = null;

        while (true)
        {
            switch (currentPage)
            {
                case Page.Store:
                    Menu.ShowStore(games);
                    int storeInput = Menu.GetInput();

                    if (storeInput == 0)
                        return;

                    if (storeInput >= 1 && storeInput <= 10)
                    {
                        try
                        {
                            selectedGame = service.getGameById(storeInput);
                            currentPage = Page.Detail;
                        }
                        catch (Exception ex)
                        {
                            Menu.ShowMessage(ex.Message);
                        }
                    }
                    else if (storeInput == 11)
                    {
                        currentPage = Page.Library;
                    }
                    else if (storeInput == 12)
                    {
                        currentPage = Page.Cart;
                    }
                    else
                    {
                        Menu.ShowMessage("Input tidak valid");
                    }
                    break;

                case Page.Detail:
                    if (selectedGame == null)
                    {
                        currentPage = Page.Store;
                        break;
                    }

                    Menu.ShowGameDetail(selectedGame);
                    int detailInput = Menu.GetInput();

                    if (detailInput == 1)
                    {
                        string message = service.buyGame(selectedGame);
                        Menu.ShowMessage(message);
                        currentPage = Page.Library;
                    }
                    else if (detailInput == 2)
                    {
                        string message = service.addToCart(selectedGame);
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
                    var cartGames = service.getCartGames();
                    int totalPrice = service.getTotalCartPrice();

                    Menu.ShowCart(cartGames, totalPrice);
                    int cartInput = Menu.GetInput();

                    if (cartInput == 1)
                    {
                        string message = service.checkoutCart();
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
                    var ownedGames = service.getOwnedGames();
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
                            selectedGame = service.getGameById(libraryInput);

                            if (selectedGame.Status != GameStatus.Owned)
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
                        string message = service.refundGame(selectedGame);
                        Menu.ShowMessage(message);
                        currentPage = Page.Library;
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
