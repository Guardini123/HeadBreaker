using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// If you want to make your own button, plz, override Pressed method.
/// </summary>
public abstract class BtnScript : MonoBehaviour
{
    [SerializeField] private KeyCode keyToEnable;

    [SerializeField] protected Image targetImage;

    private Button thisBtn;
    private bool interactable;

    private void Awake()
    {
        thisBtn = this.gameObject.GetComponent<Button>();
        interactable = true;
    }

    protected virtual void Start()
    {

    }

    protected void Update()
    {
        if (Input.GetKeyDown(keyToEnable) && interactable)
        {
            Pressed();
        }
    }

    public abstract void Pressed();

    public void SetUnInteractable()
    {
        interactable = false;
        thisBtn.interactable = false;
    }
}
