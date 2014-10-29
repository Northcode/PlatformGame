using UnityEngine;
using System.Collections;

public enum WeaponType {
	melee,
	ranged
}

public interface IWeapon
{
	//weapon things
	WeaponType Type {get;set;}
	int BaseDamage {get;set;}

	void Attack(IUnit wielder, IUnit target);
	void DoAttack(IUnit wielder);
}

public class WeaponScript : MonoBehaviour, IWeapon {

	public static LayerMask unit_mask = LayerMask.GetMask("Unit");

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	//Implement IWeapon
	public WeaponType Type {get;set;}
	public int base_damage = 1;
	public int BaseDamage {get { return base_damage; } set { base_damage = value; }}

	public void Attack(IUnit wielder, IUnit target) {
	}

	public void DoAttack(IUnit wielder) {
	}
}
