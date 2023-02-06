using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 单例基类
/// </summary>
public class SingleBase<T> where T : new()
{
    private static T instance;

    public static T Instance 
    { 
        get 
        {
            if (instance == null)
                instance = new T();
            return instance; 
        } 
    }

}
