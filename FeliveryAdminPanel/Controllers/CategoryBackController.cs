
using FeliveryAdminPanel.Helpers;
using FeliveryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BackEndRestaurant.Controllers
{
    public class CategoryBackController : Controller
    {    
        APIClient _api = new APIClient();    
        public async Task<IActionResult> Index()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var CategoryList = await Client.GetFromJsonAsync<List<Category>>("api/Category");
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
            Category Category = new Category();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Category/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                Category = JsonConvert.DeserializeObject<Category>(data);
            }
            return View(Category);
        }
        public async Task<IActionResult> Create()
        {

            HttpClient client = _api.Initial();
            //Restaurant drop down list
            var restaurantList = await client.GetFromJsonAsync<List<Restaurant>>("api/Store");
            SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");
            ViewBag.RestaurantList = RestaurantsSelectList;
            return View();
          
        }  
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/Category",category); 
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {
            Category Category = new Category();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Category/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                Category = JsonConvert.DeserializeObject<Category>(data);
            }
            //Restaurant drop down list
            var restaurantList = await client.GetFromJsonAsync<List<Restaurant>>("api/Store");
            SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");
            ViewBag.RestaurantList = RestaurantsSelectList;
            return View(Category);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Category category)
        {      
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync<Category>("api/Category", category);
              
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            
            return View(category);
        }
        public async Task <ActionResult> Delete(int? id)
        {
            Category Category = new Category();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Category/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                Category = JsonConvert.DeserializeObject<Category>(data);
            }
            return View(Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.DeleteAsync($"api/Category/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
