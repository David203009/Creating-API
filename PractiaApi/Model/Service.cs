using System.ComponentModel.DataAnnotations;

namespace PractiaApi.Model
{
    public class Service
    {
  
        public int ServiceId { get; set; }
       
        public string NameService { get; set; }

        public ICollection<HospitalService>? HospitalServices{ get; set; }

    }
}
