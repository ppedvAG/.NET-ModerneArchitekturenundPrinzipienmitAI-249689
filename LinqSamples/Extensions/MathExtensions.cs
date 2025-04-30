using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinqSamples.Extensions;

public static class MathExtensions
{
    // Quersumme berechnen
    public static int DigitSum(this int number)
    {
        return number.ToString()
            .Sum(c => (int)char.GetNumericValue(c));
    }
}
