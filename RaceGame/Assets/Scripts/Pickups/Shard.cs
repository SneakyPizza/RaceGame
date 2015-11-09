using UnityEngine;
using System.Collections;

public class Shard : PowerUps {

	public Shard()
	{
		powerUpClass = PowerClass.Projectile;
		powerName = "Shards";
		maxPowerCharges = 4;
		powerDamage = 15;
		powerSpeed = 0.5f;
		currentPowerCharges = maxPowerCharges;
		powerSprite = "PowerUps/Shard";
		powerTime = 0;
	}
}
