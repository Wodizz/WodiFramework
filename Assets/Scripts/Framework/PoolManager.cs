using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 任意对象的对象池
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObejctPool<T> where T : class
{
    private Queue<T> poolQuene;

    private GameObject poolNode;

    /// <summary>
    /// 根据容量创建对象池
    /// </summary>
    /// <param name="capacity">容量</param>
    public ObejctPool(int capacity)
    {
        poolQuene = new Queue<T>(capacity);
    }

    /// <summary>
    /// 根据节点创建对象池
    /// </summary>
    /// <param name="poolNode">节点名</param>
    public ObejctPool(string poolNode)
    {
        poolQuene = new Queue<T>();
        this.poolNode = new GameObject(poolNode);
        GameObject.DontDestroyOnLoad(this.poolNode);
    }

    public void Recyle(T obj)
    {
        if (obj is MonoBehaviour)
        {
            (obj as MonoBehaviour).transform.SetParent(poolNode.transform);
            (obj as MonoBehaviour).gameObject.SetActive(false);
        }
        poolQuene.Enqueue(obj);
    }

    public T TryGet()
    {
        T getObj = null;
        if (poolQuene.Count > 0)
        {
            getObj = poolQuene.Dequeue();
            if (getObj is MonoBehaviour)
                (getObj as MonoBehaviour).gameObject.SetActive(true);
        }
        return getObj;
    }

    public void Clear()
    {
        poolQuene.Clear();
        for (int i = 0; i < poolNode.transform.childCount; i++)
        {
            MonoBehaviour.Destroy(poolNode.transform.GetChild(i).gameObject);
        }
        MonoBehaviour.Destroy(poolNode.gameObject);
    }
}
