using UnityEngine;
using System.Collections;
using System.Timers;

public class BearSpawner : MonoBehaviour {

	Timer timer;
	public double period = 60;
	public GameObject entity;

	int counter = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(counter >= period) {
			Instantiate(entity,transform.position, Quaternion.identity);
			counter = 0;
		}

		counter++;
	}
}
