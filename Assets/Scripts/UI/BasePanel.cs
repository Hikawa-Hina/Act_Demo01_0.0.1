using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
