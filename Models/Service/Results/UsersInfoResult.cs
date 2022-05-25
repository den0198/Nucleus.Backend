using Models.Data;

namespace Models.Service.Results;

public class UsersInfoResult
{
    public IEnumerable<UserInfoData> Users { get; set; } = Array.Empty<UserInfoData>();
}