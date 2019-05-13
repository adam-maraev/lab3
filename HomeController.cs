using IGI_3.Models;
using IGI_3.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace IGI_3.Controllers
{
    public class HomeController : Controller
    {
        Repository repository;

        public HomeController(Repository repository)
        {
            this.repository = repository;
        }
        
        #region Views
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult Client()
        {
            var model = repository.GetClients();
            return View(model);
        }
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult Furniture()
        {
            var model = repository.GetFurnitures();
            return View(model);
        }
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult Order()
        {
            var model = repository.GetOrders();
            return View(model);
        }
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult Worker()
        {
            var model = repository.GetWorkers();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult AddClient()
        {
            Client model = null;
            if (HttpContext.Session.Keys.Contains("AddClient"))
            {
                model = JsonConvert.DeserializeObject<Client>(HttpContext.Session.GetString("AddClient"));
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult AddFurniture()
        {
            Furniture model = null;
            if (HttpContext.Session.Keys.Contains("AddFurniture"))
            {
                model = JsonConvert.DeserializeObject<Furniture>(HttpContext.Session.GetString("AddFurniture"));
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult AddOrder()
        {
            var model = new OrderViewModel
            {
                Order = null,
                Clients = repository.GetClients(),
                Furnitures = repository.GetFurnitures(),
                Workers = repository.GetWorkers()
            };
            if (HttpContext.Session.Keys.Contains("AddOrder"))
            {
                model.Order = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("AddOrder"));
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult AddWorker()
        {
            Worker model = null;
            if (HttpContext.Session.Keys.Contains("AddWorker"))
            {
                model = JsonConvert.DeserializeObject<Worker>(HttpContext.Session.GetString("AddWorker"));
            }
            return View(model);
        }
        #endregion

        #region Add functional
        [HttpPost]
        public ActionResult AddClient(Client client, string action)
        {
            if (action == "Add")
            {
                HttpContext.Session.Remove("AddClient");
                repository.AddClient(client);
            }
            else
            {
                HttpContext.Session.SetString("AddClient", JsonConvert.SerializeObject(client));
            }
            return RedirectToAction("Client");
        }
        [HttpPost]
        public ActionResult AddFurniture(Furniture furniture, string action)
        {
            if (action == "Add")
            {
                HttpContext.Session.Remove("AddFurniture");
                repository.AddFurniture(furniture);
            }
            else
            {
                HttpContext.Session.SetString("AddFurniture", JsonConvert.SerializeObject(furniture));
            }
            return RedirectToAction("Furniture");
        }
        [HttpPost]
        public ActionResult AddOrder(Order order, string clientName, string furnitureName, string workerName, string action)
        {
            order.Client = repository.GetClientByName(clientName);
            order.Furniture = repository.GetFurnitureByName(furnitureName);
            order.Worker = repository.GetWorkerByName(workerName);
            if (action == "Add")
            {
                HttpContext.Session.Remove("AddOrder");
                repository.AddOrder(order);
            }
            else
            {
                HttpContext.Session.SetString("AddOrder", JsonConvert.SerializeObject(order));
            }

            return RedirectToAction("Order");
        }
        [HttpPost]
        public ActionResult AddWorker(Worker worker, string action)
        {
            if (action == "Add")
            {
                HttpContext.Session.Remove("AddWorker");
                repository.AddWorker(worker);
            }
            else
            {
                HttpContext.Session.SetString("AddWorker", JsonConvert.SerializeObject(worker));
            }
            return RedirectToAction("Worker");
        }
        #endregion
    }
}