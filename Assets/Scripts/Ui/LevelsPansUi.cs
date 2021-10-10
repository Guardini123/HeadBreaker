using System.Collections;
using UnityEngine;


public class LevelsPansUi : MonoBehaviour
{
	[SerializeField] private SnapScrolling _pansController;


	private void Start()
	{
		var levels = LevelManager.Instance.GetLevelsDataList();

		_pansController.InitPansWithCount(levels.Count);

		for(int i = 0; i < levels.Count; i++)
		{
			_pansController.SetInfOnPan(i, levels[i].Pic, levels[i].Name);
		}
	}


	private void OnEnable()
	{
		if (!_pansController.WasInited)
		{
			_pansController.OnPansCreated.AddListener(() =>
			{
				_pansController.InitSnapFromNotFirst(LevelManager.Instance.CurrentLevelIndex);
			});
		}
		else
		{
			_pansController.InitSnapFromNotFirst(LevelManager.Instance.CurrentLevelIndex);
		}
	}


	public void PlaySelectedLevel()
	{
		LevelManager.Instance.LoadLevelByIndex(_pansController.SelectedPanId);
	}



}