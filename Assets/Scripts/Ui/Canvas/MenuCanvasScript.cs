using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasScript : CanvasScript, ISelectLevelBtn, IRestartLevelBtn
{
    [SerializeField] private BtnScript btnContinue;

    public override CanvasScript CanvasOn(CanvasScript canvasSwitchOn = null)
    {
        PauseManager.pauseManager.StopTime();
        return base.CanvasOn(canvasSwitchOn);
    }

    protected override void Start()
    {
        base.Start();
        EndThisLevelOnTrigger.instance.endLevelByTrigger += SetBtnContinueNotInteractable;
    }

    public void ContinueButtonPressed()
    {
        CanvasManager.canvasManager.InGameCanvasOpen();
    }

    public void OpenDeveloperSitePressed()
    {
        Application.OpenURL("https://vk.com/guardini123");
    }

    public bool ChangeAudioState()
    {
        return AudioManager.audioManager.AudioSwitchState();
    }

    public void RestartLevel()
    {
        LevelManager.levelManager.ReloadThisLevel();
    }

    public void SelectLevel()
    {
        CanvasManager.canvasManager.SelectLevelCanvasOpen();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void SetBtnContinueNotInteractable()
    {
        btnContinue.SetUnInteractable();
    }
}
