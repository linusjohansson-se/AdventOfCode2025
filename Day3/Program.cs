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
    
    var highestNumber = positions.OrderByDescending(x => x.Value).ThenBy(x => x.Key).First();

    int pos1 = 0;
    int pos2 = 0;
    
    if (highestNumber.Key == battery.Length - 1)
    {
        pos2 = highestNumber.Value;
        pos1 = positions.Where(x => x.Key < highestNumber.Key).OrderByDescending(x => x.Value).First().Value;
    }
    else
    {
        pos1 = highestNumber.Value;
        pos2 = positions.Where(x => x.Key > highestNumber.Key).OrderByDescending(x => x.Value).First().Value;
    }
    
    joltages.Add(new BatteryJoltage
    {
        Pos1 = pos1,
        Pos2 = pos2,
        TotalJoltage = int.Parse($"{pos1}{pos2}")
    });
    
    Console.WriteLine($"{pos1}{pos2}");
}

long sum = joltages.Sum(x => x.TotalJoltage);
Console.WriteLine($"{sum}");

class BatteryJoltage
{
    public int Pos1 = 0;
    public int Pos2 = 0;
    public int TotalJoltage = 0;
}