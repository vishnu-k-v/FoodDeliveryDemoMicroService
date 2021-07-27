using CustomerManagementAPI.DataAccess;
using CustomerManagementAPI.Models;
using Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagementAPI
{
    public class EventHandler : IHostedService, IMessageHandlerCallback
    {
        private readonly IMessageHandler _messageHandler;
        private readonly CustomerDbContext _customerDbContext;
        private readonly IServiceScopeFactory _scopeFactory;
        public EventHandler(IMessageHandler messageHandler, IServiceScopeFactory scopeFactory)
        {
            _messageHandler = messageHandler;
            _scopeFactory = scopeFactory;
            _customerDbContext = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<CustomerDbContext>();
        }
        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            JObject messageObject = JsonSerializer.Deserialize(message);
            switch (messageType)
            {
                case "OrderCreated":
                    await HandleAsync(messageObject.ToObject<OrderCreated>());
                    break;

            }



            return await Task.FromResult(true);
        }

        private async Task<bool> HandleAsync(OrderCreated e)
        {


            try
            {
                Orders orders = new Orders()
                {
                    Id = e.Id,
                    CustomerId = e.CustomerId
                };
                List<Items> Items = e.Items.Select(d => new Items
                {
                    ItemId = d.Id,
                    ItemName = d.ItemName
                }).ToList();
                await _customerDbContext.Orders.AddAsync(orders);
                await _customerDbContext.Items.AddRangeAsync(Items);
                await _customerDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                //Log.Warning("Skipped adding customer with customer id {CustomerId}.", e.CustomerId);
            }

            return true;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _messageHandler.Start(this);
            return Task.CompletedTask;
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _messageHandler.Stop();
            return Task.CompletedTask;
        }
    }
}
