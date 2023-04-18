using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTestingSystem.Model
{
    class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte Balls { get; set; } = 0;

        public Answer (int id, string name, string description, Byte balls)
        {
            Id = id;
            Name = name;
            Description = description;
            Balls = balls;
        }
    }
}
