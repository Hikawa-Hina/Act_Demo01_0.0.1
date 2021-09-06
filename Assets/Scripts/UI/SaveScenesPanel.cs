using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScenesPanel : BasePanel
{
    [SerializeField] private Button returnMainButton;

    public override void ShowPanel()
    {
        base.ShowPanel();

        //之后用DoTween
        Debug.Log("SaveScenes Show");
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

        AddButtonListener_Void(returnMainButton, UIManager.GetInstance.btReturnMainEvent);
    }
}
