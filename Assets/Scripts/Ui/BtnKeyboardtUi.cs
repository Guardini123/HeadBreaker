using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class BtnKeyboardtUi : MonoBehaviour
{
    [SerializeField] private KeyCode _keyToEnable;
    public KeyCode KeyToEnable => _keyToEnable;


    private Button _thisBtn;
    private bool _interactable;

    public UnityEvent OnPressed;


    private void Awake()
    {
        _thisBtn = this.gameObject.GetComponent<Button>();
        _interactable = true;
    }


	private void Start()
	{
        _thisBtn.onClick.AddListener(Pressed);
	}


	void Update()
    {
        if (Input.GetKeyDown(_keyToEnable) && _interactable)
        {
            Pressed();
        }
    }


    public void SetInteractableOrNot(bool canInteract)
    {
        _interactable = canInteract;
        _thisBtn.interactable = canInteract;
    }


    public void Pressed()
	{
        OnPressed?.Invoke();
    }
}
