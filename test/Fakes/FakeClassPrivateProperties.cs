namespace PowerUtils.xUnit.Extensions.Tests.Fakes
{
    public class FakeClassPrivateProperties
    {
        public string PropSetPrivate { get; private set; }

        private string _propPrivate { get; set; }

        protected string PropProtected { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        private string _privateField;

        protected string ProtectedField;

        public string GetValueOf_propPrivate()
        {
            return this._propPrivate;
        }

        public string GetValueOf_privateField()
        {
            return this._privateField;
        }

        public string GetValueOfPropProtected()
        {
            return this.PropProtected;
        }

        public string GetValueOfProtectedField()
        {
            return this.ProtectedField;
        }
    }
}