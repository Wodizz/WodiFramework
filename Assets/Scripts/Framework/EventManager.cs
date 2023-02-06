using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
 * 事件管理器(EventManager)
 * 管理工程内全部事件的添加、删除与派发
 */

public class EventManager
{
    public static List<IEventInfo> event_List = new List<IEventInfo>();


    /// <summary>
    /// 清空事件数据
    /// </summary>
    public static void ClearEventManager()
    {
        for (int i = 0; i < event_List.Count; i++)
        {
            event_List[i] = null;
        }
        event_List.Clear();
    }

    #region 示例事件注册

    public static EventInfo sham_Event = new EventInfo();

    #endregion


    /// <summary>
    /// 全局事件添加
    /// </summary>
    public static void InitEventManager()
    {
        
    }
}

public delegate void OnValueChanged();
public delegate void OnValueChanged<T>(T arg1);
public delegate void OnValueChanged<T, K>(T arg1, K arg2);
public delegate void OnValueChanged<T, K, J>(T arg1, K arg2, J arg3);


/// <summary>
/// 泛型与非泛型事件继承接口 方便管理
/// </summary>
public interface IEventInfo
{

}

public class EventInfo : IEventInfo
{
    OnValueChanged _action;

    public EventInfo()
    {
        EventManager.event_List.Add(this);
    }

    public void InvokeEvent()
    {
        if (_action != null)
        {
            _action.Invoke();
        }
    }

    public void AddMonitor(OnValueChanged action)
    {
        if (action != null)
        {
            this._action += action;
        }
        
    }

    public void DelMonitor(OnValueChanged action)
    {
        if (action != null)
        {
            this._action -= action;
        }
    }
}

public class EventInfo<T> : IEventInfo
{
    OnValueChanged<T> _action;

    public EventInfo()
    {
        EventManager.event_List.Add(this);
    }

    public void InvokeEvent(T arg)
    {
        if (_action != null)
        {
            _action(arg);
        }
    }

    public void AddMonitor(OnValueChanged<T> action)
    {
        if (action != null)
        {
            this._action += action;
        }
    }

    public void DelMonitor(OnValueChanged<T> action)
    {
        if (action != null)
        {
            this._action -= action;
        }
    }
}

public class EventInfo<T,K> : IEventInfo
{
    OnValueChanged<T,K> _action;

    public EventInfo()
    {
        EventManager.event_List.Add(this);
    }

    public void InvokeEvent(T arg1, K arg2)
    {
        if (_action != null)
        {
            _action(arg1, arg2);
        }
    }

    public void AddMonitor(OnValueChanged<T, K> action)
    {
        if (action != null)
        {
            this._action += action;
        }
    }

    public void DelMonitor(OnValueChanged<T, K> action)
    {
        if (action != null)
        {
            this._action -= action;
        }
    }
}

public class EventInfo<T, K, J> : IEventInfo
{
    OnValueChanged<T, K, J> _action;

    public EventInfo()
    {
        EventManager.event_List.Add(this);
    }

    public void InvokeEvent(T arg1, K arg2, J arg3)
    {
        if (_action != null)
        {
            _action(arg1, arg2, arg3);
        }
    }

    public void AddMonitor(OnValueChanged<T, K, J> action)
    {
        if (action != null)
        {
            this._action += action;
        }
    }

    public void DelMonitor(OnValueChanged<T, K, J> action)
    {
        if (action != null)
        {
            this._action -= action;
        }
    }
}
