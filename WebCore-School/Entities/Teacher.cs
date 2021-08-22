using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore_School.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Address { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }       
        public Form Form { get; set; }
    }
}
