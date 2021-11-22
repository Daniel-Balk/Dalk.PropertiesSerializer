using Dalk.PropertiesSerializer;

namespace Tests
{
    public class TestObject
    {
        public TestObject()
        {
        }
        [PropertyName("test_int")]
        public int TestInt { get; set; } = 101;
        public string TestString { get; set; } = "aaa";
        public bool TestBool { get; set; } = true;
        [PropertyName("second_obj")]
        public SecondTestObject TestSubObject { get; set; } = new();
    }
}