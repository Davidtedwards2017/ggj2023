using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Simple")]
public class SimpleEventSO : ScriptableObject
{
    public UnityEvent Event = new UnityEvent();

    public void Raise()
    {
        Event?.Invoke();
    }
}
