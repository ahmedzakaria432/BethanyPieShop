using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IService
{
    public interface IShoppingCartRepository
    {

        public string ShoppingCartId { get; set; }
        

        public void AddToCart(Pie pie, int amount);
        public int RemoveFromCart(Pie pie);
        public List<ShoppingCartItem> GetShoppingCartItems();
        public void ClearCart();
        public decimal GetShoppingCartTotal();
    }
}
