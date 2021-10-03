using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    [SerializeField] private List<Level> levels = new List<Level>();


    private void Awake()
    {
        levelManager = this;
    }


    public bool IsThisLastLevel()
    {
        return SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCount - 1);
    }


    /// <summary>
    /// Return list of level's.
    /// </summary>
    /// <returns> List of levels. </returns>
    public List<Level> GetLevelsList()
    {
        return levels;
    }

    /// <summary>
    /// Return level from list of levels by index.
    /// </summary>
    /// <param name="num"> Index - level's number in list of levels. </param>
    /// <returns> Level or null, if there is not such level. </returns>
    public Level GetLevelByNumber(int num)
    {
        if((levels.Count - 1) < num)
        {
            return null;
        }
        return levels[num];
    }

    public int CurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadThisLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Load level by nummer in build.
    /// </summary>
    /// <param name="levelNum"> Numer of scene in build. </param>
    public void LoadLevelByNumber(int levelNum)
    {
        Debug.Log("LoadLevel by number!");
        SceneManager.LoadScene(levelNum);
    }
}
