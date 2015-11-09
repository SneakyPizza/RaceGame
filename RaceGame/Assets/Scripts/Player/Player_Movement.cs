using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	[SerializeField] private Rigidbody _rigidBody;

	private float _speedMax = 20f;
	private float _speedMin = -15f;
	public float currentSpeed;
	private float _speedModifier = 0.4f;
	private float _speedMeter;

	private float _angleRot;

	void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		if (Input.GetJoystickNames().Length > 0)
			MoveJoyStick();
		else
			MoveKeyBoard();
		if (Input.GetKeyDown(KeyCode.Y))
			Flip();
		if (Input.GetKeyDown(KeyCode.Space))
			Jump();
	}
	private void MoveKeyBoard()
	{
		if(Input.GetAxis("Horizontal") != 0 && currentSpeed != 0)
		{
			_angleRot = Input.GetAxis("Horizontal") * currentSpeed;
			_angleRot = _angleRot * 3f;

			if (Input.GetKey(KeyCode.LeftShift))
			{
				_angleRot = _angleRot * 2;
				_rigidBody.AddForce(transform.right * _angleRot);
			}else
				_rigidBody.AddForce(transform.right * _angleRot / 3);
		
		_angleRot = _angleRot * 3f;
		transform.Rotate(0, _angleRot / 30, 0);
		
		}else if (Input.GetAxis("Horizontal") != 0)
		{
			_angleRot = Input.GetAxis("Horizontal");
			transform.Rotate(0, _angleRot, 0);
		}

		if (Input.GetAxis("Vertical") > 0 && (_speedMax > currentSpeed))
			currentSpeed += _speedModifier;		
		if (Input.GetAxis("Vertical") < 0 && (_speedMin < currentSpeed))
			currentSpeed -= (_speedModifier * 3);

		if (Input.GetAxis("Vertical") == 0 && currentSpeed > 0)
			currentSpeed -= _speedModifier;
		if (Input.GetAxis("Vertical") == 0 && currentSpeed < 0)
			currentSpeed += _speedModifier;

		_rigidBody.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
	}
	private void MoveJoyStick()
	{
		if(Input.GetAxis("Horizontal") != 0 && currentSpeed != 0)
		{
			_angleRot = Input.GetAxis("Horizontal") * currentSpeed;
					
			if (Input.GetButton("JoyStickSlide"))
			{
				_angleRot = _angleRot * 2;
				_rigidBody.AddForce(transform.right * _angleRot);
			}else
				_rigidBody.AddForce(transform.right * _angleRot);

			_angleRot = _angleRot * 3f;
			transform.Rotate(0, _angleRot / 15, 0);

		}else if (Input.GetAxis("Horizontal") != 0)
		{
			_angleRot = Input.GetAxis("Horizontal");
			transform.Rotate(0, _angleRot, 0);
		}

		if ( currentSpeed >= -0.1f && currentSpeed <= 0.1f)
			currentSpeed = 0f;

		if (Input.GetAxis("JoyStickAccelerate") > 0 && (_speedMax > currentSpeed))
			currentSpeed += _speedModifier;
		if (Input.GetAxis("JoyStickReverse") > 0 && (_speedMin < currentSpeed))
			currentSpeed -= (_speedModifier * 3);

		if (Input.GetAxis("JoyStickAccelerate") == 0 && currentSpeed > 0)
			currentSpeed -= _speedModifier / 5;
		if (Input.GetAxis("JoyStickReverse") == 0 && currentSpeed < 0)
			currentSpeed += _speedModifier;
		
		_rigidBody.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
	}
	private void Flip()
	{
		if(transform.localEulerAngles.z > 90)
			transform.rotation = new Quaternion(0,0,0,0);
	}
	private void Jump()
	{
		GetComponent<Rigidbody>().AddForce(0,500,0);
	}
	public float changeMaxSpeed
	{
		get { return _speedMax; }
		set { _speedMax = value; }
	}
}
