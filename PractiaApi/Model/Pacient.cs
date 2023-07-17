using System.ComponentModel.DataAnnotations;

namespace PractiaApi.Model
{
    public class Pacient
    {
        
        public int Id { get; set; }
        public string firstName{ get; set; }
        public string lastName{ get; set; }
        public DateTime BirthDate{ get; set; }
        public int PhoneNumber{ get; set; }
        public char Gender{ get; set; }        
        public string Address { get; set; }
        public ICollection<Record>? Records { get; set; }


    }
}
