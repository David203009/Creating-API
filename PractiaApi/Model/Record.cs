using System.ComponentModel.DataAnnotations;

namespace PractiaApi.Model
{
    public class Record
    {
        
        public int Id{ get; set; }
        public string ResultDescription{ get; set; }

        public Pacient _Pacient { get; set; }

        public Hospital _Hospital { get; set; }

        public Service _Service { get; set; }


    }
}
