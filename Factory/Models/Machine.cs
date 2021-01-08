using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public class Engineer
    {
        public class Engineer()
        {
            this.Engineers = new HashSet<EngineerMachine>();
        }

        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public virtual ICollection<EngineerMachine> Engineers { get; set; }
    }
}