using System;
using System.Collections.Generic;

namespace TCASharpSample;

public static class CollectionHelpers
{
    public static List<T> RemoveAt<T>(this List<T> list, int index)
    {
        if (index < 0 || index >= list.Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        var newList = new List<T>(list);
        newList.RemoveAt(index);
        return newList;
    }

    public static T[] RemovingIndexes<T>(this T[] array, HashSet<int> indexes)
    {
        var newList = new List<T>();
        for (int i = 0; i < array.Length; i++)
        {
            if (!indexes.Contains(i))
                newList.Add(array[i]);
        }
        return newList.ToArray();
    }

    public static List<T> RemovingIndexes<T>(this List<T> list, HashSet<int> indexes)
    {
        var newList = new List<T>();
        for (int i = 0; i < list.Count; i++)
        {
            if (!indexes.Contains(i))
                newList.Add(list[i]);
        }
        return newList;
    }
}