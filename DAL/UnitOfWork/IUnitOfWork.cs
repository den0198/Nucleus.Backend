using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    IAuthRepository AuthRepository { get; }
    IProductRepository ProductRepository { get; }
    IParameterRepository ParameterRepository { get; }
}