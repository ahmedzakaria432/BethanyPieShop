using Core.Entity;
using Core.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCartRepository ShoppingCart { get; set;}
        public decimal ShoppingCartTotal { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
    }
}
