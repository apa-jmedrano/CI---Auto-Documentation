namespace AiprAutoDocumentationReview;

public static class MathUtils
{
    public static int Add(int left, int right) => left + right;

    public static int Subtract(int left, int right) => left - right;

    public static int Multiply(int left, int right) => left * right;

    public static double Divide(double dividend, double divisor)
    {
        if (divisor == 0)
        {
            throw new DivideByZeroException("Divisor cannot be zero.");
        }

        return dividend / divisor;
    }

    public static bool IsEven(int value) => value % 2 == 0;

    public static bool IsOdd(int value) => value % 2 != 0;

    public static long Factorial(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be non-negative.");
        }

        long result = 1;

        for (int i = 2; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}