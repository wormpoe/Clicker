using UnityEngine;
using Zenject;

public class CalculatePrice
{
    [Inject]
    private CalculateLargeNumbers _calculateLargeNumbers;

    public (float, int) CalculateTempPrice(float price, int exponent, float scale, int count)
    {
        float newPrice;
        int newExponent;
        var tmpPrice = _calculateLargeNumbers.Calculate(price);
        newExponent = tmpPrice.Item2 + exponent;
        if (newExponent > 0)
        {
            newPrice = tmpPrice.Item1 * (1 - Mathf.Pow(scale, count)) / (1 - scale);
        }
        else
        {
            newPrice = Mathf.Floor(tmpPrice.Item1 * (1 - Mathf.Pow(scale, count)) / (1 - scale));
        }
        tmpPrice = _calculateLargeNumbers.Calculate(newPrice);
        return (tmpPrice.Item1, newExponent + tmpPrice.Item2);
    }
    public (float, int) CalculateNewPrice(float mantissa, int exponent, float scale, int count)
    {
        if (exponent > 0)
        {
            mantissa = mantissa * Mathf.Pow(scale, count);
        }
        else
        {
            mantissa = Mathf.Floor(mantissa * Mathf.Pow(scale, count));
        }
        var newPrice = _calculateLargeNumbers.Calculate(mantissa);
        return newPrice;
    }
}
