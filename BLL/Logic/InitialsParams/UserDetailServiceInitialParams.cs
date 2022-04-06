using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.InitialsParams;

public sealed class UserDetailServiceInitialParams
{
    public UserDetailServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.UserDetailRepository;
    }

    public IUserDetailRepository Repository { get; }
}