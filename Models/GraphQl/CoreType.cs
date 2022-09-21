using HotChocolate.Types;

namespace Common.GraphQl;

public abstract class CoreType <T> : ObjectType<T> where T : class
{ 
    protected override void Configure(IObjectTypeDescriptor<T> descriptor)
    {
        descriptor.Name(getName());
    }
    
    private string getName()
    {
        var fullName = typeof(T).Name;
        
        return fullName.TrimEnd("SubInput".ToCharArray());
    }
}