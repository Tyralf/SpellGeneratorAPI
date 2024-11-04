using SpellGenerator.Data.DataModels.Enums;

namespace SpellGenerator.API.DTOs
{
    public class AddOnModificationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public AddOnTypeEnum Type { get; set; }  // Enum for different types of AddOns
        public int? InstabilityValue { get; set; }
        public string? ModifierValue { get; set; }
    }
}
