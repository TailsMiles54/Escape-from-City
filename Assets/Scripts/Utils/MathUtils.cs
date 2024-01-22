using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

[Serializable]
public class FloatRange
{
    public float Min;
    public float Max;

    public float GetRandom() => Random.Range(Min, Max);
}

[Serializable]
public class Range
{
    public int Min;
    public int Max;

    public int GetRandom() => Random.Range(Min, Max);
}

public static class CollectionUtils
{
    public static TSource GetRandomElement<TSource>(this IEnumerable<TSource> collection)
    {
        var idx = Random.Range(0, collection.Count());
        return collection.Where((x, i) => i == idx).First();
    }

    public static List<T> GetRandomElements<T>(this IEnumerable<T> collection, int count)
    {
        var result = new List<T>();
        var collectionTemp = collection.ToList();
        for (int i = 0; i < count; i++)
        {
            var randomIndex = Random.Range(0, collectionTemp.Count);
            result.Add(collectionTemp[randomIndex]);
            collectionTemp.RemoveAt(randomIndex);
        }

        return result;
    }

}
