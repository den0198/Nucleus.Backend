using HotChocolate.Types;

namespace Nucleus.Models.GraphQl;

public abstract class CoreType <T> : ObjectType<T> where T : class
{ 
    protected override void Configure(IObjectTypeDescriptor<T> descriptor)
    {
        descriptor.Name(getName());
    }
    
    private static string getName()
    {
        var fullName = typeof(T).Name;
        
        return fullName.TrimEnd("SubInput".ToCharArray());
    }
}