using UnityEngine;
using System;
using System.Collections;

public class MeleeWeapon : MonoBehaviour, IWeapon {

	// Use this for initialization
	void Start () {
		Type = WeaponType.melee;
	}

	// Update is called once per frame
	void Update () {

	}

	//Implement IWeapon
	public WeaponType Type {get;set;}
	public int base_damage = 1;
	public int BaseDamage {get { return base_damage; } set { base_damage = value; }}
	public float range = 1;
	public string Name;
	public Rect bounds;

	public void Attack(IUnit wielder, IUnit target) {
	}

	public void DoAttack(IUnit wielder) {
		Vector2 ux = new Vector2(transform.position.x + bounds.xMin,transform.position.y + bounds.yMin);
		Vector2 uy = new Vector2(transform.position.x + bounds.xMax * range,transform.position.y + bounds.yMax);
		Debug.Log("Checking for enemies in (" + ux.x + "," + ux.y + "),(" + uy.x + "," + uy.y + ")");
		//Raycast weapon
		Collider2D collided = Physics2D.OverlapArea(ux,uy,WeaponScript.unit_mask);
		//Find target
		if(collided == null) {Debug.Log("No emenies found"); return; }
		Debug.Log("Attacking: " + collided.name);

		Destroy(collided.gameObject);
		//If target do attack
		//else nothing
	}
}
