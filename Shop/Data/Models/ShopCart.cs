using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent) => this.appDBContent = appDBContent;
        public string ShopCartId { get; set; } 
        public List<ShopCarItem> ListshopItems { get; set; }


        public static ShopCart GetCart(IServiceProvider service) {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ??Guid.NewGuid().ToString();

            session.SetString("CardId",shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
          
        }

        public  void AddToCar(Car car) {
            this.appDBContent.ShopCarItems.Add(new ShopCarItem
            {
                ShopCarId =ShopCartId,
                Car = car,
                Price = car.Price
            });
            appDBContent.SaveChanges(); 
        }

        public List<ShopCarItem> getShopItems() {

            return appDBContent.ShopCarItems.Where(c => c.ShopCarId == ShopCartId).Include(s => s.Car).ToList();
        
        }
    }
}
