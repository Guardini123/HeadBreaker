using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private List<Level> _levels = new List<Level>();

    [SerializeField] private int _currentLevelIndex = 0;
    public int CurrentLevelIndex => _currentLevelIndex;
    [SerializeField] private GameObject _currentLevelInstance;

    public UnityEvent OnLevelFinished;


    [SerializeField] private string _keyForCurrentLevelToSave;



    private void Awake()
    {
        Instance = this;
    }


	private void Start()
	{
        var error = "";
        if(!SaverLoaderLocal.Instance.TryLoadInt(_keyForCurrentLevelToSave, out _currentLevelIndex, out error))
		{
            _currentLevelIndex = 0;
            SaverLoaderLocal.Instance.SaveInt(_currentLevelIndex, _keyForCurrentLevelToSave);
        }

        LoadLevel(_currentLevelIndex);
        PauseCurrentLevel(true);
	}


    private void LoadLevel(int levelIndex)
	{
        GameObject.Destroy(_currentLevelInstance.gameObject);
        var go = GameObject.Instantiate(_levels[levelIndex].gameObject, Vector3.zero, Quaternion.identity);
        _currentLevelIndex = levelIndex;
        SaverLoaderLocal.Instance.SaveInt(_currentLevelIndex, _keyForCurrentLevelToSave);
        _currentLevelInstance = go;
		GameInputUi.Instance.SetUpUiInput(_currentLevelInstance.GetComponent<Level>().Players);
	}





	public bool IsThisLastLevel()
    {
        return _currentLevelIndex == (_levels.Count - 1);
    }


    public List<Level> GetLevelsDataList()
    {
        return _levels;
    }


    public Level GetLevelDataByIndex(int num)
    {
        if((_levels.Count - 1) < num)
        {
            return null;
        }
        return _levels[num];
    }


    public GameObject GetCurrentLevel()
    {
        return _currentLevelInstance;
    }


    public Level GetCurrentLevelData()
    {
        return _levels[_currentLevelIndex];
    }




    public void LoadLevelByIndex(int index)
	{
        LoadLevel(index);
	}


    public void LoadNextLevel()
    {
        LoadLevel(_currentLevelIndex+1);
    }


    public void ReloadThisLevel()
    {
        LoadLevel(_currentLevelIndex);
    }


    public void FinishLevel()
	{
        // сохранить время прохождения
        OnLevelFinished?.Invoke();
	}


    public void PauseCurrentLevel(bool pause)
    {
        foreach (var player in _currentLevelInstance.GetComponent<Level>().Players)
        {
            player.enabled = !pause;
        }
    }
}
