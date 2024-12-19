using System;
using UnityEngine;

public class CalculateLargeNumbers
{

    public (float, int) Calculate(float mantissa)
    {
        int exponent = 0;
        exponent += (int)MathF.Log10(MathF.Abs(mantissa));
        int tmp = (exponent % 3) + 1;
        exponent -= tmp - 1;
        mantissa = MathF.Abs(mantissa) / MathF.Pow(10, exponent);
        if (mantissa >= 1000)
        {
            mantissa /= 10;
            exponent++;
        }
        while (mantissa < 1 && mantissa > 0)
        {
            mantissa = Mathf.Abs(mantissa) * 1000f;
            exponent -= 3;
        }
        return (mantissa, exponent);
    }
}
