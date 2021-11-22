using Dalk.PropertiesSerializer;

public class TestObject
{
    // use the attribute to specify a custom name
    [PropertyName("test_int")]
    public int TestInt { get; set; }
    public string TestString { get; set; }
    public bool TestBool { get; set; }
    public SecondTestObject SecondTestObject { get; set; }
}