using UnityEngine;
using System.Collections;

public class Seeker : PowerUps {
	
	public Seeker()
	{
		powerUpClass = PowerClass.Projectile;
		powerName = "Seeker";
		maxPowerCharges = 2;
		powerDamage = 20;
		powerSpeed = 0.5f;
		currentPowerCharges = maxPowerCharges;
		powerSprite = "PowerUps/Shard";
		powerTime = 0;
	}
}
