using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevelCanvasScript : CanvasScript, ISelectLevelBtn, IOpenMenuBtn
{
    public override CanvasScript CanvasOn(CanvasScript canvasSwitchOn = null)
    {
        PauseManager.pauseManager.StopTime();
        return base.CanvasOn(canvasSwitchOn);
    }

    [SerializeField] private GameObject[] objectsToDisableOnLastLevel;
    [SerializeField] private GameObject[] objectsToEnableOnLastLevel;

    protected override void Start()
    {
        base.Start();
        if (LevelManager.levelManager.IsThisLastLevel())
        {
            ChangeStateOfObjectsOnLastLevel();
        }
    }


    private void ChangeStateOfObjectsOnLastLevel()
    {
        foreach(var obj in objectsToDisableOnLastLevel)
        {
            obj.SetActive(false);
        }
        foreach(var obj in objectsToEnableOnLastLevel)
        {
            obj.SetActive(true);
        }
    }

    public void PlayNextLevel()
    {
        LevelManager.levelManager.LoadNextLevel();
    }

    public void SelectLevel()
    {
        CanvasManager.canvasManager.SelectLevelCanvasOpen();
    }

    public void OpenMenu()
    {
        CanvasManager.canvasManager.MenuCanvasOpen();
    }
}
