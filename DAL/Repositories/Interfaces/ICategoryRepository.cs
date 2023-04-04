using DAL.Repositories.CrudInterface;
using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface ICategoryRepository : ICreateEntity<Category>
{
}