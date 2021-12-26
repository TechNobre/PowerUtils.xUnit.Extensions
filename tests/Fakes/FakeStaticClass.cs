using System.Threading.Tasks;

namespace PowerUtils.xUnit.Extensions.Tests.Fakes;

public static class FakeStaticClass
{
    private static int _method11(int value)
        => value * 2;

    private static int _method12(int value)
        => throw new System.ArgumentException("Message exception 12");

    private static int _method21()
        => 101;

    private static int _method22()
        => throw new System.ArgumentException("Message exception 22");

    private static void _method31(int value)
    {
    }

    private static void _method32(int value)
        => throw new System.ArgumentException("Message exception 32");

    private static void _method41()
    {
    }

    private static void _method42()
        => throw new System.ArgumentException("Message exception 42");

    private static async Task<int> _method51Async(int value)
        => value * 2;

    private static async Task<int> _method52Async(int value)
        => throw new System.ArgumentException("Message exception 52");

    private static Task _method61Async()
        => Task.CompletedTask;

    private static Task _method62Async()
        => throw new System.ArgumentException("Message exception 62");
}