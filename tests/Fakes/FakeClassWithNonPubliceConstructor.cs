namespace PowerUtils.xUnit.Extensions.Tests.Fakes
{
    public class FakeClassWithNonPubliceConstructor
    {
        public string FirstName { get; private set; }
        public string LasttName { get; private set; }
        public int Age { get; private set; }

        private FakeClassWithNonPubliceConstructor()
        {
            FirstName = "Fake first name";
            LasttName = "Fake last name";
            Age = 21;
        }

        protected FakeClassWithNonPubliceConstructor(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LasttName = lastName;
            Age = age;
        }

        private FakeClassWithNonPubliceConstructor(int age, string firstName, string lastName)
        {
            FirstName = firstName;
            LasttName = lastName;
            Age = age;
        }
    }
}
