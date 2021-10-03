using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnMovementInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]private BtnType buttonType;

    private enum BtnType
    {
        Up,
        Down,
        Left,
        Right
    }

    public void OnPointerDown(PointerEventData eventData) => PointerAction(true);

    public void OnPointerUp(PointerEventData eventData) => PointerAction(false);

    private void PointerAction(bool down)
    {
        switch (buttonType)
        {
            case BtnType.Up:
                if (down) { 
                    UiMovementInput.uiInput.UpBtnDownAction(); 
                } else {
                    UiMovementInput.uiInput.UpBtnUpAction();
                }
                break;
            case BtnType.Down:
                if (down) {
                    UiMovementInput.uiInput.DownBtnDownAction();
                } else {
                    UiMovementInput.uiInput.DownBtnUpAction();
                }
                break;
            case BtnType.Left:
                if (down) {
                    UiMovementInput.uiInput.LeftBtnDownAction();
                } else {
                    UiMovementInput.uiInput.LeftBtnUpAction();
                }
                break;
            case BtnType.Right:
                if (down) {
                    UiMovementInput.uiInput.RightBtnDownAction();
                } else {
                    UiMovementInput.uiInput.RightBtnUpAction();
                }
                break;
            default:
                break;
        }
    }
}
