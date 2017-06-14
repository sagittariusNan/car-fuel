using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarFuel.Models
{
    public class Plan
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public Plan()
        {
            Members = new HashSet<Member>();
        }
    }
}