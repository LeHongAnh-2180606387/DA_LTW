using Microsoft.AspNetCore.Mvc;
using System;

namespace VoLeAnhTien_2180604444_Tuan6.Models
{
    public class CartService
    {
        private List<CartItem> items = new List<CartItem>();

        public void AddToCart(Product product, int quantity)
        {
            var existingItem = items.FirstOrDefault(x => x.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem { ProductId = product.Id, Quantity = quantity });
            }
        }

        public int GetTotalItems()
        {
            return items.Sum(x => x.Quantity);
        }
    }
}
