using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTestingSystem.Model
{
    internal class SchoolTesting
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Question> Questions { get; set; }
    }
}
