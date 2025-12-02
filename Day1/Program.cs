string rawInput = File.ReadAllText("input.txt");

var splitInput = rawInput.Split("\n");

DialProcess dial = new DialProcess();


List<RotationEvent> events = new List<RotationEvent>();

foreach (var rotation in splitInput)
{
    events.Add(new RotationEvent {Direction = rotation[0].ToString(), Amount = int.Parse(rotation.Substring(1))});
}

foreach (RotationEvent ev in events)
{
    if (ev.Direction == "R") dial.ToBeChanged = ev.Amount;
    else dial.ToBeChanged = 0 - ev.Amount;

    dial = ToBeChanged(dial);
    if (dial.Dial == 0) dial.PartOneZeroHits++;
    Console.WriteLine($"Rotation result = {dial.Dial}");
}
Console.WriteLine($"Part one result {dial.PartOneZeroHits}");
Console.WriteLine($"Part two result {dial.ZeroHits}");

static DialProcess ToBeChanged(DialProcess dial)
{
    if (dial.ToBeChanged > 0)
    {
        for (int i = dial.ToBeChanged; i != 0; i--)
        {
            dial.Dial += 1;
            if (dial.Dial == 100) dial.Dial = 0;
            
            if (dial.Dial == 0) dial.ZeroHits++;
        }
    }
    else
    {
        for (int i = dial.ToBeChanged; i != 0; i++)
        {
            dial.Dial -= 1;
            if (dial.Dial == -1) dial.Dial = 99;
            
            if (dial.Dial == 0) dial.ZeroHits++;
        }
    }
    
    return dial;
}

class RotationEvent
{
    public string Direction;
    public int Amount;
}

class DialProcess
{
    public int Dial = 50;
    public int ToBeChanged = 0;
    public int ZeroHits = 0;
    public int PartOneZeroHits = 0;
}