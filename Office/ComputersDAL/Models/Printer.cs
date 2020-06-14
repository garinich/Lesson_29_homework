namespace ComputersDAL
{
    public class Printer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public int? ComputerId { get; set; }

        public virtual Computer Computer { get; set; }
    }
}
