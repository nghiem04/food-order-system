using NUnit.Framework;
using FoodOrdering.User;
using System.Collections.Generic;

namespace FoodOrdering.Tests
{
    [TestFixture]
    public class CartManagerTests
    {
        private CartManager cartManager;

        [SetUp]
        public void Setup()
        {
            // Initialize the CartManager object
            cartManager = new CartManager();

            // Add some sample items to the cart
            cartManager.CartItems = new List<CartItem>
            {
                new CartItem { ProductId = 1, Name = "Apple", UnitPrice = 2.5m, Quantity = 3, AvailableStock = 10 },
                new CartItem { ProductId = 2, Name = "Banana", UnitPrice = 1.2m, Quantity = 2, AvailableStock = 5 },
                new CartItem { ProductId = 3, Name = "Orange", UnitPrice = 3.0m, Quantity = 1, AvailableStock = 3 }
            };
        }

        [Test]
        public void CalculateItemTotal_ShouldReturnCorrectTotal()
        {
            // Arrange
            var productId = 1; // Apple

            // Act
            var result = cartManager.CalculateItemTotal(productId);

            // Assert
            Assert.That(result, Is.EqualTo(7.5m)); 
        }

        [Test]
        public void UpdateItemQuantity_ShouldChangeQuantityCorrectly()
        {
            // Arrange
            var productId = 2; // Banana
            var newQuantity = 4;

            // Act
            cartManager.UpdateItemQuantity(productId, newQuantity);
            var updatedItem = cartManager.CartItems.Find(item => item.ProductId == productId);

            // Assert
            Assert.That(updatedItem.Quantity, Is.EqualTo(newQuantity)); // Equivalent to Assert.AreEqual(newQuantity, updatedItem.Quantity);
        }

        [Test]
        public void RemoveItem_ShouldRemoveItemFromCart()
        {
            // Arrange
            var productIdToRemove = 3; // Orange

            // Act
            cartManager.RemoveItem(productIdToRemove);

            // Assert
            Assert.That(cartManager.CartItems.Find(item => item.ProductId == productIdToRemove), Is.Null); // Equivalent to Assert.IsNull
        }

        [Test]
        public void CanCheckout_ShouldReturnFalseIfStockIsInsufficient()
        {
            // Arrange
            cartManager.CartItems[0].Quantity = 15; // Set quantity of "Apple" more than available stock

            // Act
            var result = cartManager.CanCheckout(out string unavailableItem);

            // Assert
            Assert.That(result, Is.False); // Equivalent to Assert.IsFalse(result)
            Assert.That(unavailableItem, Is.EqualTo("Apple")); // Equivalent to Assert.AreEqual("Apple", unavailableItem);
        }

        [Test]
        public void CanCheckout_ShouldReturnTrueIfAllItemsAreAvailable()
        {
            // Act
            var result = cartManager.CanCheckout(out string unavailableItem);

            // Assert
            Assert.That(result, Is.True); // Equivalent to Assert.IsTrue(result)
            Assert.That(unavailableItem, Is.Null); // Equivalent to Assert.IsNull(unavailableItem)
        }
    }
}

