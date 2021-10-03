using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnChooseLevelScript : BtnScript
{
    [SerializeField] private CanvasScript canvasScript;

    public override void Pressed()
    {
        canvasScript.GetComponent<ISelectLevelBtn>().SelectLevel();
    }
}
