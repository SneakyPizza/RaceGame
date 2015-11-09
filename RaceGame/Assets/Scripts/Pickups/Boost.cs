using UnityEngine;
using System.Collections;

public class Boost : PowerUps {

	public Boost()
	{
		powerUpClass = PowerClass.Boost;
		powerName = "Boost";
		maxPowerCharges = 2;
		currentPowerCharges = maxPowerCharges;
		powerSprite = "PowerUps/Boost";
		powerTime = 2;
	}
}
