using UnityEngine;
using System.Collections;

public class ParalaxImage : MonoBehaviour {

	public Transform player;

	public float horizontal_paralax;
	public float vertical_paralax;

	public float horizontal_offset;
	public float vertical_offset;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.position.x * horizontal_paralax + horizontal_offset,
		player.position.y * vertical_paralax + vertical_offset,
		transform.position.z);
	}
}
