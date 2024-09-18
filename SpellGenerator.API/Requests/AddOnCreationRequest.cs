using SpellGenerator.Business.Interfaces;

namespace SpellGenerator.API.Requests
{
    public class AddOnCreationRequest
    {
        public string Name { get; set; }
        public int numericalLevel { get; set; }
        public int ManaCost { get; set; }
        public string Description { get; set; }
        public List<int> RequieredMagicsIds { get; set; }
        public List<int> RequieredMasteriesIds { get; set; }
        public List<int> AddOnIds { get; set; } = new List<int>();
    }
}
