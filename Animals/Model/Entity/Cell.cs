
namespace Animals.Model.Entity
{
    public class Cell
    {
        public int? Id { get; set; }
        public string? Type { get; set; }
        public string? Place { get; set; }

        public List<AnimalsTable>? Animals { get; set; } = new List<AnimalsTable>();

        public override string ToString()
        {
            return $"{Id} - {Type} - {Place}";
        }
    }
}
