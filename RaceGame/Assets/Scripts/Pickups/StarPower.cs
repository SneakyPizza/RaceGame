using UnityEngine;
using System.Collections;

public class StarPower : PowerUps {

	public StarPower()
	{
		powerUpClass = PowerClass.SelfBuff;
		powerName = "Star Power";
		maxPowerCharges = 1;
		currentPowerCharges = maxPowerCharges;
		powerSprite = "PowerUps/StarPower";
		powerTime = 5;
	}
	void Start()
	{
		//TODO Star Power Texture Offset
	}
}
