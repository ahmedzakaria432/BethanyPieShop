using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IService
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
