using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Iservice;
using Core.IService;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly IShoppingCartRepository shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository,IShoppingCartRepository shoppingCart)
        {
            this.pieRepository = pieRepository;
            this.shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart=shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };
           



            return View(shoppingCartViewModel);
        }
        public IActionResult AddToShoppingCart(int PieID)
        { var pie = pieRepository.GetPieById(PieID);
            if (!pie.Equals(null))
            {
                shoppingCart.AddToCart(pie, 1);

            }
          




          return RedirectToAction("Index");
        }
        public IActionResult RemoveFromShoppingCart(int PieID)
        {
            var pie = pieRepository.GetPieById(PieID);
            if (!pie.Equals(null))
            {
                shoppingCart.RemoveFromCart(pie);

            }





            return RedirectToAction("Index");
        }





    }
}
