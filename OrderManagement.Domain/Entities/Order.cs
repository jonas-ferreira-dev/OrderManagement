using OrderManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class Order
    {
        private readonly List<OrderItem> _items = new();

        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public decimal Total => _items.Sum(i => i.Total);

        public Order(Guid customerId)
        {
            if (customerId == Guid.Empty)
                throw new ArgumentException("Cliente inválido.");

            Id = Guid.NewGuid();
            CustomerId = customerId;
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Created;
        }

        public void AddItem(Guid productId, string productName, decimal unitPrice, int quantity)
        {
            var item = new OrderItem(productId, productName, unitPrice, quantity);
            _items.Add(item);
        }

        public void MarkAsPaid()
        {
            if (!_items.Any())
                throw new InvalidOperationException("Não é possível pagar um pedido sem itens.");

            Status = OrderStatus.Paid;
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Shipped)
                throw new InvalidOperationException("Não é possível cancelar um pedido já enviado.");

            Status = OrderStatus.Cancelled;
        }
    }
}
