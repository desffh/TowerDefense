using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public Action onDestroyed;

    Unit2Snow unit2snow;

    private float speed = 2;

    public int damage = 20;

    // �浹 Ȯ�� 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("���Ϳ� ��Ƽ� �� ��Ȱ��ȭ");

            MonsterStat monsterStat = other.GetComponent<MonsterStat>();

            if (monsterStat != null)
            {
                if (monsterStat is Monster1Stat)
                {
                    Monster1Stat monster1Stat = (Monster1Stat)monsterStat;
                    monster1Stat.TakeDamage(damage);
                }

                else if (monsterStat is Monster2Stat)
                {
                    Monster2Stat monster2Stat = (Monster2Stat)monsterStat;
                    monster2Stat.TakeDamage(damage);
                }

                else if (monsterStat is Monster3Stat)
                {
                    Monster3Stat monster3Stat = (Monster3Stat)monsterStat;
                    monster3Stat.TakeDamage(damage);
                }
            }
            gameObject.SetActive(false);
        }

    }


    private void Start()
    {
        unit2snow = GetComponent<Unit2Snow>();

        Invoke("DestroySnow", 4);
    }

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);

    }


    void DestroySnow()
    {
        //Debug.Log("�� �ı�");
        onDestroyed?.Invoke();

        // Collider ��Ȱ��ȭ
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject);
    }

    void DestroySnow2()
    {
        // Collider ��Ȱ��ȭ
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject);
    }
}
