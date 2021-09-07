using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScenesPanel : BasePanel
{
    [SerializeField] private Button returnMainButton;
    [SerializeField] private Button btSaveFile01;
    [SerializeField] private Button btSaveFile02;
    [SerializeField] private Button btSaveFile03;

    public override void ShowPanel()
    {
        base.ShowPanel();

        //之后用DoTween
        Debug.Log("SaveScenes Show");
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

        AddButtonListener_Void(returnMainButton, UIManager.GetInstance.btReturnMainEvent);

        AddButtonListener_Void(btSaveFile01, UIManager.GetInstance.btScenesListEvent);
        AddButtonListener_Void(btSaveFile02, UIManager.GetInstance.btScenesListEvent);
        AddButtonListener_Void(btSaveFile03, UIManager.GetInstance.btScenesListEvent);
    }
}
