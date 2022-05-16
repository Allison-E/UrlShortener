using System;
using System.Diagnostics;
using domain = UrlShortener.Domain.Utils;

namespace UnitTests.Domain;
internal class Utility
{
    [Test]
    public void GenerateRandomInt_ShouldOnlyReturn0Or1()
    {
        int noOfIterations = 1_000;

        for (int i = 0; i < noOfIterations; i++)
        {
            int randomInt = domain.Utility.GenerateRandomInt();
            Assert.IsTrue(randomInt is 0 or 1);
        }
    }

    [Test]
    public void GenerateRandomInt_RandomNumbersShouldBeInTheBoundary()
    {
        int noOfIterations = 1_000;
        const int lowerBound = 1;
        const int upperBound = 3;

        for (int i = 0; i < noOfIterations; i++)
        {
            int randomInt = domain.Utility.GenerateRandomInt(lowerBound, upperBound);
            Assert.IsTrue(randomInt is >= lowerBound or < upperBound);
        }
    }

    [Test]
    [TestCase(3, 3)]
    [TestCase(int.MinValue, 8)]
    [TestCase(4, 2)]
    public void GenerateRandomInt_ProducesArgumentOutOfRangeException(int lower, int upper)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => domain.Utility.GenerateRandomInt(), "The function failed.", lower, upper);
    }
}
