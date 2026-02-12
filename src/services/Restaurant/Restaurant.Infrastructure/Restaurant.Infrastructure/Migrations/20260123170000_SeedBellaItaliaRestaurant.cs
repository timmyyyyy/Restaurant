using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Migrations
{
    public partial class SeedBellaItaliaRestaurant : Migration
    {
        private static readonly Guid RestaurantId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        private static readonly Guid AddressId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        private static readonly Guid MenuId = Guid.Parse("44444444-4444-4444-4444-444444444444");
        
        private static readonly Guid AppetizersId = Guid.Parse("50000000-0000-0000-0000-000000000001");
        private static readonly Guid MainDishesId = Guid.Parse("50000000-0000-0000-0000-000000000002");
        private static readonly Guid PastaId = Guid.Parse("50000000-0000-0000-0000-000000000003");
        private static readonly Guid PizzaId = Guid.Parse("50000000-0000-0000-0000-000000000004");
        private static readonly Guid DrinksId = Guid.Parse("50000000-0000-0000-0000-000000000005");

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                INSERT INTO ""Addresses"" (""Id"", ""PostCode"", ""City"", ""Street"", ""BuildingNumber"", ""FlatNumber"")
                VALUES ('{AddressId}', '20121', 'Milan', 'Via Roma', '123', NULL);
            ");

            migrationBuilder.Sql($@"
                INSERT INTO ""Restaurants"" (""Id"", ""Name"", ""AddressId"", ""IsDeleted"", ""CreatedBy"", ""CreatedDate"")
                VALUES ('{RestaurantId}', 'Bella Italia', '{AddressId}', 0, '00000000-0000-0000-0000-000000000000', GETUTCDATE());
            ");

            InsertWorkingSchedules(migrationBuilder);

            migrationBuilder.Sql($@"
                INSERT INTO ""Menus"" (""Id"", ""Name"", ""RestaurantId"", ""IsDeleted"")
                VALUES ('{MenuId}', 'Bella Italia Menu', '{RestaurantId}', 0);
            ");

            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItemCategories"" (""Id"", ""CategoryName"", ""IsDeleted"")
                VALUES 
                    ('{AppetizersId}', 'Appetizers', 0),
                    ('{MainDishesId}', 'Main Dishes', 0),
                    ('{PastaId}', 'Pasta', 0),
                    ('{PizzaId}', 'Pizza', 0),
                    ('{DrinksId}', 'Drinks', 0);
            ");

            InsertAppetizers(migrationBuilder);
            
            InsertMainDishes(migrationBuilder);
            
            InsertPasta(migrationBuilder);
            
            InsertPizza(migrationBuilder);
            
            InsertDrinks(migrationBuilder);
        }

        private void InsertWorkingSchedules(MigrationBuilder migrationBuilder)
        {
            var mondayId = Guid.Parse("33333333-0000-0000-0000-000000000001");
            var tuesdayId = Guid.Parse("33333333-0000-0000-0000-000000000002");
            var wednesdayId = Guid.Parse("33333333-0000-0000-0000-000000000003");
            var thursdayId = Guid.Parse("33333333-0000-0000-0000-000000000004");
            var fridayId = Guid.Parse("33333333-0000-0000-0000-000000000005");
            var saturdayId = Guid.Parse("33333333-0000-0000-0000-000000000006");
            var sundayId = Guid.Parse("33333333-0000-0000-0000-000000000007");

            migrationBuilder.Sql($@"
                INSERT INTO ""WorkingSchedules"" (""Id"", ""DayOfWeek"", ""Start"", ""End"", ""RestaurantDbEntityId"", ""IsDeleted"", ""CreatedBy"", ""CreatedDate"")
                VALUES 
                    ('{mondayId}', 1, '11:00:00', '23:00:00', '{RestaurantId}', 0, '00000000-0000-0000-0000-000000000000', GETUTCDATE()),
                    ('{tuesdayId}', 2, '11:00:00', '23:00:00', '{RestaurantId}', 0, '00000000-0000-0000-0000-000000000000', GETUTCDATE()),
                    ('{wednesdayId}', 3, '11:00:00', '23:00:00', '{RestaurantId}', 0, '00000000-0000-0000-0000-000000000000', GETUTCDATE()),
                    ('{thursdayId}', 4, '11:00:00', '23:00:00', '{RestaurantId}', 0, '00000000-0000-0000-0000-000000000000', GETUTCDATE()),
                    ('{fridayId}', 5, '11:00:00', '23:00:00', '{RestaurantId}', 0, '00000000-0000-0000-0000-000000000000', GETUTCDATE()),
                    ('{saturdayId}', 6, '12:00:00', '00:00:00', '{RestaurantId}', 0, '00000000-0000-0000-0000-000000000000', GETUTCDATE()),
                    ('{sundayId}', 0, '12:00:00', '00:00:00', '{RestaurantId}', 0, '00000000-0000-0000-0000-000000000000', GETUTCDATE());
            ");
        }

        private void InsertAppetizers(MigrationBuilder migrationBuilder)
        {
            var bruschettaId = Guid.Parse("60000000-0001-0000-0000-000000000001");
            var capreseId = Guid.Parse("60000000-0001-0000-0000-000000000002");
            var prosciuttoMeloneId = Guid.Parse("60000000-0001-0000-0000-000000000003");
            var aranciniId = Guid.Parse("60000000-0001-0000-0000-000000000004");
            var calamariFrittiId = Guid.Parse("60000000-0001-0000-0000-000000000005");

            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItems"" (""Id"", ""Name"", ""Description"", ""ItemCategoryId"", ""Grammage"", ""Price"", ""IsCurrentlyDisabled"", ""MenuDbEntityId"")
                VALUES 
                    ('{bruschettaId}', 'Bruschetta', 'Toasted bread with tomatoes, basil, and olive oil', '{AppetizersId}', 150, 6.50, 0, '{MenuId}'),
                    ('{capreseId}', 'Caprese Salad', 'Fresh mozzarella, tomatoes, and basil', '{AppetizersId}', 200, 8.50, 0, '{MenuId}'),
                    ('{prosciuttoMeloneId}', 'Prosciutto e Melone', 'Parma ham with fresh melon', '{AppetizersId}', 180, 9.00, 0, '{MenuId}'),
                    ('{aranciniId}', 'Arancini', 'Sicilian rice balls with meat ragù (3 pieces)', '{AppetizersId}', 200, 7.00, 0, '{MenuId}'),
                    ('{calamariFrittiId}', 'Calamari Fritti', 'Fried calamari with lemon', '{AppetizersId}', 250, 10.50, 0, '{MenuId}');
            ");

            var prosciuttoAvailId = Guid.Parse("70000000-0001-0000-0000-000000000003");
            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItemAvailabilities"" (""Id"", ""MenuItemDbEntityId"", ""MenuItemAvailabilityType"", ""ItemAvailabilityJSON"")
                VALUES ('{prosciuttoAvailId}', '{prosciuttoMeloneId}', 0, 
                    '{{""MenuItemAvailabilityType"":0,""DaysOfWeek"":[1,2,3,4,5]}}');
            ");

            var calamariAvailId = Guid.Parse("70000000-0001-0000-0000-000000000005");
            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItemAvailabilities"" (""Id"", ""MenuItemDbEntityId"", ""MenuItemAvailabilityType"", ""ItemAvailabilityJSON"")
                VALUES ('{calamariAvailId}', '{calamariFrittiId}', 1, 
                    '{{""MenuItemAvailabilityType"":1,""StartTime"":""18:00:00"",""EndTime"":""23:00:00""}}');
            ");
        }

        private void InsertMainDishes(MigrationBuilder migrationBuilder)
        {
            var ossoBucoId = Guid.Parse("60000000-0002-0000-0000-000000000001");
            var saltimboccaId = Guid.Parse("60000000-0002-0000-0000-000000000002");
            var polloId = Guid.Parse("60000000-0002-0000-0000-000000000003");
            var bisteccaId = Guid.Parse("60000000-0002-0000-0000-000000000004");
            var branzinoId = Guid.Parse("60000000-0002-0000-0000-000000000005");

            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItems"" (""Id"", ""Name"", ""Description"", ""ItemCategoryId"", ""Grammage"", ""Price"", ""IsCurrentlyDisabled"", ""MenuDbEntityId"")
                VALUES 
                    ('{ossoBucoId}', 'Osso Buco', 'Braised veal shanks with risotto', '{MainDishesId}', 400, 22.00, 0, '{MenuId}'),
                    ('{saltimboccaId}', 'Saltimbocca alla Romana', 'Veal with prosciutto and sage', '{MainDishesId}', 300, 18.50, 0, '{MenuId}'),
                    ('{polloId}', 'Pollo alla Cacciatora', 'Hunter''s chicken with vegetables', '{MainDishesId}', 350, 16.00, 0, '{MenuId}'),
                    ('{bisteccaId}', 'Bistecca alla Fiorentina', 'Florentine T-bone steak', '{MainDishesId}', 500, 28.00, 0, '{MenuId}'),
                    ('{branzinoId}', 'Branzino al Forno', 'Oven-baked sea bass with herbs', '{MainDishesId}', 350, 24.00, 0, '{MenuId}');
            ");

            var ossoBucoAvailId = Guid.Parse("70000000-0002-0000-0000-000000000001");
            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItemAvailabilities"" (""Id"", ""MenuItemDbEntityId"", ""MenuItemAvailabilityType"", ""ItemAvailabilityJSON"")
                VALUES ('{ossoBucoAvailId}', '{ossoBucoId}', 0, 
                    '{{""MenuItemAvailabilityType"":0,""DaysOfWeek"":[4,5,6]}}');
            ");

            var bisteccaAvail1Id = Guid.Parse("70000000-0002-0000-0000-000000000004");
            var bisteccaAvail2Id = Guid.Parse("70000000-0002-0000-0000-000000000044");
            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItemAvailabilities"" (""Id"", ""MenuItemDbEntityId"", ""MenuItemAvailabilityType"", ""ItemAvailabilityJSON"")
                VALUES 
                    ('{bisteccaAvail1Id}', '{bisteccaId}', 1, 
                        '{{""MenuItemAvailabilityType"":1,""StartTime"":""19:00:00"",""EndTime"":""23:00:00""}}'),
                    ('{bisteccaAvail2Id}', '{bisteccaId}', 0, 
                        '{{""MenuItemAvailabilityType"":0,""DaysOfWeek"":[5,6,0]}}');
            ");
        }

        private void InsertPasta(MigrationBuilder migrationBuilder)
        {
            var carbonaraId = Guid.Parse("60000000-0003-0000-0000-000000000001");
            var arrabiataId = Guid.Parse("60000000-0003-0000-0000-000000000002");
            var tartufoId = Guid.Parse("60000000-0003-0000-0000-000000000003");
            var lasagneId = Guid.Parse("60000000-0003-0000-0000-000000000004");
            var ravioliId = Guid.Parse("60000000-0003-0000-0000-000000000005");

            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItems"" (""Id"", ""Name"", ""Description"", ""ItemCategoryId"", ""Grammage"", ""Price"", ""IsCurrentlyDisabled"", ""MenuDbEntityId"")
                VALUES 
                    ('{carbonaraId}', 'Spaghetti Carbonara', 'Classic Roman pasta with eggs, pecorino, and guanciale', '{PastaId}', 300, 12.50, 0, '{MenuId}'),
                    ('{arrabiataId}', 'Penne Arrabbiata', 'Spicy tomato sauce with garlic', '{PastaId}', 300, 11.00, 0, '{MenuId}'),
                    ('{tartufoId}', 'Tagliatelle al Tartufo', 'Fresh pasta with black truffle', '{PastaId}', 280, 18.00, 0, '{MenuId}'),
                    ('{lasagneId}', 'Lasagne alla Bolognese', 'Traditional meat lasagne', '{PastaId}', 350, 13.50, 0, '{MenuId}'),
                    ('{ravioliId}', 'Ravioli di Ricotta e Spinaci', 'Ricotta and spinach ravioli with butter and sage', '{PastaId}', 300, 14.00, 0, '{MenuId}');
            ");

            var tartufoAvailId = Guid.Parse("70000000-0003-0000-0000-000000000003");
            var currentYear = DateTime.UtcNow.Year;
            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItemAvailabilities"" (""Id"", ""MenuItemDbEntityId"", ""MenuItemAvailabilityType"", ""ItemAvailabilityJSON"")
                VALUES ('{tartufoAvailId}', '{tartufoId}', 2, 
                    '{{""MenuItemAvailabilityType"":2,""StartDate"":""{currentYear}-10-01T00:00:00"",""EndDate"":""{currentYear}-12-31T23:59:59""}}');
            ");
        }

        private void InsertPizza(MigrationBuilder migrationBuilder)
        {
            var margheritaId = Guid.Parse("60000000-0004-0000-0000-000000000001");
            var diavolaId = Guid.Parse("60000000-0004-0000-0000-000000000002");
            var quattroStagioniId = Guid.Parse("60000000-0004-0000-0000-000000000003");
            var prosciuttoFunghiId = Guid.Parse("60000000-0004-0000-0000-000000000004");
            var capricciosaId = Guid.Parse("60000000-0004-0000-0000-000000000005");
            var tartufoBiancoId = Guid.Parse("60000000-0004-0000-0000-000000000006");

            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItems"" (""Id"", ""Name"", ""Description"", ""ItemCategoryId"", ""Grammage"", ""Price"", ""IsCurrentlyDisabled"", ""MenuDbEntityId"")
                VALUES 
                    ('{margheritaId}', 'Margherita', 'Tomato, mozzarella, basil', '{PizzaId}', 350, 9.50, 0, '{MenuId}'),
                    ('{diavolaId}', 'Diavola', 'Spicy salami, tomato, mozzarella', '{PizzaId}', 370, 11.50, 0, '{MenuId}'),
                    ('{quattroStagioniId}', 'Quattro Stagioni', 'Four seasons - artichokes, ham, mushrooms, olives', '{PizzaId}', 400, 13.00, 0, '{MenuId}'),
                    ('{prosciuttoFunghiId}', 'Prosciutto e Funghi', 'Ham and mushrooms', '{PizzaId}', 380, 12.00, 0, '{MenuId}'),
                    ('{capricciosaId}', 'Capricciosa', 'Ham, artichokes, mushrooms, olives', '{PizzaId}', 390, 12.50, 0, '{MenuId}'),
                    ('{tartufoBiancoId}', 'Pizza al Tartufo Bianco', 'White pizza with fresh truffle', '{PizzaId}', 360, 19.00, 0, '{MenuId}');
            ");

            var tartufoAvailId = Guid.Parse("70000000-0004-0000-0000-000000000006");
            var dates = GetFirstSaturdaysOfNextMonths(12);
            var datesJson = string.Join(",", dates.Select(x => $@"""{x:yyyy-MM-dd}"""));
            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItemAvailabilities"" (""Id"", ""MenuItemDbEntityId"", ""MenuItemAvailabilityType"", ""ItemAvailabilityJSON"")
                VALUES ('{tartufoAvailId}', '{tartufoBiancoId}', 3, 
                    '{{""MenuItemAvailabilityType"":3,""SpecificDates"":[{datesJson}]}}');
            ");
        }

        private void InsertDrinks(MigrationBuilder migrationBuilder)
        {
            var espressoId = Guid.Parse("60000000-0005-0000-0000-000000000001");
            var cappuccinoId = Guid.Parse("60000000-0005-0000-0000-000000000002");
            var limoncelloId = Guid.Parse("60000000-0005-0000-0000-000000000003");
            var chiantiId = Guid.Parse("60000000-0005-0000-0000-000000000004");
            var proseccoId = Guid.Parse("60000000-0005-0000-0000-000000000005");

            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItems"" (""Id"", ""Name"", ""Description"", ""ItemCategoryId"", ""Grammage"", ""Price"", ""IsCurrentlyDisabled"", ""MenuDbEntityId"")
                VALUES 
                    ('{espressoId}', 'Espresso', 'Italian espresso coffee', '{DrinksId}', NULL, 2.50, 0, '{MenuId}'),
                    ('{cappuccinoId}', 'Cappuccino', 'Coffee with steamed milk foam', '{DrinksId}', NULL, 3.50, 0, '{MenuId}'),
                    ('{limoncelloId}', 'Limoncello', 'Traditional lemon liqueur', '{DrinksId}', 40, 5.00, 0, '{MenuId}'),
                    ('{chiantiId}', 'Chianti Classico (Glass)', 'Tuscan red wine', '{DrinksId}', 150, 7.00, 0, '{MenuId}'),
                    ('{proseccoId}', 'Prosecco (Glass)', 'Italian sparkling wine', '{DrinksId}', 125, 6.00, 0, '{MenuId}');
            ");

            var cappuccinoAvailId = Guid.Parse("70000000-0005-0000-0000-000000000002");
            migrationBuilder.Sql($@"
                INSERT INTO ""MenuItemAvailabilities"" (""Id"", ""MenuItemDbEntityId"", ""MenuItemAvailabilityType"", ""ItemAvailabilityJSON"")
                VALUES ('{cappuccinoAvailId}', '{cappuccinoId}', 1, 
                    '{{""MenuItemAvailabilityType"":1,""StartTime"":""07:00:00"",""EndTime"":""12:00:00""}}');
            ");
        }

        private static List<DateOnly> GetFirstSaturdaysOfNextMonths(int monthsCount)
        {
            var dates = new List<DateOnly>();
            var currentDate = DateTime.UtcNow;
            
            for (int i = 0; i < monthsCount; i++)
            {
                var targetMonth = currentDate.AddMonths(i);
                var firstDayOfMonth = new DateTime(targetMonth.Year, targetMonth.Month, 1);
                
                while (firstDayOfMonth.DayOfWeek != DayOfWeek.Saturday)
                {
                    firstDayOfMonth = firstDayOfMonth.AddDays(1);
                }
                
                dates.Add(DateOnly.FromDateTime(firstDayOfMonth));
            }
            
            return dates;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM \"MenuItemAvailabilities\" WHERE \"MenuItemDbEntityId\" IN (SELECT \"Id\" FROM \"MenuItems\" WHERE \"MenuDbEntityId\" = '{MenuId}');");
            migrationBuilder.Sql($"DELETE FROM \"MenuItems\" WHERE \"MenuDbEntityId\" = '{MenuId}';");
            migrationBuilder.Sql($"DELETE FROM \"MenuItemCategories\";");
            migrationBuilder.Sql($"DELETE FROM \"Menus\" WHERE \"Id\" = '{MenuId}';");
            migrationBuilder.Sql($"DELETE FROM \"WorkingSchedules\" WHERE \"RestaurantDbEntityId\" = '{RestaurantId}';");
            migrationBuilder.Sql($"DELETE FROM \"Restaurants\" WHERE \"Id\" = '{RestaurantId}';");
            migrationBuilder.Sql($"DELETE FROM \"Addresses\" WHERE \"Id\" = '{AddressId}';");
        }
    }
}

