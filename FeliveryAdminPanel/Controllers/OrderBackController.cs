
using FeliveryAdminPanel.Helpers;
using FeliveryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BackEndRestaurant.Controllers
{
    public class OrderBackController : Controller
    {    
        APIClient _api = new APIClient();    
        public async Task<IActionResult> Index()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var CategoryList = await Client.GetFromJsonAsync<List<Order>>("api/Order");
                return View(CategoryList);
            }
            catch (Exception e)
            {
                return View();
            }      
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Order order = new Order();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Order/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<Order>(data);
            }
            return View(order);
        }
        //public async Task<IActionResult> Create()
        //{
        //    HttpClient client = _api.Initial();
        //    //Restaurant drop down list
        //    var restaurantList = await client.GetFromJsonAsync<List<Restaurant>>("api/Store");
        //    SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");
        //    ViewBag.RestaurantList = RestaurantsSelectList;
        //    //Customer drop down list
        //    var CustomerList = await client.GetFromJsonAsync<List<Customer>>("api/Customer");
        //    SelectList CustomerSelectList = new SelectList(CustomerList, "Id", "Name");
        //    ViewBag.CustomerList = CustomerSelectList;
        //    return View();

        //}  
        //[HttpPost]
        //public async Task<IActionResult> Create(Order order)
        //{
        //    HttpClient client = _api.Initial();
        //    HttpResponseMessage res = await client.PostAsJsonAsync($"api/Order",order); 
        //    if (res.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //public async Task<ActionResult> Edit(int id)
        //{
        //    HttpClient client = _api.Initial();
        //    //Restaurant drop down list
        //    var restaurantList = await client.GetFromJsonAsync<List<Restaurant>>("api/Store");
        //    SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");
        //    ViewBag.RestaurantList = RestaurantsSelectList;
        //    //Customer drop down list
        //    var CustomerList = await client.GetFromJsonAsync<List<Customer>>("api/Customer");
        //    SelectList CustomerSelectList = new SelectList(CustomerList, "Id", "Name");
        //    ViewBag.CustomerList = CustomerSelectList;
        //    return View();
        //}
        //[HttpPost]
        //public async Task<ActionResult> Edit(int id, Order order)
        //{      
        //    HttpClient client = _api.Initial();
        //    HttpResponseMessage res = await client.PutAsJsonAsync<Order>("api/Order", order);

        //        if (res.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("index");
        //        }

        //    return View(order);
        //}


        public async Task<ActionResult> Delete(int? id)
        {
            Order order = new Order();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Order/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<Order>(data);
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.DeleteAsync($"api/Order/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
