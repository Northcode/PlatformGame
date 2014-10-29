using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum Direction {
	right,left
}

public class PlayerController : MonoBehaviour, IUnit {

	public float top_speed = 10.0f;
	public float jump_force = 10.0f;
	public float turn_force = 0.8f;

	public Transform spawn_point;

	private Direction l_direction;

	public Direction direction
	{
		get {
			return l_direction;
		}
		set {
			if (value != l_direction)
				Flip();
			l_direction = value;
		}
	}

	public Transform player_feet;
	public float feet_size = 0.2f;
	public LayerMask ground_mask;

	public MeleeWeapon sword;

	public List<IWeapon> Weapons = new List<IWeapon>();

	Animator anim;

	public delegate void PlayerEvent(PlayerController pc);

	public PlayerEvent OnDeath;
	public PlayerEvent OnWin;

	public bool on_ground {
		get {
			return Physics2D.OverlapCircle(player_feet.position,feet_size,ground_mask);
		}
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		OnDeath += (p) => {};
		OnWin += (p) => {};
	}

	void Update() {
		if(Input.GetButtonDown("Jump") && on_ground) {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jump_force);
			anim.SetTrigger("jumping");
		} else if (Input.GetButtonDown("Fire1")) {
			anim.SetTrigger("attack");
			Attack();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//move
		float speed = Input.GetAxis("Horizontal") * top_speed;
		rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);

		//check for speed direction
		if(Math.Abs(speed) > 0.1) {
			direction = speed > 0 ? Direction.right : Direction.left;
		}


		anim.SetBool("moving", Math.Abs(speed) > 0.1);
		anim.SetBool("on_ground", on_ground);

	}

	void Flip()
	{
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y + turn_force * (rigidbody2D.velocity.x * rigidbody2D.velocity.x + 1));
	}

	public void Respawn()
	{
		if(spawn_point != null) {
			transform.position = spawn_point.position;
			OnDeath(this);
		}
	}

	public void WinTheGame()
	{
		OnWin(this);
	}

	void Attack() {
		//display weapon
		//make weapon attack
		Debug.Log("Attack!");
		if(sword)
			sword.DoAttack(this);
	}

	//Implement IUnit
	public int HP {get;set;}

	public void TakeDamage(IUnit attacker, int amount, IWeapon weapon) {

	}

	public void Heal(IUnit healer, int amount) {

	}
}
