using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="VoidEventChannel",menuName ="CustomEvent/UI/VoidEventChannel")]
public class VoidEventChannel : ScriptableObject
{
    public UnityAction OnEventRaised = delegate { };

    public void EventRaise()
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke();
    }
}
