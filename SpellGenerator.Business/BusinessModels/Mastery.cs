namespace SpellGenerator.Business.BusinessModels
{
    public class Mastery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Mastery ParentMastery { get; set; }

        public List<Mastery> GetParentMasteries()
        {
            throw new NotImplementedException();
        }
    }
}