using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillZone : MonoBehaviour {

	public Text ui_text;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player")
		{
			Debug.Log("Kill player");
			PlayerController pc = other.GetComponent<PlayerController>();
			if(ui_text != null) ui_text.text = "You deaded!";
			pc.Respawn();
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
