using System.Text.Json;
using System.Text.Json.Serialization;

namespace Restaurant.Domain.Aggregates.Menu.ItemAvailabilityTypes;

public class MenuItemAvailabilityJsonConverter : JsonConverter<MenuItemAvailability>
{
    public override MenuItemAvailability? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);

        var typeInt = jsonDocument.RootElement.GetProperty(nameof(MenuItemAvailability.MenuItemAvailabilityType)).GetInt32()!;
        var type = (MenuItemAvailabilityType)typeInt;

        var rawText = jsonDocument.RootElement.GetRawText();
        
        var deserializationOptions = new JsonSerializerOptions(options);
        deserializationOptions.Converters.Clear();
        deserializationOptions.IncludeFields = true;
        
        return type switch
        {
            MenuItemAvailabilityType.HoursOfTheDay =>
                JsonSerializer.Deserialize<MenuItemHoursOfDayAvailability>(rawText, deserializationOptions),
            MenuItemAvailabilityType.DaysOfTheWeek =>
                JsonSerializer.Deserialize<MenuItemDaysOfWeekAvailability>(rawText, deserializationOptions),
            MenuItemAvailabilityType.DatePeriod =>
                JsonSerializer.Deserialize<MenuItemDatePeriodAvailability>(rawText, deserializationOptions),
            MenuItemAvailabilityType.SpecificDates =>
                JsonSerializer.Deserialize<MenuItemSpecificDatesAvailability>(rawText, deserializationOptions),
            _ => throw new InvalidOperationException("Not supported MenuItemAvailabilityType")
        };
    }

    public override void Write(Utf8JsonWriter writer, MenuItemAvailability value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
    }
}

