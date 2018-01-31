namespace TheFollow.Models.Interfaces
{
	internal interface IPickable
	{
		uint PickWeight { get; set; }
		uint MinPickChance { get; set; }
		uint MaxPickChance { get; set; }
	}
}