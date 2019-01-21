using System.Collections.Generic;
using DevShop.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevShopTests.Models
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void CartQuantityTotalReturnsCorrectValue()
        {
            //Arrange
            var cart = new Cart()
            {
                CartBooks = new List<CartBook>()
                {
                    new CartBook() {Book = new Book() {}, Quantity = 2},
                    new CartBook() {Book = new Book() {}, Quantity = 1},
                }
            };

            //Act
            var totalQuantity = cart.QuantityTotal;

            //Assert
            Assert.AreEqual(totalQuantity, 3);
        }

        [TestMethod]
        public void CartTotalPriceReturnsCorrectValue()
        {
            //Arrange
            var cart = new Cart()
            {
                CartBooks = new List<CartBook>()
                {
                    new CartBook() {Book = new Book() {Price = 120.25M}, Quantity = 1},
                    new CartBook() {Book = new Book() {Price = 25}, Quantity = 2},
                }
            };

            //Act
            var totalPrice = cart.PriceTotal;

            //Assert
            Assert.AreEqual(totalPrice, 170.25M);
        }
    }
}
