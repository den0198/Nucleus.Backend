using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Interfaces;

public interface IParameterService
{
    /// <summary>
    /// Создаёт новый параметер
    /// </summary>
    /// <param name="parameters"></param>
    Task CreateAsync(CreateParameterParameters parameters);
}