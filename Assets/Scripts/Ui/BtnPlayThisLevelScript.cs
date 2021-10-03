using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPlayThisLevelScript : BtnScript
{
    [SerializeField] private SelectLevelCanvasScript selectLevelCanvas;
    [SerializeField] private SnapScrolling snapScrollingLevels;

    public override void Pressed()
    {
        selectLevelCanvas.SelectLevel(snapScrollingLevels.GetCurrentId());
    }
}
