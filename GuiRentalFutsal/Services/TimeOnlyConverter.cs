using System.Text.Json;
using System.Text.Json.Serialization;

namespace GuiRentalFutsal.Services
{
    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm";

        public override TimeOnly Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string? value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value))
            {
                return default;
            }

            return TimeOnly.ParseExact(value, TimeFormat);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TimeOnly value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(TimeFormat));
        }
    }
}