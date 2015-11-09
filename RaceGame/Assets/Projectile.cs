using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Projectile : MonoBehaviour {

	public GameObject otherObject;
	public PowerUps currentProjectile;
	public List<GameObject> _seekerTargets = new List<GameObject>();	
	private Transform _target;
	private int targetAdd = 0;
	private float _speed;
	private float _despawnTime = 5;
	private float _despawnMoment;
	private float _distance = 1000;
	private int _damage;

	void Start()
	{
		_despawnMoment = Time.time + _despawnTime;
		switch (otherObject.name)
		{
		case "Shards(Clone)":
			GiveValues("Shards");
			break;
		case "Seeker(Clone)":
			GiveValues("Seeker");
			SetSeekerTargets();
			break;
		}
	}
	void LateUpdate()
	{
		switch (otherObject.name)
		{
		case "Shards(Clone)":
			ShardsFlight();
			break;
		case "Seeker(Clone)":
			SeekerFlight();
			break;
		}
		if (Time.time > _despawnMoment)
			Destroy(otherObject);
	}
	private void GiveValues(string value)
	{
		_damage = PowerUpDatabase.GetPowerUpString(value).getPowerDamage;
		_speed = PowerUpDatabase.GetPowerUpString(value).getPowerSpeed;
	}
	private void ShardsFlight()
	{
		float distance;
		otherObject.transform.Translate(Vector3.back * _speed);
		distance = Vector3.Distance(this.transform.position, otherObject.transform.position);
		transform.position = (transform.position - otherObject.transform.position).normalized * distance + otherObject.transform.position;
		transform.RotateAround (otherObject.transform.position, transform.forward, 350 * Time.deltaTime);
	}
	private void SetSeekerTargets()
	{
		int j = 0;
		foreach (GameObject player in GameObject.FindGameObjectsWithTag(Tags.Player))
		{
			if (player.name != "Player")
			{	
				j ++;
				_seekerTargets.Add(GameObject.Find("Player (" + j + ")"));
			}
		}
		for (int i = 0; i < _seekerTargets.Count; i++)
		{
			if (Vector3.Distance(otherObject.transform.position, _seekerTargets[i].transform.position) < _distance)
			{
				_distance = Vector3.Distance(otherObject.transform.position, _seekerTargets[i].transform.position);
				targetAdd = i;
			}
			if (i == _seekerTargets.Count - 1)
			{
				_target = _seekerTargets[targetAdd].transform;
			}
		}
	}
	private void SeekerFlight()
	{	
		if (_target != null)
		{
			if (Vector3.Distance(_target.position, otherObject.transform.position) < 0.2f)
				Destroy(otherObject);
			otherObject.transform.LookAt(_target.position);
		}
		this.transform.Rotate(Vector3.forward * 350);
		otherObject.transform.Translate(Vector3.forward * _speed);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == Tags.Player && other.gameObject.name != "Player")
		{
			other.gameObject.GetComponent<Player_Health>().DamagePlayer(_damage);
			other.gameObject.GetComponent<Player_Movement>().currentSpeed = other.gameObject.GetComponent<Player_Movement>().currentSpeed / 2;
			other.gameObject.GetComponent<Rigidbody>().AddForceAtPosition((other.gameObject.transform.position - this.transform.position) * 350, this.transform.position);
			Destroy(otherObject);
		}
	}
}
