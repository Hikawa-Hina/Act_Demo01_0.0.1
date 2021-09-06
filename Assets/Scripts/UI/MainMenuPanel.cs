using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : BasePanel
{
    [SerializeField] private Button startButton;
    
    public override void ShowPanel()
    {
        base.ShowPanel();

        //之后用DoTween
        Debug.Log("MainMenu Show");
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;


        //为按钮添加事件
        AddButtonListener_Void(startButton, UIManager.GetInstance.btStartEvent);
    }
}
