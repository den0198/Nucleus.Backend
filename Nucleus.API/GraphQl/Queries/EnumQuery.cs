using Nucleus.Common.Enums;
using Nucleus.Common.Managers;

namespace Nucleus.API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public class EnumQuery : CoreQuery
{
    public Dictionary<int, string> GetExceptionCodesEnum()
    {
        return EnumManager.ToDictionary<ExceptionCodesEnum>();
    }
    
    public Dictionary<int, string> GetProductSortsEnum()
    {
        return EnumManager.ToDictionary<ProductSortsEnum>();
    }
}