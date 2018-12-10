using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopInput : GenericInputCheker
{
    public override void Start()
    {
        base.Start();
        IsKnown = true;
    }
    protected override void UpdateBackKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc pressed");
            IsBackKeyPressed = true;
        }
        else
        {
            IsBackKeyPressed = false;
        }
    }

    protected override void UpdateScreenStatus()
    {
        var isDown = Input.GetMouseButtonDown(0);
        var position = Input.mousePosition;
        ScreenStatus.Update(position.x, position.y, isDown);
    }
}
