using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : BasePanel
{
    [SerializeField] private Button returnMainButton;

    //设置的一些toggle

    //



    public override void ShowPanel()
    {
        base.ShowPanel();

        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

        AddButtonListener_Void(returnMainButton, UIManager.GetInstance.btReturnMainEvent);
    }

}
