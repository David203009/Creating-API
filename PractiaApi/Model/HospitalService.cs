namespace PractiaApi.Model
{
    public class HospitalService
    {
        public int HospitalId { get; set; } 
        public Hospital Hospital { get; set; } 
        public int ServiceId { get; set; }  
        public Service Service{ get; set; } 
       
    }
}
