namespace TheFollow.Models
{
    public interface IModifier
    {
        string Id { get; set; }
        string Perk { get; set; }
        int Value { get; set; }
    }
}