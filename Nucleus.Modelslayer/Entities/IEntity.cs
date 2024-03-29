﻿namespace Nucleus.ModelsLayer.Entities;

public interface IEntity
{
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
}