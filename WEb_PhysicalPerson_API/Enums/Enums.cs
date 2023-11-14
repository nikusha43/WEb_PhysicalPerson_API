using System.Text.Json.Serialization;

namespace WEb_PhysicalPerson_API.Enums
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ConnectionType { Friend, Relative, Colleague };

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MobileType { Office, Home, Private };

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender { Male = 1, Female = 2 };
}
