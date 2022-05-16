using System.Security.Cryptography;

namespace UrlShortener.Domain.Utils;
public static class Utility
{
    /// <summary>
    /// Generates a positive random number between 0 and 1.
    /// </summary>
    /// <returns>A random number.</returns>
    public static int GenerateRandomInt()
    {
        var random = generateRandomDouble();

        return (random < 0.5) ? 0 : 1;
    }

    /// <summary>
    /// Generates a positive random number between 0 and the maximimum indicated (exclusive).
    /// </summary>
    /// <param name="exclusiveMax">Upper bound (exclusive).</param>
    /// <returns>A random integer.</returns>
    public static int GenerateRandomInt(int exclusiveMax)
    {
        return GenerateRandomInt(0, exclusiveMax);
    }

    /// <summary>
    /// Generates a positive random number between a given min (inclusive) and max (exclusive).
    /// </summary>
    /// <param name="inclusiveMin">Lower bound (inclusive).</param>
    /// <param name="exclusiveMax">Upper bound (exclusive).</param>
    /// <returns>A random integer.</returns>
    public static int GenerateRandomInt(int inclusiveMin, int exclusiveMax)
    {
        if (exclusiveMax - inclusiveMin == 1)
            return inclusiveMin;
        if (inclusiveMin == exclusiveMax)
            throw new ArgumentOutOfRangeException($"exclusiveMax should be greater than inclusiveMin.");
        if (inclusiveMin > exclusiveMax)
            throw new ArgumentOutOfRangeException($"inclusiveMin should be less than exclusiveMax. {inclusiveMin} is greater than {exclusiveMax}.");
        if (inclusiveMin < 0)
            throw new ArgumentOutOfRangeException($"inclusiveMin should not be less than 0. This method returns only positive random numbers.");

        var solution = generateRandomDouble();

        int difference = exclusiveMax - inclusiveMin;
        solution = (solution * difference) + inclusiveMin;
        return (int)solution;
    }

    private static double generateRandomDouble()
    {
        byte[] randomBytes = getRandomBytes(sizeof(int));
        int randomInt = BitConverter.ToInt32(randomBytes, 0);
        double solution = (double)randomInt / int.MaxValue;
        solution = Math.Abs(solution);
        return solution;
    }

    private static byte[] getRandomBytes(int size)
    {
        var gen = RandomNumberGenerator.Create();
        byte[] randomBytes = new byte[size];
        gen.GetBytes(randomBytes);
        return randomBytes;
    }
}
