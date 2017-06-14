using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Models
{
    public class Member
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual Plan Plan { get; set; }

        [ForeignKey("Plan")]
        public string PlanCode { get; set; }
    }
}
