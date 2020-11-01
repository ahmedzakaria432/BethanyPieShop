using Core.IService;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCartRepository shoppingCart;

        public ShoppingCartSummary(IShoppingCartRepository shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            ShoppingCartViewModel shoppingCartView = new ShoppingCartViewModel
            { ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal() ,
                Items=shoppingCart.GetShoppingCartItems()};
            return View(shoppingCartView);
        }
    }
}
