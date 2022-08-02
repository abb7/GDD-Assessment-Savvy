using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JsonHelper : MonoBehaviour
{

    //Usage:
    //YouObject[] objects = JsonHelper.getJsonArray<YouObject> (jsonString);
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }
    //Usage:
    //string jsonString = JsonHelper.arrayToJson<YouObject>(objects);
    public static string arrayToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.array = array;
        return JsonUtility.ToJson(wrapper);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

    public static T[] FromJson<T>(string json)
    {
        Wrappers<T> wrapper = JsonUtility.FromJson<Wrappers<T>>(json);
        return wrapper.Item;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrappers<T> wrapper = new Wrappers<T>();
        wrapper.Item = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrappers<T> wrapper = new Wrappers<T>();
        wrapper.Item = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrappers<T>
    {
        public T[] Item;
    }
}
