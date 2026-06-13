using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CreateGame_ValidData_Success()
        {
            Game game = new Game(1, "Terraria", 100000);

            Assert.AreEqual(1, game.Id);
            Assert.AreEqual("Terraria", game.Name);
            Assert.AreEqual(100000, game.Price);
            Assert.AreEqual(GameStatus.NotOwned, game.Status);
        }

        [TestMethod]
        public void CreateGame_InvalidId_ThrowsException()
        {
            bool exceptionThrown = false;

            try
            {
                new Game(0, "Terraria", 100000);
            }
            catch (Exception)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void CreateGame_EmptyName_ThrowsException()
        {
            bool exceptionThrown = false;

            try
            {
                new Game(1, "", 100000);
            }
            catch (Exception)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }
    }

    [TestClass]
    public class GameStateMachineTests
    {
        [TestMethod]
        public void AddToCart_ChangesStateToCart()
        {
            GameStateMachine sm = new GameStateMachine();

            GameStatus result =
                sm.Move(GameStatus.NotOwned, GameAction.AddToCart);

            Assert.AreEqual(GameStatus.Cart, result);
        }

        [TestMethod]
        public void Checkout_ChangesCartToOwned()
        {
            GameStateMachine sm = new GameStateMachine();

            GameStatus result =
                sm.Move(GameStatus.Cart, GameAction.Checkout);

            Assert.AreEqual(GameStatus.Owned, result);
        }

        [TestMethod]
        public void InvalidTransition_ThrowsException()
        {
            bool exceptionThrown = false;

            try
            {
                GameStateMachine sm = new GameStateMachine();

                sm.Move(
                    GameStatus.NotOwned,
                    GameAction.ApproveRefund
                );
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }
    }
}