using Core.BethanyDbContext;
using Core.Entity;
using Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Service
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly BethanysPieShopDbContext dbContext;

        public string ShoppingCartId { get ; set ; }
        
        public ShoppingCartRepository(BethanysPieShopDbContext  dbContext)
        {
            this.dbContext = dbContext;
        }
        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetRequiredService<BethanysPieShopDbContext>();
            string CartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", CartId);
            return new ShoppingCartRepository(context) { ShoppingCartId = CartId };

        }


        public void AddToCart(Pie pie, int amount)
        {
            var ShoppingCartItem = dbContext.shoppingCartItems.SingleOrDefault
                (ShoppingItem => ShoppingItem.Pie.PieId == pie.PieId &&
                ShoppingItem.ShoppingCartId == ShoppingCartId);
            if (ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem()
                {
                    Pie = pie,
                    Amount = 1,
                    ShoppingCartId = ShoppingCartId
                };
                dbContext.shoppingCartItems.Add(ShoppingCartItem);

            }
            else
                ShoppingCartItem.Amount++;
            dbContext.SaveChanges();



            
        }

        public void ClearCart()
        {
            dbContext.shoppingCartItems.RemoveRange(
                dbContext.shoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)

                );
            dbContext.SaveChanges();

        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return  dbContext.shoppingCartItems.
                Where(s => s.ShoppingCartId == ShoppingCartId)
                .Include(s=>s.Pie)
                .ToList(); 
        }

        public decimal GetShoppingCartTotal()
        {
            decimal total = 0;
             total = dbContext.shoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).
                Select(s => s.Pie.Price*s.Amount).Sum();
            return total; 
        }

        public int RemoveFromCart(Pie pie)
        {
            var CartItemToRemove = dbContext.shoppingCartItems.SingleOrDefault(item =>
            item.Pie.PieId==pie.PieId&&item.ShoppingCartId==ShoppingCartId

            );
          var LocalAmount=  CartItemToRemove?.Amount > 1 ?
                CartItemToRemove.Amount-- :   0;
            dbContext.SaveChanges();
            return LocalAmount;

        }
    }
}
