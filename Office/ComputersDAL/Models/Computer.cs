using System.Collections.Generic;

namespace ComputersDAL
{
    public class Computer
    {
        public Computer()
        {
            Monitors = new HashSet<Monitor>();
            Printers = new HashSet<Printer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Monitor> Monitors { get; set; }
        public virtual ICollection<Printer> Printers { get; set; }
    }
}
