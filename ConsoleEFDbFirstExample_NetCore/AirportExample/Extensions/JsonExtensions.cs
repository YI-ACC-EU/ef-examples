using Newtonsoft.Json;

namespace AirportExample.Extensions;
public static class JsonExtensions
{
    public static string ToJson<T>(this T item)
        => JsonConvert.SerializeObject(item, new JsonSerializerSettings() {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        });

    public static T? FromJson<T>(this string json)
        => JsonConvert.DeserializeObject<T>(json);
}