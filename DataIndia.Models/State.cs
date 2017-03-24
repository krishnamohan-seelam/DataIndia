using System.Collections.Generic;

namespace DataIndia.Models
{
    public class State
    {

        public State()
        {
            Districts = new HashSet<District>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
