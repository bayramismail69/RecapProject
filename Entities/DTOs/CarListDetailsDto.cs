using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarListDetailsDto : IDto
    {
        //burası join yapmadan önce nelere ihtiyacımız var onu belirtiyoruz 
        public int CarId { get; set; }//burayı yazdıktan sonra 
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal MinimumCarFindex { get; set; }
        public int ModelYear { get; set; }
        public List<string> ImagePath { get; set; }
    }
}
