﻿using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.ModelsLayer.Service.Results;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface ICatalogService
{
    /// <summary>
    /// Получить каталог
    /// </summary>
    /// <param name="parameters">Параметры для получения каталога</param>
    /// <returns>Каталог</returns>
    public Task<CatalogResult> GetCatalog(GetCatalogParameters parameters);
}