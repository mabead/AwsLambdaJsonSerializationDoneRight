using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

public class WellBehavedJsonSerializer : Amazon.Lambda.Serialization.Json.JsonSerializer
{
    public WellBehavedJsonSerializer()
        : base(
            // Step 1: Customize the serializer settings
            CustomizeSerializerSettings, 
            // Step 2: Use Pascal Case
            new CamelCaseNamingStrategy()
            )
    {

    }

    private static void CustomizeSerializerSettings(JsonSerializerSettings settings)
    {
        settings.Converters = new List<JsonConverter>
        {
            new StringEnumConverter() 
            {
                CamelCaseText = false 
            },
        };
        settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
    }
}
