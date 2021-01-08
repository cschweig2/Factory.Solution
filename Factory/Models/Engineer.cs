using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public class Engineer
    {
        public class Engineer()
        {
            this.Machines = new HashSet<EngineerMachine>();
        }
        public int EngineerId { get; set; }
        public string EngineerName { get; set; }
        public string Certification { get; set; }
        public ICollection<EngineerMachine> Machines { get; set; }
    }
}