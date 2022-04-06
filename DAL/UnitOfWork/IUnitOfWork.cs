using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserAccountRepository UserAccountRepository { get; }
    IUserDetailRepository UserDetailRepository { get; }
    IRoleRepository RoleRepository { get; }
    IAuthRepository AuthRepository { get; }
}