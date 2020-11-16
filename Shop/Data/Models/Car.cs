using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Car
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string ShortDesk { set; get; }
        public string LongDesk { set; get; }
        public string Img { set; get; }
        public ushort Price { set; get; }
        public bool IsFavourite { set; get; }
        public bool AvaiLable { set; get; }
        public int CotegoryId { set; get; }
        public virtual Category Category { set; get; }
    }
}
