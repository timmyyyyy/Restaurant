using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes
{
    public class MenuItemAvailabilityJsonConverter : JsonConverter<MenuItemAvailability>
    {
        public override MenuItemAvailability? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);

            var typeString = jsonDocument.RootElement.GetProperty(nameof(MenuItemAvailability.MenuItemAvailabilityType)).GetString()!;
            var type = Enum.Parse(typeof(MenuItemAvailabilityType), typeString, true);

            var rawText = jsonDocument.RootElement.GetRawText();
            return type switch
            {
                MenuItemAvailabilityType.HoursOfTheDay =>
                    JsonSerializer.Deserialize<MenuItemHoursOfDayAvailability>(rawText, options),
                MenuItemAvailabilityType.DaysOfTheWeek =>
                    JsonSerializer.Deserialize<MenuItemDaysOfWeekAvailability>(rawText, options),
                MenuItemAvailabilityType.DatePeriod =>
                    JsonSerializer.Deserialize<MenuItemDatePeriodAvailability>(rawText, options),
                MenuItemAvailabilityType.SpecificDates =>
                    JsonSerializer.Deserialize<MenuItemSpecificDatesAvailability>(rawText, options),
                _ => throw new InvalidOperationException("Not supported MenuItemAvailabilityType")
            };
        }

        public override void Write(Utf8JsonWriter writer, MenuItemAvailability value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}
