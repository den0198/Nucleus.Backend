using Microsoft.Extensions.Caching.Memory;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class CatalogServiceInitialParams
{
    public CatalogServiceInitialParams(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
    {
        MemoryCache = memoryCache;
        Repository = unitOfWork.CatalogRepository;
    }

    public ICatalogRepository Repository { get; }
    public IMemoryCache MemoryCache { get; }
}