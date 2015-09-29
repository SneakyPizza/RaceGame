using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	private float _speedMax = 0.5f;
	private float _speedMin = -0.2f;
	public float currentSpeed;
	private float _speedMeter;

	private float _angleRot;

	void Update ()
	{
		Move();
		if (Input.GetKeyDown(KeyCode.Y))
			Flip();
		if (Input.GetKeyDown(KeyCode.Space))
			Jump();
	}
	private void Move()
	{
		_angleRot = Input.GetAxis("Horizontal") * currentSpeed;
		_angleRot = _angleRot * 3f;

		if (Input.GetKey(KeyCode.LeftShift))
			_angleRot = _angleRot * 2;
		transform.Rotate(0,_angleRot,0);

		float y = Input.GetAxis("Vertical") * currentSpeed;

		if (Input.GetAxis("Vertical") > 0 && (_speedMax > currentSpeed))
			currentSpeed += 0.005f;		
		if (Input.GetAxis("Vertical") < 0 && (_speedMin < currentSpeed))
			currentSpeed -= 0.015f;

		if (Input.GetAxis("Vertical") == 0 && currentSpeed > 0)
			currentSpeed -= 0.005f;
		if (Input.GetAxis("Vertical") == 0 && currentSpeed < 0)
			currentSpeed += 0.005f;

		transform.Translate(0,0,currentSpeed);
	}
	private void Flip()
	{
		if(transform.localEulerAngles.z > 100)
			transform.Rotate(0,0,180);
	}
	private void Jump()
	{
		GetComponent<Rigidbody>().AddForce(0,150000,0);
	}
}
