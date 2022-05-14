using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pooling<T> where T : MonoBehaviour
{
    private Queue<T> list = new Queue<T>();
    private T _template;

    public Pooling(T templat)
    {
        _template = templat;
    }

    public T GetObject()
    {
        if (list.Count <= 0)
            return Object.Instantiate(_template);
        return list.Dequeue();
    }

    public void Return(T ret)
    {
        list.Enqueue(ret);
    }
}
