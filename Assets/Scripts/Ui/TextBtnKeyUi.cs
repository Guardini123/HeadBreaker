using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(TMP_Text))]
public class TextBtnKeyUi : MonoBehaviour
{
	[SerializeField] private BtnKeyboardtUi _targetBtn;

    private TMP_Text _textField;


	private void Start()
	{
#if UNITY_EDITOR || UNITY_STANDALONE
		_textField = this.GetComponent<TMP_Text>();
		_textField.text = _targetBtn.KeyToEnable.ToString();
#endif
	}
}
