using System.Threading.Tasks;

namespace PowerUtils.xUnit.Extensions.Tests.Fakes;

public static class FakeStaticClass
{
    private static int _method1_1(int value)
    {
        return value * 2;
    }

    private static int _method1_2(int value)
    {
        throw new System.ArgumentException("Message exception 1_2");
    }

    private static int _method2_1()
    {
        return 101;
    }

    private static int _method2_2()
    {
        throw new System.ArgumentException("Message exception 2_2");
    }

    private static void _method3_1(int value)
    {
    }

    private static void _method3_2(int value)
    {
        throw new System.ArgumentException("Message exception 3_2");
    }
    private static void _method4_1()
    {
    }

    private static void _method4_2()
    {
        throw new System.ArgumentException("Message exception 4_2");
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    private async static Task<int> _method5_1Async(int value)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        return value * 2;
    }

    private async static Task<int> _method5_2Async(int value)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        throw new System.ArgumentException("Message exception 5_2");
    }

    private static Task _method6_1Async()
    {
        return Task.CompletedTask;
    }

    private static Task _method6_2Async()
    {
        throw new System.ArgumentException("Message exception 6_2");
    }
}