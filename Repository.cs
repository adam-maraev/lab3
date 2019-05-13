using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_3.Models
{
    public class Repository
    {
        ApplicationContext context = new ApplicationContext();
        IMemoryCache memoryCache;

        public Repository(IMemoryCache cache)
        {
            memoryCache = cache;
        }

        public IEnumerable<Client> GetClients()
        {
            IEnumerable<Client> clients;
            if (!memoryCache.TryGetValue("allClients", out clients))
            {
                clients = context.Clients;

                if (clients != null)
                {
                    memoryCache.Set("allClients", clients,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(262)));
                }
            }
            return clients;
        }
        public IEnumerable<Furniture> GetFurnitures()
        {
            IEnumerable<Furniture> furnitures;
            if (!memoryCache.TryGetValue("allFurnitures", out furnitures))
            {
                furnitures = context.Furnitures;

                if (furnitures != null)
                {
                    memoryCache.Set("allFurnitures", furnitures,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(262)));
                }
            }
            return furnitures;
        }
        public IEnumerable<Order> GetOrders()
        {
            IEnumerable<Order> orders;
            if (!memoryCache.TryGetValue("allOrders", out orders))
            {
                orders = context.Orders.Include("Client").Include("Furniture").Include("Worker");

                if (orders != null)
                {
                    memoryCache.Set("allOrders", orders,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(262)));
                }
            }
            return orders;
        }
        public IEnumerable<Worker> GetWorkers()
        {
            IEnumerable<Worker> workers;
            if (!memoryCache.TryGetValue("allWorkers", out workers))
            {
                workers = context.Workers;

                if (workers != null)
                {
                    memoryCache.Set("allWorkers", workers,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(262)));
                }
            }
            return workers;
        }

        public Client GetClientByName(string name)
        {
            return context.Clients.FirstOrDefault(x => x.Name == name);
        }
        public Furniture GetFurnitureByName(string name)
        {
            return context.Furnitures.FirstOrDefault(x => x.Name == name);
        }
        public Worker GetWorkerByName(string name)
        {
            return context.Workers.FirstOrDefault(x => x.Name == name);
        }

        public void AddClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }
        public void AddFurniture(Furniture furniture)
        {
            context.Furnitures.Add(furniture);
            context.SaveChanges();
        }
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
        public void AddWorker(Worker worker)
        {
            context.Workers.Add(worker);
            context.SaveChanges();
        }
    }
}
