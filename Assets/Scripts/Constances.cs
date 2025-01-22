using UnityEngine;

public static class Consts
{
    public const float MetersMultiplier = 0.2921808474f * 0.5f; // 4.6748935645f; // 0.2921808474f;

    private const float min1 = 2428f;
    private const float max1 = 2873f;

    private const float min2 = 1947f;
    private const float max2 = 2305;

    private const float min3 = 726f;
    private const float max3 = 859f;

    private const float min4 = 388f;
    private const float max4 = 460f;

    private const float min5 = 148f;
    private const float max5 = 176f;

    public static float GetRadius(int category, float value, float min, float max)
    {
        float rel = (max - value) / (max - min);
        if (category == 0)
        {
            float minMax = max1 - min1;
            return max1 - rel * minMax;
        }
        if (category == 1)
        {
            float minMax = max2 - min2;
            return max2 - rel * minMax;
        }
        if (category == 2)
        {
            float minMax = max3 - min3;
            return max3 - rel * minMax;
        }
        if (category == 3)
        {
            float minMax = max4 - min4;
            return max4 - rel * minMax;
        }
        if (category == 4)
        {
            float minMax = max5 - min5;
            return max5 - rel * minMax;
        }

        return 0;
    }
}
