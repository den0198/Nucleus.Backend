using Nucleus.Common.Constants.GraphQl;
using Nucleus.Common.Enums;
using Nucleus.Common.Managers;

namespace Nucleus.API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public class EnumQuery : CoreQuery
{
    [GraphQLName(QueryNames.GET_EXCEPTION_CODES_ENUM)]
    public Dictionary<int, string> GetExceptionCodesEnum()
    {
        return EnumManager.ToDictionary<ExceptionCodesEnum>();
    }
    
    [GraphQLName(QueryNames.GET_PRODUCT_SORTS_ENUM)]
    public Dictionary<int, string> GetProductSortsEnum()
    {
        return EnumManager.ToDictionary<ProductSortsEnum>();
    }
}