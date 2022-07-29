namespace Models.Entities;

public class Option
{
    public long OptionId { get; set; }
    public string Value { get; set; }
    
    public Property Property { get; set; }
}