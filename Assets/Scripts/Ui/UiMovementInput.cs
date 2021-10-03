using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMovementInput : MonoBehaviour
{
    public delegate void MovementButtonAction();
    public event MovementButtonAction upBtnDown;
    public event MovementButtonAction upBtnUp;
    public event MovementButtonAction downBtnDown;
    public event MovementButtonAction downBtnUp;
    public event MovementButtonAction leftBtnDown;
    public event MovementButtonAction leftBtnUp;
    public event MovementButtonAction rightBtnDown;
    public event MovementButtonAction rightBtnUp;

    public static UiMovementInput uiInput { get; private set; }

    private void Awake()
    {
        uiInput = this;    
    }

    public void Start()
    {
        
    }

    public void UpBtnDownAction() => upBtnDown?.Invoke();
    public void DownBtnDownAction() => downBtnDown?.Invoke();
    public void LeftBtnDownAction() => leftBtnDown?.Invoke();
    public void RightBtnDownAction() => rightBtnDown?.Invoke();
    public void UpBtnUpAction() => upBtnUp?.Invoke();
    public void DownBtnUpAction() => downBtnUp?.Invoke();
    public void LeftBtnUpAction() => leftBtnUp?.Invoke();
    public void RightBtnUpAction() => rightBtnUp?.Invoke();
}
