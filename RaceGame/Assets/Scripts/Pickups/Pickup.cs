using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == Tags.Player && other.GetComponent<Player_Powers>().alreadyHasPower == false)
		{
			other.GetComponent<Player_Powers>().alreadyHasPower = true;
			other.GetComponent<Player_Powers>().AddPower(GetRandomPower());
			Destroy(this.gameObject);
		}
	}	
	public PowerUps GetRandomPower()
	{
		//return PowerUpDatabase.powerUpList[3];
		return PowerUpDatabase.powerUpList[Random.Range(0, PowerUpDatabase.powerUpList.Count)];
	}
}
