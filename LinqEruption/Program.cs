

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano"),
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

Eruption? chiliEruption = eruptions.FirstOrDefault(l => l.Location == "Chile");
// Console.WriteLine(chiliEruption);
try{
    Eruption Hawai = eruptions.First(h => h.Location == "Hawaiian Is");
    // Console.WriteLine(Hawai);
}catch{
    // Console.WriteLine("No Hawaiian Is Found");
}
Eruption nintys = eruptions.Where(n => n.Year > 1900 && n.Location == "New Zealand").First();
// Console.WriteLine(nintys);
IEnumerable<Eruption> allVolcanos = eruptions.Where(v => v.ElevationInMeters > 2000);
// PrintEach(allVolcanos);
IEnumerable<Eruption> zVolcano = eruptions.Where(z => z.Volcano == "z");
// PrintEach(zVolcano);
int maxEle = eruptions.Max(m => m.ElevationInMeters);
// Console.WriteLine(maxEle);
Eruption? maxVol = eruptions.FirstOrDefault( m => m.ElevationInMeters == maxEle);
Console.WriteLine(maxVol);
IEnumerable<Eruption> allNames = eruptions.OrderBy(a => a.Volcano);
// PrintEach(allNames);
IEnumerable<Eruption> exploded = eruptions.Where(e => e.Year < 990).OrderBy(o => o.Volcano);
PrintEach(exploded); 






// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}