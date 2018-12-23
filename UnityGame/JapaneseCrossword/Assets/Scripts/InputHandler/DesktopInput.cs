using UnityEngine;

public class DesktopInput : InputCheker
{
    public override void Start()
    {
        base.Start();
        IsKnown = true;
    }
    protected override void UpdateBackKeyPress()
    {
        IsBackKeyPressed = Input.GetKeyDown(KeyCode.Escape);
    }

    protected override void UpdateScreenStatus()
    {
        var isDown = Input.GetMouseButtonDown(0);
        var position = Input.mousePosition;
        ScreenStatus.Update(position.x, position.y, isDown);
    }
}
