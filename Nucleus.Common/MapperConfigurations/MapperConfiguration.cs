namespace Nucleus.Common.MapperConfigurations;

public static partial class MapperConfiguration
{
    public static void AddConfigurations()
    {
        AddInputsInParametersAndDtosConfigurations();
        AddEntitiesAndResultsInDataConfigurations();
        AddParametersAndDtosInEntitiesConfigurations();
    }
}