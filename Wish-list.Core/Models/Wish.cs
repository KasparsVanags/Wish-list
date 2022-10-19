using System.ComponentModel.DataAnnotations;
using Wish_list.Core.Interfaces;
using static Wish_list.Core.Constants;

namespace Wish_list.Core.Models;

public class Wish : Entity, IWish
{
    [MaxLength(MaxWishNameLength)] public string Name { get; set; }

    [MaxLength(MaxUrlLength)] public string? Url { get; set; }

    [MaxLength(MaxNotesLength)] public string? Notes { get; set; }
}