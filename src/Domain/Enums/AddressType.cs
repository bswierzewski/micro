using System.Runtime.Serialization;

namespace micro_api.Domain.Enums
{
    public enum AddressType
    {
        [EnumMember(Value = "Mac")]
        Mac = 1,

        [EnumMember(Value = "Bluetooth")]
        Ble = 2,
    }
}
