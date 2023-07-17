using System.ComponentModel.DataAnnotations;

namespace PractiaApi.Model
{
    public class Hospital
    {
        
        public int HospitalId { get; set; }
        public string? Organization { get; set; }
        public string? Address { get; set; }

        public ICollection<HospitalService>? HospitalServices { get; set; }
        
    }
}
