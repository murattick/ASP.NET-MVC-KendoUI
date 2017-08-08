using TelerikMvcApp.Areas.Address.Models;
using System.ComponentModel.DataAnnotations;

namespace TelerikMvcApp.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int DepartmentId { get; set; }

        [UIHint("DepartmentEditor")]
        public Department Department { get; set; }

        


    }
}