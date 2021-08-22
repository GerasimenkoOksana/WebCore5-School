using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore_School.Entities
{
    public class Form
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int FormTeacherId { get; set; }
        public Teacher FormTeacher { get; set; }      
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Pupil> Pupils { get; set; }
    }
}
