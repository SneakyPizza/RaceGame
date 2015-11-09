using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpDatabase : MonoBehaviour {
	
	public static List<PowerUps> powerUpList = new List<PowerUps>();

	void Awake () 
	{
		powerUpList.Add(new Boost());
		powerUpList.Add(new Shard());
		powerUpList.Add(new StarPower());
		powerUpList.Add(new Seeker());
		
		for (int i = 0; i < powerUpList.Count; i++)
		{
			powerUpList[i].powerUpID = i;
		}
	}
	public static PowerUps GetPowerUpString(string value)
	{
		PowerUps power = new PowerUps();
		for (int i = 0; i < powerUpList.Count; i++)
		{
			if (powerUpList[i].getPowerName == value)
				power = powerUpList[i];
		}
		return power;
	}
}
