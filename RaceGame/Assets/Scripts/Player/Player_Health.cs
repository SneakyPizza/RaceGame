using UnityEngine;
using System.Collections;

public class Player_Health : MonoBehaviour {

	private int _healthMax = 100;
	private int _healthCurrent;

	void Start()
	{
		_healthCurrent = _healthMax;
	}
	public void DamagePlayer(int dmg)
	{
		_healthCurrent = _healthCurrent - dmg;
	}
}
