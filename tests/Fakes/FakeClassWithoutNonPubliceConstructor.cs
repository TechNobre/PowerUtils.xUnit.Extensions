namespace PowerUtils.xUnit.Extensions.Tests.Fakes;

public class FakeClassWithoutNonPubliceConstructor
{
    public string FirstName { get; private set; }
    public string LasttName { get; private set; }
    public int Age { get; private set; }

    public FakeClassWithoutNonPubliceConstructor()
    {
        FirstName = "Non public fake first name";
        LasttName = "Non public fake last name";
        Age = 21;
    }

    public FakeClassWithoutNonPubliceConstructor(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LasttName = lastName;
        Age = age;
    }

    public FakeClassWithoutNonPubliceConstructor(int age, string firstName, string lastName)
    {
        FirstName = firstName;
        LasttName = lastName;
        Age = age;
    }
}
