using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameCanvasScript : CanvasScript, IOpenMenuBtn
{
    public override CanvasScript CanvasOn(CanvasScript canvasSwitchOn = null)
    {
        PauseManager.pauseManager.ContinueTime();
        return base.CanvasOn(canvasSwitchOn);
    }

    public void OpenMenu()
    {
        CanvasManager.canvasManager.MenuCanvasOpen();
    }
}