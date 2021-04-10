using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Bank:IEntity
    {
        public int Id { get; set; }
        public string NameAndSurname { get; set; }
        public string CardNumber { get; set; }
        public int Cvv { get; set; }
        public string ExpirationDate { get; set; }

    }
}
