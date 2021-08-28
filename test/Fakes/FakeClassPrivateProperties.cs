namespace PowerUtils.xUnit.Extensions.Tests.Fakes
{
    public class FakeClassPrivateProperties
    {
        public string PropSetPrivate { get; private set; }

        private string _propPrivate { get; set; }

#pragma warning disable IDE0044 // Add readonly modifier
        private string _privateField;
#pragma warning restore IDE0044 // Add readonly modifier

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