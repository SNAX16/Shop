using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfacas;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopCartController:Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart) {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var intems = _shopCart.getShopItems();
            _shopCart.ListshopItems = intems;

            var obj = new ShopCartViewModels
            {
                shopCart = _shopCart
            };
            return View(obj);
        }


        public RedirectToActionResult addToCart(int id) {

            var item = _carRep.Cars.FirstOrDefault(i=>i.Id==id);
            if (item != null)
            {
                _shopCart.AddToCar(item);

            }
            return RedirectToAction("Index");
        }

    }
}
