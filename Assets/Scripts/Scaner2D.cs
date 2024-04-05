/***************************************************************************/
/** 	© 2017 NULLcode Studio. All Rights Reserved.
/** 	Разработано в рамках проекта: http://null-code.ru/
/** 	WebMoney: R209469863836, Z126797238132, E274925448496, U157628274347
/** 	Яндекс.Деньги: 410011769316504
/***************************************************************************/

using System.Collections;
using UnityEngine;

public class Scaner2D : MonoBehaviour {

	[SerializeField] private LayerMask targetMask; // маски целей
	[SerializeField] private LayerMask ignoreMask; // маски, которые нужно игнорировать (например, маска данного персонажа)
	[SerializeField] [Range(1, 6)] private int rays = 3; // число лучей по формуле (N * 2) - 1, где N - данная переменная
	[SerializeField] [Range(1, 30)] private float distance = 5; // длинна луча
	[SerializeField] [Range(0, 90)] private float angle = 20; // угол между лучами
	[SerializeField] private Transform rayPoint; // объект, из которого выпускаются лучи
	private int invert = 1;

	// только для платформера, когда персонаж может поворачивается лицом влево/вправо
	// где по умолчанию, на старте, персонаж смотрит вправо
	// если в игре персонаж всегда следит за мышкой (вид сверху) то эту функцию использовать не нужно
	public void PlatfomerFlip()
	{
		invert *= -1;
	}

	bool GetRay(Vector2 dir)
	{
		bool result = false;

		RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, dir, distance, ~ignoreMask);

		if(hit.collider != null)
		{
			if(CheckObject(hit.collider.gameObject))
			{
				result = true;
				Debug.DrawLine(rayPoint.position, hit.point, Color.green);
				// луч попал в цель
			}
			else
			{
				Debug.DrawLine(rayPoint.position, hit.point, Color.blue);
				// луч попал в любой другой коллайдер
			}
		}
		else
		{
			Debug.DrawRay(rayPoint.position, dir * distance, Color.red);
			// луч никуда не попал
		}
		return result;
	}

	bool CheckObject(GameObject obj)
	{
		if(((1 << obj.layer) & targetMask) != 0)
		{
			return true;
		}

		return false;
	}

	bool Scan() 
	{
		bool hit = false;
		float j = 0;
		for (int i = 0; i < rays; i++)
		{
			var x = Mathf.Sin(j);
			var y = Mathf.Cos(j);

			j += angle * Mathf.Deg2Rad / rays * invert;

			if(x != 0) 
			{
				if(GetRay(rayPoint.TransformDirection(new Vector3(y,-x,0)))) hit = true;
			}

			if(GetRay(rayPoint.TransformDirection(new Vector3(y,x,0)))) hit = true;
		}

		return hit;
	}

	void Update()
	{
		if(Scan())
		{
			// Контакт с целью
		}
		else
		{
			// Поиск цели...
		}
	}
}
