using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTestingSystem.Model
{
    internal class Question 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Answer> Answers { get; set; }

        public Question(int id, string name, string description) 
        { 
            Id= id;
            Name = name;
            Description = description;
        }
    }
}
