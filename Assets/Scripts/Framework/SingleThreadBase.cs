using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// 多线程单例基类
/// </summary>
public class SingleThreadBase<T> where T : new()
{
    private static T instance;
    private static readonly object locker = new object();

    public static T Instance
    {
        get
        {
            // 双检锁
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new T();
                }
            }
            return instance;
        }
    }
}
