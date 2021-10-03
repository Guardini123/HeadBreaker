using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelCanvasScript : CanvasScript, ICloseCanvasBtn
{
    public void CloseCanvas()
    {
        CanvasClose();
    }

    public void SelectLevel(int levelNum)
    {
        //Debug.Log("Func SelectLevel invoke!");
        LevelManager.levelManager.LoadLevelByNumber(levelNum);
    }

    public int GetCurrentLevel()
    {
        return LevelManager.levelManager.CurrentLevel();
    }

    public List<Level> GetListOfLevels()
    {
        return LevelManager.levelManager.GetLevelsList();
    }
}
