using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DictionaryExtension
{
    public static KeyValuePair<T, G> GetRandomItem<T, G>(this Dictionary<T, G> dictionary)
    {
        if (dictionary == null || dictionary.Count == 0) return default(KeyValuePair<T,G>);
        int randomNum = Random.Range(0, dictionary.Count - 1);
        return dictionary.ElementAt(randomNum);
    }
}
