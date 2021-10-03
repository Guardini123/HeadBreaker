using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnChangeAudioStateScript : BtnScript
{
    [SerializeField] private bool audioOn;
    [SerializeField] private MenuCanvasScript menuCanvas;
    [SerializeField] private Sprite audioOnSprite;
    [SerializeField] private Sprite audioOffSprite;
    

    // Start is called before the first frame update
    protected override void Start()
    {
        //delete this in future
        audioOn = true;
        //read settings about sound from saved-presset
        SetTargetImage();
    }

    public override void Pressed()
    {
        audioOn = menuCanvas.ChangeAudioState();
        SetTargetImage();
    }

    private void SetTargetImage()
    {
        targetImage.sprite = audioOn ? audioOnSprite : audioOffSprite;
    }
}
