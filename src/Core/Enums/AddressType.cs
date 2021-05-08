using System.Runtime.Serialization;

namespace Core.Entities.Enums
{
    public enum AddressType
    {
        [EnumMember(Value = "Mac")]
        Mac = 1,

        [EnumMember(Value = "Bluetooth")]
        Ble = 2,
    }
}