namespace PowerUtils.xUnit.Extensions.Tests.Fakes
{
    public class FakeClassNonPublicProperties
    {
        public string PropSetPrivate { get; private set; }

        private string _propPrivate { get; set; }

        protected string PropProtected { get; set; }

        private string _privateField;

        protected string ProtectedField;

        public string GetValueOf_propPrivate()
            => _propPrivate;

        public string GetValueOf_privateField()
            => _privateField;

        public string GetValueOfPropProtected()
            => PropProtected;

        public string GetValueOfProtectedField()
            => ProtectedField;
    }
}
