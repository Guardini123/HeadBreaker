using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stopwatch : MonoBehaviour
{
	public UnityEvent OnStopwatchStop;


	public float ResultTimeSeconds { get; private set; } = 0.0f;


    public bool Started { get; private set; } = false;


    public float CurrentTimeSeconds { get; private set; } = 0.0f;


    public void StartStopwatch()
	{
        CurrentTimeSeconds = 0.0f;
        ResultTimeSeconds = 0.0f;
        Started = true;
	}


    public void ContinueStopwatch()
	{
        Started = true;
	}


	public void StopStopwatch()
	{
		Started = false;
		ResultTimeSeconds = CurrentTimeSeconds;
		OnStopwatchStop?.Invoke();
	}


	public void ResetStopwatch()
	{
		CurrentTimeSeconds = 0.0f;
		ResultTimeSeconds = 0.0f;
	}


	private void Update()
	{
		if (Started)
		{
			CurrentTimeSeconds += Time.deltaTime;
		}
	}
}
