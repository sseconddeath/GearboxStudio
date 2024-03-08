using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Heal : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<float> HealGot;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent<Healer>(out var Healer))
        {
            HealGot?.Invoke(Healer.Hp);
            Destroy(other.gameObject);
        }
    }
}
