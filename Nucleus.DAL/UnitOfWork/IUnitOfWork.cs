using Nucleus.DAL.Repositories.Interfaces;

namespace Nucleus.DAL.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    IAuthRepository AuthRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IProductRepository ProductRepository { get; }
    IParameterRepository ParameterRepository { get; }
    IParameterValueRepository ParameterValueRepository { get; }
    IAddOnRepository AddOnRepository { get; }
    ISubProductRepository SubProductRepository { get; }
    ISubProductParameterValueRepository SubProductParameterValueRepository { get; }
}