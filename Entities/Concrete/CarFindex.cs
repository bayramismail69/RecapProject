using Core.Entities;

namespace Entities.Concrete
{
    public class CarFindex : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public decimal FindexNot { get; set; }
    }
}