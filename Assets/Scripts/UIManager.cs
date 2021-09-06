using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class UIManager :Singleton<UIManager>
{
    private Transform uiRootTrans;
    public Dictionary<string, BasePanel> uiPanelPrefabsDic = new Dictionary<string, BasePanel>();
    public Dictionary<string, BasePanel> uiBasePanelsDic = new Dictionary<string, BasePanel>();


    [Header("Custom Events")]
    [DisplayOnly] public VoidEventChannel btStartEvent;
    [DisplayOnly] public VoidEventChannel btReturnMainEvent;

    private void Start()
    {
        InitEventChannel();
    }


    public void InitEventChannel()
    {
        //之后的事件初始化都是这个步骤
        //添加引用&&添加回调
        btStartEvent = CustomEventChannelManager.GetInstance.LoadVoidEvent("Button/BtStartEvent");
        btStartEvent.OnEventRaised += OnShowSceneList;

        btReturnMainEvent = CustomEventChannelManager.GetInstance.LoadVoidEvent("Button/BtReturnMainEvent");
        btReturnMainEvent.OnEventRaised += OnReturnMainMenu;


        //游戏开始时的初始化界面
        LoadUIPanelsFromRes(Application.streamingAssetsPath + "/XML/UIPanelConfig.xml");
        ShowPanel_Designative("MainMenuPanel");
    }

    private void OnDisable()
    {
        btStartEvent.OnEventRaised -= OnShowSceneList;
        btStartEvent.OnEventRaised -= OnReturnMainMenu;
    }


    /// <summary>
    /// 加载panels的预制体
    /// </summary>
    public void LoadUIPanelsFromRes(string _path)
    {
        uiRootTrans = GameObject.FindGameObjectWithTag("UIRoot").transform;

        XmlDocument xml_Panels = new XmlDocument();

        xml_Panels.Load(_path);

        XmlElement uiRoot = xml_Panels.SelectSingleNode("UIRoot") as XmlElement;

        foreach(XmlElement childNode in uiRoot.ChildNodes)
        {
            string panelName = childNode.GetAttribute("name");
            string panelPath = childNode.GetAttribute("prefabPath");

            uiPanelPrefabsDic.Add(panelName, Resources.Load<BasePanel>(panelPath));
        }

        //DEBUG---
        foreach(var name in uiPanelPrefabsDic.Values)
        {
            Debug.Log(name);
        }
        //--------
    }


    /// <summary>
    /// 查找指定的Panel面板
    /// </summary>
    /// <param name="_panelName">在集合中的key值</param>
    public void ShowPanel_Designative(string _panelName)
    {
        //查看panels缓存中是否有指定的panel,没有则从预制体容器中加载并加入到panels缓存中，否则直接加载
        if(!uiBasePanelsDic.ContainsKey(_panelName))
        {
            //若预制体容器中也没有，抛出异常
            if(!uiPanelPrefabsDic.ContainsKey(_panelName))
            {
                throw new KeyNotFoundException();
            }

            //从预制体中生成指定panel
            BasePanel spawnPanel = Instantiate(uiPanelPrefabsDic[_panelName],uiRootTrans);
            uiBasePanelsDic.Add(_panelName,spawnPanel);

            spawnPanel.ShowPanel();
            return;
        }

        uiBasePanelsDic[_panelName].ShowPanel();
    }

    /// <summary>
    /// 关闭所有的窗口
    /// </summary>
    public void HideAllPanel()
    {
        if(uiBasePanelsDic.Count>0)
        {
            foreach(BasePanel panel in uiBasePanelsDic.Values)
            {
                panel.HidePanel();
                Debug.Log("已关闭所有panel");
            }
        }
    }



    //-----------------------------------------VOID EVENT CALLBACK-----------------------------------------------

    private void OnShowSceneList()
    {
        HideAllPanel();
        ShowPanel_Designative("SaveScenesPanel");
    }

    private void OnReturnMainMenu()
    {
        HideAllPanel();
        ShowPanel_Designative("MainMenuPanel");
    }

    //-----------------------------------------------------------------------------------------------------------
}
