using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有窗口的父类 提供封装的生命周期函数
/// </summary>
public abstract class UIBase : MonoBehaviour 
{
	public E_WindowType WindowType { get; set; }

	#region 生命周期函数
	public abstract void FindUI();

	public abstract void OnShow();

	public abstract void OnHide();

	public abstract void AddEvent();

	public abstract void DelEvent();

	#endregion

	/// <summary>
	/// 因为有些窗口不需要添加帧更新 避免性能损耗
	/// </summary>
	public virtual void OnUpdate()
    {

    }

}
