/***************************************************************************/
/** 	© 2017 NULLcode Studio. All Rights Reserved.
/** 	Разработано в рамках проекта: http://null-code.ru/
/** 	WebMoney: R209469863836, Z126797238132, E274925448496, U157628274347
/** 	Яндекс.Деньги: 410011769316504
/***************************************************************************/

using System.Collections;
using UnityEngine;

public class Character2DControl : MonoBehaviour {

	[SerializeField] private float speed = 1.5f; // скорость движения
	[SerializeField] private float acceleration = 100; // ускорение
	[SerializeField] private float jumpForce = 5; // сила прыжка
	[SerializeField] private float jumpDistance = 0.75f; // расстояние от центра объекта, до поверхности (определяется вручную в зависимости от размеров спрайта)
	[SerializeField] private KeyCode jumpButton = KeyCode.Space; // клавиша для прыжка
	[SerializeField] private bool facingRight = true; // в какую сторону смотрит персонаж на старте?

	[SerializeField] private Scaner2D scaner; // для разворота лучей вместе с лицом персонажа

	private Vector3 direction;
	private int layerMask;
	private Rigidbody2D body;

	void Awake() 
	{
		body = GetComponent<Rigidbody2D>();
		body.freezeRotation = true;
		layerMask = 1 << gameObject.layer | 1 << 2;
		layerMask = ~layerMask;
	}

	bool GetJump() // проверяем, есть ли коллайдер под ногами
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, jumpDistance, layerMask);
		if(hit.collider) return true;
		return false;
	}

	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed * acceleration);

		if(Mathf.Abs(body.velocity.x) > speed)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, Vector3.down * jumpDistance);
	}

	void Flip() // отражение по горизонтали
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		scaner.PlatfomerFlip();
	}

	void Update() 
	{
		if(Input.GetKeyDown(jumpButton) && GetJump())
		{
			body.velocity = new Vector2(0, jumpForce);
		}

		float h = Input.GetAxis("Horizontal");

		direction = new Vector2(h, 0); 

		if(h > 0 && !facingRight) Flip(); else if(h < 0 && facingRight) Flip();
	}
}
