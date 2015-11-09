using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PowerUps : System.Object {

	public PowerClass powerUpClass;
	protected string powerName;
	protected int maxPowerCharges;
	protected int currentPowerCharges;
	protected float powerTime;
	protected string powerSprite;
	protected int powerDamage;
	protected float powerSpeed;
	public int powerUpID;

	public enum PowerClass
	{
		Projectile,
		AOE,
		Boost,
		SelfBuff
	}

	public string getPowerName
	{
		get { return powerName; }
		set { powerName = value; }
	}
	public int getMaxPowerCharges
	{
		get { return maxPowerCharges; }
		set { maxPowerCharges = value; }
	}
	public int getCurrentPowerCharges
	{
		get { return currentPowerCharges; }
		set { currentPowerCharges = value; }
	}
	public float getPowerTime
	{
		get { return powerTime; }
		set { powerTime = value; }
	}
	public string getPowerSprite
	{
		get { return powerSprite; }
		set { powerSprite = value; }
	}
	public PowerClass getPowerUpClass
	{
		get { return powerUpClass; }
	}
	public int getPowerDamage
	{
		get { return powerDamage; }
		set { powerDamage = value; }
	}
	public float getPowerSpeed
	{
		get { return powerSpeed; }
		set { powerSpeed = value; }
	}
}
