using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class CreateSellerInput
{
    [Required]
    public long UserId { get; init; }
}