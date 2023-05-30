
using FeliveryAdminPanel.Helpers;
using FeliveryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace BackEndCategory.Controllers
{
    public class MenuItemBackController : Controller
    {
        APIClient _api = new APIClient();
       
        public async Task<IActionResult> Index()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var MenuItemList = await Client.GetFromJsonAsync<List<MenuItem>>("api/MenuItem/GetFoodServed");
                return View(MenuItemList);
            }
            catch (Exception e)
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            MenuItem MenuItemList = new MenuItem();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/MenuItem/GetById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                MenuItemList = JsonConvert.DeserializeObject<MenuItem>(data);
            }
            return View(MenuItemList);
        }

        public async Task<IActionResult> Create()
        {
            HttpClient client = _api.Initial();
            //Category drop down list
            var categoryList = await client.GetFromJsonAsync<List<Category>>("api/Category");
            SelectList CategoriesSelectList = new SelectList(categoryList, "Id", "Name");

            ViewBag.CategoryList = CategoriesSelectList;

            //Restaurant drop down list
            var restaurantList = await client.GetFromJsonAsync<List<Restaurant>>("api/Store");
            SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");

            ViewBag.RestaurantList = RestaurantsSelectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItem foodServed)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/MenuItem/Post", foodServed); 
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        } 

        public async Task<IActionResult> Edit(int id)
        {

            MenuItem MenuItemList = new MenuItem();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/MenuItem/GetById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                MenuItemList = JsonConvert.DeserializeObject<MenuItem>(data);
            }
            try
            {
                //Category drop down list
                var categoryList = await client.GetFromJsonAsync<List<Category>>("api/Category");
                SelectList CategoriesSelectList = new SelectList(categoryList, "Id", "Name");

                ViewBag.CategoryList = CategoriesSelectList;

                //Restaurant drop down list
                var restaurantList = await client.GetFromJsonAsync<List<Restaurant>>("api/Store");
                SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");

                ViewBag.RestaurantList = RestaurantsSelectList;

                return View(MenuItemList);
            }
            catch (Exception e)
            {
            }

            return View(MenuItemList);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MenuItem MenuItemList)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync("api/MenuItem/Put", MenuItemList);     
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View(MenuItemList);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            MenuItem MenuItemList = new MenuItem();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/MenuItem/GetById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                MenuItemList = JsonConvert.DeserializeObject<MenuItem>(data);
            }
            return View(MenuItemList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
                HttpResponseMessage res = await Client.DeleteAsync($"api/MenuItem/Delete/{id}");
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            return View();
        }


       



}
}