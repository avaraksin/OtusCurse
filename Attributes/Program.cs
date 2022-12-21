
var attr = typeof(TestClass).GetCustomAttributes(typeof(LastChangedAttribute), true).ToList();
foreach (var attribute in attr)
{
    LastChangedAttribute lastChangedAttribute = attribute as LastChangedAttribute;
    Console.WriteLine($"{lastChangedAttribute.Name} - {lastChangedAttribute.Changed} - {lastChangedAttribute.TaskName}");
}



[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class LastChangedAttribute : Attribute
{
    public string Name { get; set; }
    public string Changed { get; set; }
    public string TaskName { get; set; }

    public LastChangedAttribute(string Name, string changed, string TaskName) 
    {
        this.Name = Name;
        Changed = changed;
        this.TaskName = TaskName;
    }
}



[LastChanged("Alex", "21.12.2022", "51")]
[LastChanged("Alex", "21.12.2022", "52")]
public class TestClass
{ }