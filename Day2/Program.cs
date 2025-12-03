string rawInput = File.ReadAllText("input.txt");

var ranges = rawInput.Split(",");
List<ProcessIds> idRanges = new List<ProcessIds>();

foreach (var range in ranges)
{
    idRanges.Add(new ProcessIds {StartingId = long.Parse(range.Split("-")[0]), EndId = long.Parse(range.Split("-")[1])});
}

long sum = 0;

foreach (var idRange in idRanges)
{
    while (idRange.StartingId <= idRange.EndId)
    {
        var repeatingDigits = HasRepeatingPattern(idRange.StartingId);
        sum += repeatingDigits.Sum(x => long.Parse(x.Key) * x.Value);
        idRange.StartingId++;
    }
}

Console.WriteLine($"Part two result {sum}");

static Dictionary<string, long> HasRepeatingPattern(long value)
{
    Dictionary<string, long> repeatingDigits = new Dictionary<string, long>();

    List<int> divideables = new List<int>
    {
        2, 3, 5, 7 // For part one, only add 2 to the list
    };

    foreach (var divideable in divideables)
    {
        int lenght = value.ToString().Length / divideable;

        if (value.ToString().Length % divideable != 0)
        {
            continue;
        }
        
        List<string> values = new List<string>();
        for (int i = 0; i < divideable; i++)
        {
            values.Add(value.ToString().Substring((lenght * i), lenght));
        }

        if (values.All(x => x == values[0]))
        {
            Console.WriteLine($"Repeating {value}");
            if (repeatingDigits.ContainsKey(value.ToString()))
            {
                repeatingDigits[value.ToString()]++;
                break;
            }
            else
            {
                repeatingDigits.Add(value.ToString(), 1);
                break;
            }
        }
    }
    
    return repeatingDigits;
}

class ProcessIds
{
    public long StartingId = 0;
    public long EndId = 0;
}