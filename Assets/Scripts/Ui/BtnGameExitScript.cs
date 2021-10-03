using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnGameExitScript : BtnScript
{
    [SerializeField] private MenuCanvasScript menuCanvas;

    public override void Pressed()
    {
        menuCanvas.ExitGame();
    }
}
