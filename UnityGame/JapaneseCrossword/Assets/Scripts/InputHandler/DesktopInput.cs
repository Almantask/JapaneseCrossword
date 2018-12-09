using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopInput : GenericInputCheker
{
    public void Start()
    {
        IsKnown = true;
    }
    protected override void UpdateBackKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsBackKeyPressed = true;
        }
    }

    protected override void UpdateScreenStatus()
    {
        var isDown = Input.GetMouseButtonDown(0);
        var position = Input.mousePosition;
        ScreenStatus.Update(position.x, position.y, isDown);
    }
}
