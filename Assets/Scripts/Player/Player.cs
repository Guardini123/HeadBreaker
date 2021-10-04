using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Need to set only one axis!")]
    [SerializeField] private Vector3 speedInDirection;

    public bool canMoveInMinusDirection { get; private set; }
    public bool canMoveInPlusDirection { get; private set; }

    public bool canMove { get; private set; }

    public Rigidbody rb { get; private set; }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        canMoveInPlusDirection = false;
        canMoveInMinusDirection = false;

        PauseManager.pauseManager.pause += SetCanMove;
    }

    public Vector3 GetDirection() => speedInDirection;

    public void SetCanMove(bool canMoveFlag)
    {
        canMove = !canMoveFlag;
    }

    public void PlayerCanMoveInPlusDirection() => canMoveInPlusDirection = true;
    public void PlayerCanMoveInMinusDirection() => canMoveInMinusDirection = true;
    public void PlayerCantMoveInPlusDirection() => canMoveInPlusDirection = false;
    public void PlayerCantMoveInMinusDirection() => canMoveInMinusDirection = false;
}
