﻿namespace Nucleus.ModelsLayer.Entities;

public sealed class Parameter : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
    public IEnumerable<ParameterValue> ParameterValues { get; set; }
    public IEnumerable<SubProductParameterValue> SubProductParameterValues { get; set; }
}