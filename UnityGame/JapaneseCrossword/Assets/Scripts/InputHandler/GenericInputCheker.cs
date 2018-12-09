using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericInputCheker:MonoBehaviour
{
    public bool IsKnown { protected set; get; }
    public bool IsBackKeyPressed { protected set; get; }
    public ScreenStatus ScreenStatus { protected set; get; }

    void Update()
    {
        InputRoutine();
    }

    protected virtual void InputRoutine()
    {
        UpdateBackKeyPress();
        UpdateScreenStatus();
    }

    protected abstract void UpdateBackKeyPress();
    protected abstract void UpdateScreenStatus();
}