using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        UIManager.GetInstance.LoadUIPanelsFromRes(Application.streamingAssetsPath + "/XML/UIPanelConfig.xml");
        UIManager.GetInstance.ShowPanel_Designative("MainMenuPanel");
    }
}
