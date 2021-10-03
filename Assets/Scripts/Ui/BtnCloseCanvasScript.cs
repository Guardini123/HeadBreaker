using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseCanvasScript : BtnScript
{
    [SerializeField] private CanvasScript canvasScript;

    public override void Pressed()
    {
        canvasScript.GetComponent<ICloseCanvasBtn>().CloseCanvas();
    }

}
