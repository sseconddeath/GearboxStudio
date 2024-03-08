using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField]
    private float _hp;

    public float Hp => _hp;
}
