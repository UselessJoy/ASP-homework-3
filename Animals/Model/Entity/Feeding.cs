
namespace Animals.Model.Entity
{
    public class Feeding
    {

        public int? Id { get; set; }
        public string? Time { get; set; }

        public int? Quantity { get; set; }

        public string? Type { get; set; }

        public AnimalsTable? Animals { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Time} - {Quantity} - {Type}";
        }

    }
}
