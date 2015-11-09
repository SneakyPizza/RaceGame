using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player_Powers : MonoBehaviour {

	public bool alreadyHasPower = false;
	[SerializeField] private Text _currentPowerText;
	[SerializeField] private Image _currentPowerSprite;
	[SerializeField] private Transform _projectileSpawner;
	[SerializeField] private Material _render;
	[SerializeField] private ParticleSystem _boostParticle;
	public List<GameObject> _projectileToShoot = new List<GameObject>();
	private PowerUps _currentPower;
	private string _powerInfo = "";
	private Player_Movement playerMovement;
	Vector2 _test = new Vector2 (0.1f,0);

	void Start()
	{
		playerMovement = GetComponent<Player_Movement>();
		_boostParticle.Stop();
	}
	public void AddPower(PowerUps powerUp)
	{
		_currentPowerSprite.sprite = Resources.Load(powerUp.getPowerSprite, typeof(Sprite)) as Sprite;
		powerUp.getCurrentPowerCharges = powerUp.getMaxPowerCharges;
		_currentPower = powerUp;
		ChangePowerText(_currentPower);
	}
	private void ChangePowerText(PowerUps powerUp)
	{
		if (powerUp.getCurrentPowerCharges > 0)
		{
			_powerInfo = "";
			_powerInfo += "Power : " + "\n";
			_powerInfo += _currentPower.getPowerName + "\n";
			_powerInfo += _currentPower.getCurrentPowerCharges.ToString() + " Charges";
			_currentPowerText.text = _powerInfo;
		}
		else
		{
			alreadyHasPower = false;
			_powerInfo = "";
			_currentPowerText.text = _powerInfo;
			_currentPowerSprite.sprite = null;
		}
	}
	void Update()
	{
		if ((Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("JoyStickPower")) && alreadyHasPower == true)
		{
			if (_currentPower.getCurrentPowerCharges > 0)
			{
				UsePower();
				_currentPower.getCurrentPowerCharges -= 1;
				ChangePowerText(_currentPower);
			}
		}
	}
	private void UsePower()
	{
		switch (_currentPower.getPowerUpClass)
		{
		case PowerUps.PowerClass.Projectile:
			ActivateProjectiles();
			break;
		case PowerUps.PowerClass.Boost:
			StartCoroutine(ActivateBoost());
			break;
		case PowerUps.PowerClass.SelfBuff:
			StartCoroutine(ActivateStarPower());
			break;
		}
	}
	private void ActivateProjectiles()
	{
		foreach(GameObject projectile in _projectileToShoot)
		{
			if (projectile.name == _currentPower.getPowerName)
			{
				GameObject.Instantiate(projectile, _projectileSpawner.position, _projectileSpawner.rotation);
			}
		}
	}
	IEnumerator ActivateBoost()
	{
		_boostParticle.Play();
		playerMovement.currentSpeed = (playerMovement.currentSpeed + playerMovement.currentSpeed);
		if (playerMovement.currentSpeed > 0.6f)
			playerMovement.currentSpeed = 0.6f;
		yield return new WaitForSeconds(_currentPower.getPowerTime);
		if (playerMovement.currentSpeed > playerMovement.changeMaxSpeed)
			playerMovement.currentSpeed = 0.29f;
		_boostParticle.Stop();
	}
	IEnumerator ActivateStarPower()
	{
		playerMovement.changeMaxSpeed = 0.6f;
		_render.mainTextureOffset += _test;
		yield return new WaitForSeconds(_currentPower.getPowerTime);
		playerMovement.changeMaxSpeed = 0.3f;
		if (playerMovement.currentSpeed > playerMovement.changeMaxSpeed)
			playerMovement.currentSpeed = 0.29f;
	}
}
