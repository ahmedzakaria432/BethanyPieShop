using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IShoppingCartRepository shoppingCart;
        private readonly IOrderRepository orderRepository;

        public OrderController(IShoppingCartRepository shoppingCart,IOrderRepository orderRepository)
        {
            this.shoppingCart = shoppingCart;
            this.orderRepository = orderRepository;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (shoppingCart.GetShoppingCartItems().Count == 0)
            {
                ModelState.AddModelError("empty", "Your cart is empty please add some pies first!");
            }
            if(ModelState.IsValid)
            {
                orderRepository.CreateOrder(order);
                shoppingCart.ClearCart();

                return RedirectToAction("CheckoutComplete");

            }
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            TempData["CheckoutCompleteMessage"] = "thanks for your order we will send you order soon";



                return RedirectToAction("Index","Home") ;
        }
    }
}
