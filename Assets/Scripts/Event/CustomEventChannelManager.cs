using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class CustomEventChannelManager : Singleton<CustomEventChannelManager>
{

    /// <summary>
    /// 加载指定的voidEventChannel
    /// </summary>
    ///  <param name="_channelName">事件中介在res/Events之后的路径</param>
    public VoidEventChannel LoadVoidEvent(string _channelName)
    {
        VoidEventChannel voidEventChannel = Resources.Load<VoidEventChannel>("Events/" + _channelName);

        return voidEventChannel;
    }
}
