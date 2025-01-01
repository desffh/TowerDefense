using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��Ƽ�� (�Ϲ���) (���� ��ĭ)
public class Monster2Gizmo : MonoBehaviour
{
    public Transform Pos;
    private Vector2 BoxSize = new Vector2(2.8f, 1.3f);
    private Vector2 Offset = new Vector2(-0.8f, 0f);

    Monster2Anime Monster2Anime;

    public float attackCooldown = 5.0f; // ���� �ֱ� (�� ����)
    private float lastAttackTime = -1.0f; // ������ ���� ����

    bool previousState = false; // ���� ���¸� ����

    public int damage = 6;


    private void Start()
    {
        Monster2Anime = GetComponent<Monster2Anime>();
    }

    void Update()
    {
        Vector2 boxCenter = (Vector2)Pos.position + Offset;

        // ī�޶��� ����Ʈ ��ǥ�� ��������
        Camera mainCamera = Camera.main;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(boxCenter);

        if (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1)
        {

            // OverlapBoxAll(������ġ, �ڽ�ũ��, ���̾�)
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(boxCenter, BoxSize, 10);

            bool unitDetected = false;

            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.CompareTag("Unit"))
                {
                    Debug.Log("���ְ� �浹");

                    // ���� ��ٿ� Ȯ��
                    if (Time.time - lastAttackTime >= attackCooldown)
                    {
                        // �浹�� ��󿡼� UnitStat ��������
                        UnitStat unitStat = collider.GetComponent<UnitStat>();

                        if (unitStat != null)
                        {
                            if (unitStat is Unit00010 unit1Stat)
                            {
                                unit1Stat.TakeDamage(damage);
                                Debug.Log("Unit00010���� ������ ���޵�");
                            }
                            else if (unitStat is Unit00020 unit2Stat)
                            {
                                unit2Stat.TakeDamage(damage);
                                Debug.Log("Unit00020���� ������ ���޵�");
                            }
                        }

                        // ������ ���� �ð� ����
                        lastAttackTime = Time.time;
                    }

                    unitDetected = true;
                    break;
                }
            }

            // ���� ���¿� ���� ���°� �ٸ� ��쿡�� �ִϸ��̼� ȣ��
            if (unitDetected != previousState)
            {
                if (unitDetected)
                {
                    Monster2Anime.StartAttack(); // ���� �ִϸ��̼�
                }
                else
                {
                    Monster2Anime.EndAttack(); // Idle �ִϸ��̼�
                }

                previousState = unitDetected; // ���� ������Ʈ
            }
        }
        else
        {
            //Debug.Log("�浹 ������ ī�޶� ȭ�� ���Դϴ�.");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)Pos.position + Offset, BoxSize);
    }
}
