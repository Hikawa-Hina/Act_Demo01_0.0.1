using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 适用于不同类型的单例
/// </summary>
/// <typeparam name="T">需要设计成单例模式的子类对象</typeparam>

public class UnitySingleton<T> : MonoBehaviour where T:Component
{
    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if(_instance==null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;

                if(_instance==null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
}
