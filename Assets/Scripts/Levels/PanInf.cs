using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanInf : MonoBehaviour
{
    [SerializeField] private Image targetImage;
    [SerializeField] private Text targetText;
    [SerializeField] private Text targetHighScore;

    public void SetSpriteOnImage(Sprite sprite)
    {
        targetImage.sprite = sprite;
    }

    public void SetTextOnPan(string text)
    {
        targetText.text = text;
    }

    public void SetHighScoreOnPan(string highScore)
    {
        targetHighScore.text = highScore;
    }
}
