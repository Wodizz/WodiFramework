using System;
using UnityEngine;
using UnityEngine.UI;

/*
 * 组件扩展方法工具
 * 所有的扩展方法放入此类中存放
 * 目前包含 添加/删除动画帧事件，添加/去除图片置灰
 */

public static class ExtendFunction
{
    /// <summary>
    /// 添加指定动画的帧事件
    /// </summary>
    /// <param name="animator">本身</param>
    /// <param name="clipName">动画名字</param>
    /// <param name="function">绑定事件</param>
    /// <param name="frame">绑定时间</param>
    public static void AddAnimEvent(this Animator animator, string clipName, Action function, float timer = -1)
    {
        if(animator != null) {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++) {
                if (string.Equals(clips[i].name, clipName)) {
                    if (clips[i].events.Length > 0) return;
                    AnimationEvent events = new AnimationEvent {
                        functionName = function.Method.Name,
                        time = timer == -1 ? clips[i].length : timer > clips[i].length ? clips[i].length : timer
                    };
                    clips[i].AddEvent(events);
                }
            }
            animator.Rebind();
        }
    }

    /// <summary>
    /// 清除所有事件
    /// </summary>
    public static void CleanAllEvent(this Animator animator)
     {
        if (animator != null) {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++) {
                clips[i].events = default(AnimationEvent[]);
            }
        }
     }

    /// <summary>
    /// 得到随机数种子
    /// </summary>
    /// <returns></returns>
    static int GetRandomSeedbyGuid()
    {
        byte[] buffer = Guid.NewGuid().ToByteArray();

        return BitConverter.ToInt32(buffer, 0);
    }

    public static bool IsRandomInInterval(int interval, int max, int min = 0)
    {
        int getValue = 0;
        int getValueIndex = max / 2;

        System.Random random = new System.Random(GetRandomSeedbyGuid());

        for (int i = 0; i < max; i++)
        {
            if (i == getValueIndex)
            {
                getValue = random.Next(min, max);
            }
        }

        return getValue <= interval;
    }

    public static int GetRandomValue(int max, int min = 0, int index = 2)
    {
        int getValue = 0;
        int getValueIndex = max / index;

        System.Random random = new System.Random(GetRandomSeedbyGuid());

        for (int i = 0; i < max; i++)
        {
            if (i == getValueIndex)
            {
                getValue = random.Next(min, max);
            }
        }

        return getValue;
    }
}
