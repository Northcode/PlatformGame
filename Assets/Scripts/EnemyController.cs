using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour, IUnit {

	public float movement_speed = 5.0f;
	Direction _direction = Direction.right;
	public bool ignore_drops = false;

	public Direction direction {
		get {
			return _direction;
		}
		set {
			if(value != _direction) Flip();
			_direction = value;
		}
	}

	public float look_distance = 0.7f;
	public LayerMask ground_mask;

	public bool DropAhead {
		get {
			Vector2 start = rigidbody2D.position + new Vector2((collider2D.bounds.extents.x * (direction == Direction.right ? 1 : -1)),0);
			RaycastHit2D hit = Physics2D.Raycast(start, -Vector2.up, look_distance, ground_mask);
			return !hit;
		}
	}

	public bool WallAhead {
		get {
			Vector2 start = rigidbody2D.position + new Vector2((collider2D.bounds.extents.x * (direction == Direction.right ? 1 : -1)),0);
			RaycastHit2D hit = Physics2D.Raycast(start, (direction == Direction.right ? Vector2.right : -Vector2.right), look_distance, ground_mask);
			return hit;
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		if((!ignore_drops && DropAhead) || WallAhead) {
			direction = direction == Direction.right ? Direction.left : Direction.right;
		}

		rigidbody2D.velocity = new Vector2(movement_speed * (direction == Direction.right ? 1 : -1),rigidbody2D.velocity.y);
	}

	void Flip()
	{
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}


	//Implement IUnit
	public int HP {get;set;}

	public void TakeDamage(IUnit attacker, int amount, IWeapon weapon) {

	}

	public void Heal(IUnit healer, int amount) {

	}
}
