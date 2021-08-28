namespace PowerUtils.xUnit.Extensions.Tests.Fakes
{
    public class FakeClassPrivateProperties
    {
        public string PropSetPrivate { get; private set; }

        private string _propPrivate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        private string _privateField;

        public string GetValueOf_propPrivate()
        {
            return this._propPrivate;
        }

        public string GetValueOf_privateField()
        {
            return this._privateField;
        }
    }
}