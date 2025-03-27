using Mapster;

namespace Pbk.DataAccess.Mapping
{
    public class MapsterSettings
    {
        public static void Configure()
        {
            TypeAdapterConfig.GlobalSettings.Default.EnumMappingStrategy(EnumMappingStrategy.ByName);
            TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
         ///   TypeAdapterConfig<GnlFirma, GnlFirmaEditor>.NewConfig().PreserveReference(true);
        }
    }
}
