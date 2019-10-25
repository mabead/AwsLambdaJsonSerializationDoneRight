using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

public class WellBehavedJsonSerializer : Amazon.Lambda.Serialization.Json.JsonSerializer
{
    public WellBehavedJsonSerializer()
        : base(CustomizeSerializerSettings, new CamelCaseNamingStrategy())
    {

    }

    private static void CustomizeSerializerSettings(JsonSerializerSettings serializerSettings)
    {
        serializerSettings.Converters = new List<JsonConverter>
        {
            new StringEnumConverter() { CamelCaseText = false },
        };
        serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
    }
}
