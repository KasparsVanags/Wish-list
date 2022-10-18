namespace Wish_list.Core.Interfaces;

public interface IWish : IEntity
{
    public string Name { get; set; }
    public string? Url { get; set; }
    public string? Notes { get; set; }
}