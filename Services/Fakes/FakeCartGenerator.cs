using Bogus;
using demo.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Services.Fakes
{
    public class FakeCartGenerator
    {
        static string[] models = new[] { "Road Galleon", "Rainy Dream", "Rattle Buggy", "Bullet Blaster", "Koopa Dasher", "Heart Coach", "Goo-Goo Buggy" };
        static string[] colors = new[] { "racing red", "green", "sky blue", "sunrise yellow", "night black", "ocean pearl", "stormy gray" };
        static string[] style = new[] { "Kart", "Racer", "Cruiser", "Charger" };
        static int[] seats = new[] { 1, 2 };


        public static List<KartItem> Generate(int count)
        {
            var fakeKartGenerator = new Faker<KartItem>()

                    .StrictMode(true)
                    .RuleFor(o => o.VIN, f => f.Vehicle.Vin())
                    .RuleFor(o => o.Color, f => f.PickRandom(colors))
                    .RuleFor(o => o.Model, f => f.PickRandom(models))
                    .RuleFor(o => o.Seats, f => f.PickRandom(seats))
                    .RuleFor(o => o.Style, f => f.PickRandom(style))
                    .RuleFor(o => o.MPG, f => f.Random.Decimal(15, 50))
                    .RuleFor(o => o.LastServiceDate, f => f.Date.Past(3, DateTime.UtcNow))
                    .RuleFor(o => o.FuelType, f => f.Random.Enum<KartFuelType>());

            return fakeKartGenerator.Generate(count);
        }
    }
}
