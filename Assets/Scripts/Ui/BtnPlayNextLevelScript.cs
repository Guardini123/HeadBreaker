using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPlayNextLevelScript : BtnScript
{
    [SerializeField] private WinLevelCanvasScript winLevelCanvas;

    public override void Pressed()
    {
        winLevelCanvas.PlayNextLevel();
    }
}
