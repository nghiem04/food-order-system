using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.User
{
    // Represents an item in the shopping cart
    public class CartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int AvailableStock { get; set; }
    }

    // Business logic manager for handling cart operations
    public class CartManager
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        // Calculate the total price of a given cart item
        public decimal CalculateItemTotal(int productId)
        {
            var item = CartItems.FirstOrDefault(i => i.ProductId == productId);
            return item != null ? item.UnitPrice * item.Quantity : 0;
        }

        // Update the quantity of an item in the cart
        public void UpdateItemQuantity(int productId, int newQuantity)
        {
            var item = CartItems.FirstOrDefault(i => i.ProductId == productId);
            if (item != null && newQuantity > 0 && newQuantity <= item.AvailableStock)
            {
                item.Quantity = newQuantity;
            }
        }

        // Remove an item from the cart by ProductId
        public void RemoveItem(int productId)
        {
            CartItems.RemoveAll(item => item.ProductId == productId);
        }

        // Check if all items in the cart have sufficient stock for checkout
        public bool CanCheckout(out string unavailableItem)
        {
            unavailableItem = null;
            foreach (var item in CartItems)
            {
                if (item.Quantity > item.AvailableStock)
                {
                    unavailableItem = item.Name;
                    return false;
                }
            }
            return true;
        }
    }
}
