using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class UIManager :Singleton<UIManager>
{
    private Transform uiRootTrans;
    public Dictionary<string, BasePanel> uiPanelPrefabsDic = new Dictionary<string, BasePanel>();
    public Dictionary<string, BasePanel> uiBasePanelsDic = new Dictionary<string, BasePanel>();




    private void Start()
    {
        uiRootTrans = GameObject.FindGameObjectWithTag("UIRoot").transform;
    }

    /// <summary>
    /// 加载panels的预制体
    /// </summary>
    public void LoadUIPanelsFromRes(string _path)
    {
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
            BasePanel spawnPanel = Instantiate(uiPanelPrefabsDic[_panelName]);
            uiBasePanelsDic.Add(_panelName,spawnPanel);
            spawnPanel.transform.SetParent(uiRootTrans);

            spawnPanel.ShowPanel();

            return;
        }

        uiBasePanelsDic[_panelName].ShowPanel();
    }
}
