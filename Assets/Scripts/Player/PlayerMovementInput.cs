using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInput : MonoBehaviour
{
    [Header("Keys for desktop.")]
    [Header("This script has public methods for UI input!")]
    [SerializeField] private KeyCode keyPlusDirection;
    [SerializeField] private KeyCode keyMinusDirection;

    private Player player;


    private void Start()
    {
        player = this.GetComponent<Player>();
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
