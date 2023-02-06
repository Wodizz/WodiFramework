using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏主入口
/// </summary>
public class Main : MonoBehaviour 
{
	public static E_Scene CurScene;
	public static GameObject MainObject;
	public static Main MainMono;
	public static OnValueChanged OnGameUpdate;
	public static OnValueChanged OnGameFixedUpdate;
	public static OnValueChanged OnGameQuit;

	#region 生命周期函数

	private void Awake()
	{
		// 用于供外部使用
		MainObject = gameObject;
		CurScene = E_Scene.Start;
		// 管理器初始化
		Init();
	}

	private void Start()
    {
		// 打开开始界面
		UIManager.CreateWindow<StartWindow>(E_WindowType.Base);
    }

	private void Update()
	{
		if (OnGameFixedUpdate != null)
			OnGameFixedUpdate.Invoke();
	}

	private void FixedUpdate()
	{
		if (OnGameFixedUpdate != null)
			OnGameFixedUpdate.Invoke();
	}

	private void OnApplicationPause()
	{

	}

	private void OnApplicationQuit()
	{
		if (OnGameQuit != null)
			OnGameQuit.Invoke();
	}

	#endregion

	public void Init()
    {
		MainObject.SetActive(true);
		DontDestroyOnLoad(MainObject);
		// UI管理器初始化
		UIManager.Init();
		// 事件中心初始化
		EventManager.InitEventManager();
	}


	public void Clear()
    {
		UIManager.Clear();
		EventManager.ClearEventManager();
	}
}

/// <summary>
/// 可修改场景枚举
/// </summary>
public enum E_Scene
{
	Start,
	Main,
	Game,
}
