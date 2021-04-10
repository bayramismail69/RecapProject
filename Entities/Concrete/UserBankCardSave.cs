using Core.Entities;

namespace Entities.Concrete
{
    public class UserBankCardSave : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameAndSurname { get; set; }
    
        public string CardNumber { get; set; }
        public int Cvv { get; set; }
        public string ExpirationDate { get; set; }
       
    }
}