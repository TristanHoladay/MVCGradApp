using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Vehicle> Fleet { get; set; }
        public IEnumerable<Item> Resources { get; set; }
    }
}
