﻿using Microsoft.AspNetCore.Identity;

namespace Nucleus.ModelsLayer.Entities;

public class User : IdentityUser<long>, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
}