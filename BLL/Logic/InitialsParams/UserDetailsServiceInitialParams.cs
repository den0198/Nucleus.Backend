using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.InitialsParams;

public sealed class UserDetailsServiceInitialParams
{
    public UserDetailsServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.UserDetailsRepository;
    }

    public IUserDetailsRepository Repository { get; }
}