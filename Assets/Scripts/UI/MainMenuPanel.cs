using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : BasePanel
{
    public override void ShowPanel()
    {
        base.ShowPanel();

        //之后用DoTween
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
}
