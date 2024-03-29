﻿using Nucleus.ModelsLayer.Options;

namespace Nucleus.TestsHelpers.Builders;

public sealed class AuthOptionBuilder : CoreBuilder<AuthOptions>
{
    public AuthOptionBuilder()
    {
        Entity = new AuthOptions
        {
            Audience = AnyValue.String,
            Issuer = AnyValue.String,
            Key = AnyValue.String,
            Lifetime = AnyValue.Short
        };
    }
}