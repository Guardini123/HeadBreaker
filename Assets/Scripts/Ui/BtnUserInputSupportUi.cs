using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BtnUserInputSupportUi : MonoBehaviour
{
	[SerializeField] private bool _pressed = false;
	public bool Pressed => _pressed;


	public UnityEvent OnPress;


	public void PressOrNotButton(bool press)
	{
		_pressed = press;
	}


	private void Update()
	{
		if (Pressed) OnPress?.Invoke();
	}
}
