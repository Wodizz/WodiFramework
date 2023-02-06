using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;


/// <summary>
/// 场景切换模块
/// </summary>
public class ScenesManager : SingleBase<SceneManager>
{
    /// <summary>
    /// 同步切换场景方法
    /// </summary>
    /// <param name="name">场景名</param>
    /// <param name="callback">回调</param>
    public void LoadScene(string name, Action callback)
    {
        // 场景同步加载
        SceneManager.LoadScene(name);
        // 加载完成后才会执行
        callback();
    }

    /// <summary>
    /// 异步切换场景方法
    /// </summary>
    /// <param name="name">场景名</param>
    /// <param name="callback">回调</param>
    public void LoadSceneAsyn(string name, Action callback)
    {
        Main.MainMono.StartCoroutine(LoadSceneAsynByCoroutine(name, callback));
    }


    private IEnumerator LoadSceneAsynByCoroutine(string name, Action callback)
    {
        // AsyncOperation异步操作协同程序类
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            // 触发进度条事件
            
            // 如果没完成 返回进度值
            yield return ao.progress;
        }
        yield return null;
        callback();
    }

    
}
