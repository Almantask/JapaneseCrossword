using UnityEngine;

public abstract class InputCheker:MonoBehaviour
{
    public bool IsKnown { protected set; get; }
    public bool IsBackKeyPressed { protected set; get; }
    public ScreenStatus ScreenStatus { protected set; get; }

    public virtual void Start()
    {
        ScreenStatus = new ScreenStatus();
    }

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