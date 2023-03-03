using System.ComponentModel;

namespace Example.Ecommerce.Transversal.Common.Enum
{
    public enum EnumState
    {
        [Description("Active State")]
        Activo = 1,

        [Description("Active Inactive")]
        Inactivo = 2,

        [Description("Active Expired")]
        Expirado = 3,

        [Description("Active Restore")]
        Restaurado = 4
    }
}
