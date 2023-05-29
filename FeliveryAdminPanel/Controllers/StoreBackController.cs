
using FeliveryAdminPanel.Helpers;
using FeliveryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BackEndRestaurant.Controllers
{
    public class StoreBackController : Controller
    {    
        APIClient _api = new APIClient();    
        public async Task<IActionResult> Index()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var RestaurantList = await Client.GetFromJsonAsync<List<Restaurant>>("api/Store");
                return View(RestaurantList);
            }
            catch (Exception e)
            {
                return View();
            }      
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Restaurant restaurant = new Restaurant();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Store/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                restaurant = JsonConvert.DeserializeObject<Restaurant>(data);
            }
            return View(restaurant);
        }
        public async Task<IActionResult> Create()
        {
            return View();
          
        }  
        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/Store/Registration", restaurant); 
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {
            Restaurant restaurant = new Restaurant();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Store/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                restaurant = JsonConvert.DeserializeObject<Restaurant>(data);
            }
            return View(restaurant);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Restaurant restaurant)
        {      
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync<Restaurant>("api/Store", restaurant);
              
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            
            return View(restaurant);
        }
        public ActionResult Delete(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.DeleteAsync($"api/Store/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Approve(string id)
        {
            AddRoleModel addRole = new AddRoleModel() { UserId = id, Role = "ApprovedStore" };
            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.PostAsJsonAsync($"api/Admin/addrole", addRole);
            //if (res.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
        }
    }
}
