using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour 
{
	[SerializeField]private float _aiSpeed;
	[SerializeField]private Transform[] _waypoints;

	private int _currentWaypoint = 0;

	void Start()
	{

	}

	void Update()
	{
		MoveToWaypoint ();
	}

	private void MoveToWaypoint()
	{
		if (_currentWaypoint == 0) 
		{
			Debug.Log("No waypoints assigned");
		}

		if (Vector3.Distance(_waypoints[_currentWaypoint].position, transform.position) < 2 )
		{
			_currentWaypoint++;
			//_currentWaypoint += 1;
			if (_currentWaypoint >= _waypoints.Length) _currentWaypoint = 0;
		}
		MoveTowards(_waypoints[_currentWaypoint].position);
	}

	private void MoveTowards(Vector3 position)
	{
		Vector3 direction = position - transform.position;
		direction.y = 0;

		if(direction.magnitude < 0.5f)
		{
			SendMessage("SetSpeed",0,0);
			return;
		}

	}

}