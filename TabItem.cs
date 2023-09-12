namespace AvTest;

public class TabItem
{
    public int Value { get; init; }

    public string Header => $"Header - {Value}";
}
