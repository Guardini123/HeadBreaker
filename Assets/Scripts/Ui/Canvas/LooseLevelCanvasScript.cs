using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseLevelCanvasScript : CanvasScript, ISelectLevelBtn, IRestartLevelBtn
{
    public void RestartLevel()
    {
        LevelManager.levelManager.ReloadThisLevel();
    }

    public void SelectLevel()
    {
        CanvasManager.canvasManager.SelectLevelCanvasOpen();
    }
}
