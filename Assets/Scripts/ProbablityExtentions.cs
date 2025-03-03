using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class ProbablityExtentions
{
    /// <summary>
    ///  get your luck
    /// </summary>
    /// <param name="myChance"> chance of getting true, between 0 and 1</param>
    /// <returns>true if luck, false unlucky </returns>
    public static bool Luck(float myChance)
    {
        myChance = Mathf.Clamp01(myChance);
        var value = Random.value;
        return value <= myChance;
    }
    

    public static float GetRandomBetween(this Vector2 vector) => Random.Range(vector.x, vector.y);

    public static float GetRandomBetweenWithBias(this Vector2 vector,  float exp = 2f)
    {
        var pivot = Random.value;
        var min = vector.x;
        var max = vector.y;
        
        var weightedRandom = min + (max - min) * Mathf.Pow(pivot, exp);
        return weightedRandom;
    }

    public static T GetRandom<T>(this T[] list)
    {
        return list[UnityEngine.Random.Range(0, list.Length)];
    }
    
    public static T GetRandom<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }   
    
    public static T[] GetRandomElements<T>(this List<T> list, int howMany)
    {
        return SelectRandomlyFrom(howMany, list.ToArray());
    }
    
    public static T SelectRandomlyFrom<T>(params T[] list)
    {
        var indes = Random.Range(0, list.Length);
        return list[indes];
    }

    public static T[] SelectRandomlyFrom<T>(int howMany, params T[] list)
    {
        var output = new T[howMany];
        var listOfItems = new List<T>(list);
        for (int i = 0; i < howMany; i++)
        {
            var s = SelectRandomlyFrom(listOfItems.ToArray());
            listOfItems.Remove(s);
            output[i] = s;
        }

        return output;
    }

}