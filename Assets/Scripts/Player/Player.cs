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


	private void Update()
	{
        if (Input.GetKey(_moveKey))
        {
            /*_currentSpeed = Vector3.zero;*/
            MovePlayer();
        }
        if (Input.GetKey(_invertMoveKey))
        {
            /*_currentSpeed = Vector3.zero;*/
            MovePlayer(true);
        }
    }


	private void FixedUpdate()
    {
        rb.AddForce(_currentSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        _currentSpeed = Vector3.zero;
    }


    public void MovePlayer(bool invertDirection = false)
	{
		if (invertDirection)
		{
            _currentSpeed = _moveDirection.normalized * _speed * -1;
		}
		else
		{
            _currentSpeed = _moveDirection.normalized * _speed;
        }
    }


    public void MovePlayerByUI()
	{
        _currentSpeed = _moveDirection.normalized * _speed;
    }


    public void MovePlayerByUIInvert()
	{
        _currentSpeed = _moveDirection.normalized * _speed * -1;
    }
}
