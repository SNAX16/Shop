using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfacas;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CarsController : Controller {
        private readonly IAllCars allCars;
        private readonly ICarsCategory allCategory;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCategory) {

            allCars = iAllCars;
            allCategory = iCarsCategory;

        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")] 
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars=null;
            string carCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(i => i.Category.CategoruName.Equals("Электомобили")).OrderBy(i => i.Id);
                    carCategory = "Электомобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(i => i.Category.CategoruName.Equals("Классические авто")).OrderBy(i => i.Id);
                    carCategory = "Классические автомобили";
                }

            }
            var carObj = new CarsListViewModel{
                allCars = cars,
                CarCategory = carCategory


            };
            ViewBag.Title = "Страница с автомобилями";
          
            return View(carObj);
        }
    }
}
