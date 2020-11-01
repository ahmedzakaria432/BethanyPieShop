using Core.BethanyDbContext;
using Core.Entity;
using Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Service
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BethanysPieShopDbContext dbContext;
        private readonly IShoppingCartRepository shoppingCart;

        public OrderRepository(BethanysPieShopDbContext dbContext,IShoppingCartRepository shoppingCart)
        {
            this.dbContext = dbContext;
            this.shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            dbContext.orders.Add(order);
            dbContext.SaveChanges();
           var NewId= dbContext.orders.ToList().LastOrDefault().OrderId;
            foreach (var item in shoppingCart.GetShoppingCartItems())
            {
                var OrderDetail = new OrderDetail
                {
                    Amount=item.Amount,
                    OrderId=NewId ,
                    PieId=item.Pie.PieId,
                    Price=item.Pie.Price
                };
                dbContext.OrderDetails.Add(OrderDetail);
            }

            dbContext.SaveChanges();



        }
    }
}
