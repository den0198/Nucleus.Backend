﻿namespace Nucleus.ModelsLayer.Entities;

public sealed class Category : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
    
    public IEnumerable<SubCategory> SubCategories { get; set; }
}