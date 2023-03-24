﻿namespace Models.Entities;

public class Catalog
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
}