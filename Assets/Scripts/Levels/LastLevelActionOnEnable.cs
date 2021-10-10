using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LastLevelActionOnEnable : MonoBehaviour
{
    public UnityEvent OnThisIsLastLevel;
	public UnityEvent OnThisIsNotLastLevel;


	private void OnEnable()
	{
		if (LevelManager.Instance.IsThisLastLevel()) OnThisIsLastLevel?.Invoke();
		else OnThisIsNotLastLevel?.Invoke();
	}
}
