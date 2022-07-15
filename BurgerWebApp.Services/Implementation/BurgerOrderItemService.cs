using BurgerWebApp.DataAccess.Abstraction;
using BurgerWebApp.Domain;
using BurgerWebApp.Mappers;
using BurgerWebApp.Services.Abstraction;
using BurgerWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerWebApp.Services.Implementation
{
    public class BurgerOrderItemService : IBurgerOrderItemService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Burger> _burgerRepository;
        private readonly IRepository<BurgerOrderItem> _burgerOrderItemRepository;

        public BurgerOrderItemService(IRepository<Order> orderRepository, IRepository<Burger> burgerRepository, IRepository<BurgerOrderItem> burgerOrderItemRepository)
        {
            _orderRepository = orderRepository;
            _burgerRepository = burgerRepository;
            _burgerOrderItemRepository = burgerOrderItemRepository;
        }
        public void Create(BurgerOrderItemViewModel model)
        {
            var order = _orderRepository.GetById(model.OrderId);
            if (order == null)
            {
                throw new Exception($"Order with id: {model.OrderId} does not exist");
            }
            if (order.IsOrderCompleted)
            {
                throw new Exception("Order is already completed you cannot edit at this time");
            }
            var burger = _burgerRepository.GetById(model.Burger.Id);
            if (burger == null)
            {
                throw new Exception("Please select a valid burger");
            }
            else if (model.Quantity <= 0)
            {
                throw new Exception("Quantity cannot be 0 or less");
            }
            if (order.Burgers.Any(x => x.BurgerId == burger.Id))
            {
                var existingBurger = order.Burgers.First(x => x.BurgerId == burger.Id);
                existingBurger.Quantity += model.Quantity;
            }
            else
            {
                order.Burgers.Add(new BurgerOrderItem(burger.Id, order.Id, model.Quantity, burger.Price));
            }
            _orderRepository.Update(order);
        }

        public void Edit(BurgerOrderItemViewModel model)
        {
            var order = _orderRepository.GetById(model.OrderId);
            if (order == null)
            {
                throw new Exception($"Order with Id : {model.OrderId} does not exist.");
            }
            if (order.IsOrderCompleted)
            {
                throw new Exception("Order is already completed you cannot edit at this time");
            }
            if (model.Quantity <= 0)
            {
                throw new Exception($"Quantity cannot be 0 or less");
            }
            var editItem = order.Burgers.FirstOrDefault(x => x.Id == model.Id);
            editItem.Quantity = model.Quantity;
            _orderRepository.Update(order);
        }
        public int Delete(int id)
        {
            var order = _orderRepository.GetAll().FirstOrDefault(x => x.Burgers.Any(y => y.Id == id));
            if (order == null)
            {
                throw new Exception($"Order with id :{order.Id} does not contain item with id : {id}");
            }
            if (order.IsOrderCompleted)
            {
                throw new Exception("Order is already completed you cannot edit at this time");
            }
            var item = order.Burgers.FirstOrDefault(x => x.Id == id);
            order.Burgers.Remove(item);
            _orderRepository.Update(order);
            return order.Id;
        }

        public BurgerOrderItemViewModel GetById(int id)
        {
            var item = _burgerOrderItemRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Item with id:{id} does not exist");
            }
            return item.ToViewModel();
        }
    }
}
