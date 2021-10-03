using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName ="Level")]
public class Level : ScriptableObject
{
    [SerializeField] private string levelName;
    [SerializeField] private string levelDescription;
    [SerializeField] private Sprite levelPic;

    

    /// <summary>
    /// Return level's name.
    /// </summary>
    /// <returns> Level's name. </returns>
    public string GetLevelName()
    {
        return levelName;
    }


    /// <summary>
    /// Return level's description. 
    /// </summary>
    /// <returns> Level's description. </returns>
    public string GetLevelDescription()
    {
        return levelDescription;
    }


    /// <summary>
    /// Return picture of level.
    /// </summary>
    /// <returns> Level's picture. </returns>
    public Sprite GetLevelPic()
    {
        return levelPic;
    }
}
