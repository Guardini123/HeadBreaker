using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInput : MonoBehaviour
{
    [Header("Keys for desktop.")]
    [Header("This script has public methods for UI input!")]
    [SerializeField] private KeyCode keyPlusDirection;
    [SerializeField] private KeyCode keyMinusDirection;

    [Header("Invert input keys if player want. Need to restart game!")]
    [SerializeField] private bool invertAxis;

    private Player player;

    private void Start()
    {
        player = this.GetComponent<Player>();

        if (invertAxis)
        {
            InvertPlayerInput();
        }

        Vector3 direction = player.GetDirection();
        //подписка на Ui ивенты
        if (direction.z != 0)
        {
            //двигается вверх-вниз
            UiMovementInput.uiInput.downBtnDown += PlayerPressedMinusDirectionDown;
            UiMovementInput.uiInput.downBtnUp += PlayerPressedMinusDirectionUp;
            UiMovementInput.uiInput.upBtnDown += PlayerPressedPlusDirectionDown;
            UiMovementInput.uiInput.upBtnUp += PlayerPressedPlusDirectionUp;
        }
        if (direction.x != 0)
        {
            //двигается вправо-влево
            UiMovementInput.uiInput.leftBtnDown += PlayerPressedMinusDirectionDown;
            UiMovementInput.uiInput.leftBtnUp += PlayerPressedMinusDirectionUp;
            UiMovementInput.uiInput.rightBtnDown += PlayerPressedPlusDirectionDown;
            UiMovementInput.uiInput.rightBtnUp += PlayerPressedPlusDirectionUp;
        }
    }

    public void InvertPlayerInput()
    {
        KeyCode buf = keyPlusDirection;
        keyPlusDirection = keyMinusDirection;
        keyMinusDirection = buf;
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyPlusDirection))
        {
            PlayerPressedPlusDirectionDown();
        }
        if (Input.GetKeyDown(keyMinusDirection))
        {
            PlayerPressedMinusDirectionDown();
        }

        if (Input.GetKeyUp(keyPlusDirection))
        {
            PlayerPressedPlusDirectionUp();
        }
        if (Input.GetKeyUp(keyMinusDirection))
        {
            PlayerPressedMinusDirectionUp();
        }
    }


    //Methods for UI input.

    public void PlayerPressedPlusDirectionDown() => player.PlayerCanMoveInPlusDirection();

    public void PlayerPressedMinusDirectionDown() => player.PlayerCanMoveInMinusDirection();

    public void PlayerPressedPlusDirectionUp() => player.PlayerCantMoveInPlusDirection();

    public void PlayerPressedMinusDirectionUp() => player.PlayerCantMoveInMinusDirection();
}
