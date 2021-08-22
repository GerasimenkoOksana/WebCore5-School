using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore_School.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pupil> Pupils { get; set; }
    }
}
