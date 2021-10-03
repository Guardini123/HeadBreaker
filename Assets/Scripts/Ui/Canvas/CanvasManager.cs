using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager canvasManager { get; private set; }

    [SerializeField] private CanvasScript inGameCanvas;
    [SerializeField] private CanvasScript menuCanvas;
    [SerializeField] private CanvasScript winCanvas;
    [SerializeField] private CanvasScript looseCanvas;
    [SerializeField] private CanvasScript selectLevelCanvas;


    [SerializeField] private CanvasScript activeCanvas;

    private void Awake()
    {
        canvasManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EndThisLevelOnTrigger.instance.endLevelByTrigger += WinCanvasOpen;
    }

    public void UpdateActiveCanvas(CanvasScript targetCanvas)
    {
        activeCanvas = targetCanvas;
    }

    public void InGameCanvasOpen()
    {
        activeCanvas.CanvasOff();
        activeCanvas = inGameCanvas.CanvasOn(activeCanvas);
    }

    public void MenuCanvasOpen()
    {
        activeCanvas.CanvasOff();
        activeCanvas = menuCanvas.CanvasOn(activeCanvas);
    }

    public void WinCanvasOpen()
    {
        activeCanvas.CanvasOff();
        activeCanvas = winCanvas.CanvasOn(activeCanvas);
    }

    public void LooseCanvasOpen()
    {
        activeCanvas.CanvasOff();
        activeCanvas = looseCanvas.CanvasOn(activeCanvas);
    }

    public void SelectLevelCanvasOpen()
    {
        activeCanvas.CanvasOff();
        activeCanvas = selectLevelCanvas.CanvasOn(activeCanvas);
    }
}
