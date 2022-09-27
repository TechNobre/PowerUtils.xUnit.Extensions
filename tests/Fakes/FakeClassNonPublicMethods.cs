using System.Threading.Tasks;

namespace PowerUtils.xUnit.Extensions.Tests.Fakes
{
    public class FakeClassNonPublicMethods
    {
        public bool Prop61 { get; set; } = false;


        private int _method11(int value)
            => value * 2;

        private int _method12(int value)
            => throw new System.ArgumentException("Message exception 1_2");

        private int _method21()
            => 101;


        private int _method22()
            => throw new System.ArgumentException("Message exception 2_2");

        private void _method31(int value)
        {
        }

        private void _method32(int value)
            => throw new System.ArgumentException("Message exception 3_2");

        private void _method41()
        {
        }

        private void _method42()
            => throw new System.ArgumentException("Message exception 4_2");

        private async Task<int> _method51Async(int value)
        {
            await Task.Delay(2);

            return value * 2;
        }

        private async Task<int> _method52Async(int value)
        {
            await Task.Delay(1);

            throw new System.ArgumentException("Message exception 5_2");
        }

        private async Task _method61Async()
        {
            await Task.Delay(50);

            Prop61 = true;
        }

        private Task _method62Async()
            => throw new System.ArgumentException("Message exception 6_2");

        protected int Method71()
            => 102;

        private Task<bool> _funcWithException()
            => throw new FakeException();
    }
}
