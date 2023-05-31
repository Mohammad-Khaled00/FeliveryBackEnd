using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public class RegData
    {
        public RegisterModel Model { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Customer? Customer { get; set; }
        //public FormFile? Image { get; set; }
    }
}
