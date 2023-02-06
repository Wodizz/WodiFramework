using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 继承mono的单例
/// </summary>
public class SingleAutoMono<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // 如果是空
            if (instance == null)
            {
                GameObject obj = new GameObject();
                // 设置这个对象为脚本名
                obj.name = typeof(T).Name;
                // 因为单例模式对象往往不移除 存在整个生命周期中
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<T>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
