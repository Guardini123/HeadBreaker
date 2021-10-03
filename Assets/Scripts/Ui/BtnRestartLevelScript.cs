using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRestartLevelScript : BtnScript
{
    [SerializeField] private CanvasScript canvasScript;

    public override void Pressed()
    {
        canvasScript.GetComponent<IRestartLevelBtn>().RestartLevel();
    }
}
