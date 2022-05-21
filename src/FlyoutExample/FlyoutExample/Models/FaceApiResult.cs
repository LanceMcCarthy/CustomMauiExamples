using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace FlyoutExample.Models;

public class FaceApiResult
{
    [JsonProperty("faces")]
    public List<Face> Faces { get; set; }

    [JsonProperty("total")]
    public long Total { get; set; }
}

public class Face
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("version")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long Version { get; set; }

    [JsonProperty("urls")]
    public List<Dictionary<string, Uri>> Urls { get; set; }

    [JsonProperty("meta")]
    public Meta Meta { get; set; }
}

public class Meta
{
    [JsonProperty("confidence")]
    public double Confidence { get; set; }

    [JsonProperty("gender")]
    public List<string> Gender { get; set; }

    [JsonProperty("age")]
    public List<string> Age { get; set; }

    [JsonProperty("ethnicity")]
    public List<string> Ethnicity { get; set; }

    [JsonProperty("eye_color")]
    public List<string> EyeColor { get; set; }

    [JsonProperty("hair_color")]
    public List<string> HairColor { get; set; }

    [JsonProperty("hair_length")]
    public List<string> HairLength { get; set; }

    [JsonProperty("emotion")]
    public List<string> Emotion { get; set; }
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}


internal class ParseStringConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        long l;
        if (Int64.TryParse(value, out l))
        {
            return l;
        }
        throw new Exception("Cannot unmarshal type long");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (long)untypedValue;
        serializer.Serialize(writer, value.ToString());
        return;
    }

    public static readonly ParseStringConverter Singleton = new ParseStringConverter();
}
