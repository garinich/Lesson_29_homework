namespace ComputersDAL
{
    public class Monitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Diagonal { get; set; }
        public int? ComputerId { get; set; }

        public virtual Computer Computer { get; set; }
    }
}
