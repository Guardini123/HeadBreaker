using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Text))]
public class StopwatchOutputUi : MonoBehaviour
{
	private TMP_Text _stopwatchText;
	[SerializeField] private Stopwatch _stopwatch;


	private void Awake()
	{
		_stopwatchText = this.gameObject.GetComponent<TMP_Text>();
	}


	private void Update()
	{
		var endTimeSec = _stopwatch.CurrentTimeSeconds;
		var time = TimeSpan.FromSeconds(endTimeSec);
		_stopwatchText.text = time.ToString("mm':'ss':'ff");
	}
}
