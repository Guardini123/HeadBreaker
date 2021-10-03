using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMenuOpenScript : BtnScript
{
    [SerializeField] private CanvasScript canvasScript;
    public override void Pressed()
    {
        canvasScript.GetComponent<IOpenMenuBtn>().OpenMenu();
    }
}
