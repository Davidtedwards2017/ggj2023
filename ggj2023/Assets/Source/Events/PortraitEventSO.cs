using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Events/Portrait")]
public class PortraitEventSO : ScriptableObject
{
    public PortraitEvent Event = new PortraitEvent();

    public void Raise(Portrait portrait)
    {
        Event?.Invoke(portrait);
    }
}
    
public class PortraitEvent : UnityEvent<Portrait> { }
    
