using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDeveloperSiteOpenScript : BtnScript
{
    [SerializeField] private MenuCanvasScript menuCanvas;

    public override void Pressed()
    {
        menuCanvas.OpenDeveloperSitePressed();
    }
}
