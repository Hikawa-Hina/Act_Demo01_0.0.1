using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePanel : MonoBehaviour
{
    private void Start()
    {
        //初始化 ，如位置等信息
    }

    public virtual void ShowPanel()
    {
        gameObject.SetActive(true);
    }
    public virtual void HidePanel()
    {
        gameObject.SetActive(false);
    }


    /// <summary>
    /// 为当前面板中的按钮添加事件回调
    /// </summary>
    /// <param name="_button"></param>
    /// <param name="_voidEventChannel">事件中介对象</param>
    protected void AddButtonListener_Void(Button _button, VoidEventChannel _voidEventChannel)
    {
        if (_button != null)
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(_voidEventChannel.EventRaise);
            Debug.Log("添加了事件回调");
        }
    }
}
