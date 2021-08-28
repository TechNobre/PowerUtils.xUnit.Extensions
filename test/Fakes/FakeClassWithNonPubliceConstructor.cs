namespace PowerUtils.xUnit.Extensions.Tests.Fakes
{
    public class FakeClassWithNonPubliceConstructor
    {
        public string FirstName { get; private set; }
        public string LasttName { get; private set; }
        public int Age { get; private set; }

        private FakeClassWithNonPubliceConstructor()
        {
            this.FirstName = "Fake first name";
            this.LasttName = "Fake last name";
            this.Age = 21;
        }

        protected FakeClassWithNonPubliceConstructor(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LasttName = lastName;
            this.Age = age;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private FakeClassWithNonPubliceConstructor(int age, string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LasttName = lastName;
            this.Age = age;
        }
    }
}