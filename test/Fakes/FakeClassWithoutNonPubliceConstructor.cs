namespace PowerUtils.xUnit.Extensions.Tests.Fakes
{
    public class FakeClassWithoutNonPubliceConstructor
    {
        public string FirstName { get; private set; }
        public string LasttName { get; private set; }
        public int Age { get; private set; }

        public FakeClassWithoutNonPubliceConstructor()
        {
            this.FirstName = "Non public fake first name";
            this.LasttName = "Non public fake last name";
            this.Age = 21;
        }

        public FakeClassWithoutNonPubliceConstructor(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LasttName = lastName;
            this.Age = age;
        }

        public FakeClassWithoutNonPubliceConstructor(int age, string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LasttName = lastName;
            this.Age = age;
        }
    }
}