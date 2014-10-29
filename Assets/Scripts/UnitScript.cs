using UnityEngine;
using System.Collections;

public interface IUnit {
	int HP {get;set;}

	void TakeDamage(IUnit attacker, int amount, IWeapon weapon);
	void Heal(IUnit healer, int amount);
}

public class UnitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
