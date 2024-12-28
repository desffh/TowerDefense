using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Action onDestroyed;

    Unit1Arrow unit1Arrow;

    private float speed = 3;

    public int damage = 20;

    // �浹 Ȯ�� 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("���Ϳ� ��Ƽ� Ȱ ��Ȱ��ȭ");

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
        unit1Arrow = GetComponent<Unit1Arrow>();

        Invoke("DestroyArrow", 4);
    }

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);

    }


    void DestroyArrow()
    {
        //Debug.Log("Ȱ �ı�");
        onDestroyed?.Invoke();

        // Collider ��Ȱ��ȭ
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject);
    }

    void DestroyArrow2()
    {
        // Collider ��Ȱ��ȭ
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject);
    }
}
