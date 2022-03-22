using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.InitialsParams;

public sealed class UserAccountServiceInitialParams
{
    public UserAccountServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.UserAccountRepository;
    }

    public IUserAccountRepository Repository { get; set; }
}