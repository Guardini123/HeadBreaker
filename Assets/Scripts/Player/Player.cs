using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _speed;
    private Vector3 _currentSpeed;

    [SerializeField] private KeyCode _moveKey;
    [SerializeField] private KeyCode _invertMoveKey;

    public Rigidbody rb { get; private set; }

    public Vector3 MoveDirection => _moveDirection;


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }


	private void FixedUpdate()
    {
        rb.AddForce(_currentSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        _currentSpeed = Vector3.zero;
    }


    public void MovePlayer(bool invertDirection = false)
	{
        _currentSpeed = _moveDirection.normalized * _speed;
        _currentSpeed = invertDirection ? _currentSpeed * -1 : _currentSpeed;
    }
}
