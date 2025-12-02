string rawInput = File.ReadAllText("input.txt");

var ranges = rawInput.Split(",");
List<ProcessIds> idRanges = new List<ProcessIds>();

foreach (var range in ranges)
{
    idRanges.Add(new ProcessIds {StartingId = int.Parse(range.Split("-")[0]), EndId = int.Parse(range.Split("-")[1])});
}

int sum = 0;

foreach (var idRange in idRanges)
{
    while (idRange.StartingId <= idRange.EndId)
    {
        var repeatingDigits = HasRepeatingPattern(idRange.StartingId);
        sum += repeatingDigits.Where(x => x.Value > 1).Sum(x => x.Value);
        idRange.StartingId++;
    }
}

Console.WriteLine($"Part one result {sum}");

static Dictionary<string, int> HasRepeatingPattern(int value)
{
    Dictionary<string, int> repeatingDigits = new Dictionary<string, int>();
    
    for (int x = 0; x < value.ToString().Length - 1; x++)
    {
        for (int i = value.ToString().Substring(x).Length; i > 0; i--)
        {
            string substring = value.ToString().Substring(0, i);
            if (repeatingDigits.ContainsKey(substring))
            {
                repeatingDigits[substring]++;
            }
            else
            {
                repeatingDigits.Add(substring, 1);
            }
        }
    }

    foreach (var digit in repeatingDigits.Values)
    {
        bool FoundDigit = false;
        int startIndex =
        while (!FoundDigit)
        {
            
        }
        value.ToString().Substring(0, digit);
    }
    
    return repeatingDigits;
}

class ProcessIds
{
    public int StartingId = 0;
    public int EndId = 0;
}