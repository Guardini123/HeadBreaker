using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BtnPressSupportUi : MonoBehaviour
{
	[SerializeField] private bool _pressed = false;
	public bool Pressed => _pressed;


	public UnityEvent OnPress;


	private void OnEnable()
	{
		_pressed = false;
	}


	public void PressBtn(bool press)
	{
		_pressed = press;
	}


	private void Update()
	{
		if (Pressed) OnPress?.Invoke();
	}
}
