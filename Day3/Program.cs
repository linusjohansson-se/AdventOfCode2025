// See https://aka.ms/new-console-template for more information

string rawInput = File.ReadAllText("input.txt");

List<string> batteryBank = new List<string>();

var splitInput = rawInput.Split('\n');

foreach (var line in splitInput)
{
    batteryBank.Add(line.Replace("\r", string.Empty));
}

List<BatteryJoltage> joltages = new List<BatteryJoltage>();


foreach (string battery in batteryBank)
{
    Dictionary<int, int> positions = new Dictionary<int, int>();

    for (int i = 0; i < battery.Length; i++)
    {
        positions.Add(i, int.Parse(battery[i].ToString()));
    }

    int allowedCellsCount = 12; // Set to 2 for part one and 12 for part two
    
    List<int> orderedValues = new List<int>();
    
    int start = 0;
    for (int i = allowedCellsCount; i > 0; i--)
    {
        var highestNumber = positions.Where(x => x.Key >= start)
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .First(x => battery.Length - i >= x.Key);
        orderedValues.Add(highestNumber.Value);
        start = highestNumber.Key + 1;
    }

    string totalJoltage = "";
    
    foreach (var value in orderedValues)
    {
        totalJoltage = $"{totalJoltage}{value}";
    }
    Console.WriteLine(totalJoltage);
    
    joltages.Add(new BatteryJoltage
    {
        OrderedValues = orderedValues,
        TotalJoltage = long.Parse(totalJoltage)
    });
}

long sum = joltages.Sum(x => x.TotalJoltage);
Console.WriteLine($"{sum}");

class BatteryJoltage
{
    public List<int> OrderedValues = new List<int>();
    public long TotalJoltage = 0;
}