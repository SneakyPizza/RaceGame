using UnityEngine;
using System.Collections;

public class Player_Respawn : MonoBehaviour {

	private Vector3 startpos;
	private Quaternion startRot;

	void Start()
	{
		startpos = this.transform.position;
		startRot = this.transform.rotation;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.R))
			Respawn();
	}
	void Respawn()
	{
		GetComponent<Player_Movement>().currentSpeed = 0;
		this.transform.position = startpos;
		this.transform.rotation = startRot;
	}
}
