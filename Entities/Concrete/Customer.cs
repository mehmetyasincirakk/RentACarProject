using Core.DataAccess.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        public int UserID { get; set; }
        public string CompanyName { get; set; }
    }
}
