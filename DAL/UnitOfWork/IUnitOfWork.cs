using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    IAuthRepository AuthRepository { get; }
    IProductRepository ProductRepository { get; }
    IParameterRepository ParameterRepository { get; }
    IParameterValueRepository ParameterValueRepository { get; }
    IAddOnRepository AddOnRepository { get; }
}