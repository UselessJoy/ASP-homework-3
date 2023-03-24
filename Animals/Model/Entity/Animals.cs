namespace Animals.Model.Entity
{
    public class AnimalsTable
    {

        public int? Id { get; set; }

        public string? Type { get; set; }
        public string? Name { get; set; }

        public int? Age { get; set; }

        public int? Weight { get; set; }

        public int? Height { get; set; }

        public int? FeedingId { get; set; }
        public Feeding? Feeding { get; set; }

        public int? CellId { get; set; }
        public Cell? Cell { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Type} - {Name} - {Age} - {Weight} - {Height} - {FeedingId} - {CellId}";
        }
    }
}
