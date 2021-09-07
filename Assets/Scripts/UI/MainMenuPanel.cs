using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : BasePanel
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;
    
    public override void ShowPanel()
    {
        base.ShowPanel();

        //之后用DoTween
        Debug.Log("MainMenu Show");
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;


        //为按钮添加事件
        AddButtonListener_Void(startButton, UIManager.GetInstance.btStartEvent);
        AddButtonListener_Void(optionButton, UIManager.GetInstance.btOpenOptionEvent);
    }
}
