using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Healt : MonoBehaviour
{
    [SerializeField]
    private float _maxHp;

    [SerializeField]
    private UnityEvent Die;

    [SerializeField]
    private UnityEvent<float> HpChaged;
    [SerializeField]
    private UnityEvent<float> HpChagedPercent;

    private float _hp;      

    public float HP
    {
        get => _hp;
        set
        {
            _hp = value;
            HpChaged?.Invoke(_hp);
            HpChagedPercent?.Invoke(_hp / _maxHp);

            if (_hp <= 0)
            {
                Die?.Invoke();

                LoadScene();
            }
        }
    }
    [System.Obsolete]
    void LoadScene()
    {
        Application.LoadLevel(Application.loadedLevel);

    }
   
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        HP = _maxHp;
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
    }
    public void AddHealth(float hp)
    {
        HP += hp;
    }
    
}
    //private void Die()
    //{
    //    if (menuEnd.enabled == false)
    //    {
    //        menuEnd.enabled = true;
    //    }
    //}
    //public void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.CompareTag("heal"))
    //    {
    //        Destroy(col.gameObject);
    //        AddHealth(10);
    //    }
    //}

