# Dalk.Properties
 A properties serializer for C#


## Documentation

### import the classes
```csharp
// import the serializer classes
using Dalk.PropertiesSerializer;
```

### create a type to serialize
```csharp
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
```

### serialize an object
```csharp
string properties = Serializer.Serialize(@object);
```

### deserialize a string
```csharp
var @object = Serializer.Deserialize<TestObject>(properties);
```

