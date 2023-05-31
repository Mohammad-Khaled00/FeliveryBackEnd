
using FeliveryAdminPanel.Helpers;
using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System.Net.Http;

namespace BackEndRestaurant.Controllers
{
    public class CustomerBackController : Controller
    {
       
        APIClient _api = new APIClient();    
        public async Task<IActionResult> Index()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var CustomerList = await Client.GetFromJsonAsync<List<Customer>>("api/Customer");
                return View(CustomerList);
            }
            catch (Exception e)
            {
                return View();
            }      
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Customer customer = new Customer();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Customer/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(data);
            }
            return View(customer);
        }
        public async Task<IActionResult> Create(int id)
        {      
            return View();      
        }  
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/Customer/Registration", customer); 
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {
            Customer customer = new Customer();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Customer/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(data);
            }
            return View(customer);
        }
        [HttpPost]
        public async  Task<ActionResult> Edit(int id,Customer customer)
        {      
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync<Customer>("api/Customer", customer);
            if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }        
            return View(customer);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            Customer customer = new Customer();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Customer/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(data);
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,Customer customer)
        {
            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.DeleteAsync($"api/Customer/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
       
    }
}
