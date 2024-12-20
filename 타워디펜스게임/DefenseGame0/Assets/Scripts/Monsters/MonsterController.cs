using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Vector3 FinalDestination; // ���� ����

    public float moveSpeed = 0.2f;
    public float approachSpeed = 0.2f; // ���� ��ġ�� �̵��ϴ� �ӵ�


    private bool isStopped;
    private bool isApproachingTarget = false; // ���� ��ġ�� �̵� ������ Ȯ��
    private Vector3 targetPosition; // ��ǥ ��ġ(���� ��ġ)


    private void FixedUpdate()
    {
        if (isApproachingTarget)
        {
            Vector3 targetPositionXOnly = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
            // õõ�� ���� ��ġ�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPositionXOnly, approachSpeed * Time.fixedDeltaTime);

            // ��ǥ ��ġ�� �����ϸ� ����
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isApproachingTarget = false;
                isStopped = true; // ���� �� ����
            }
        }
        else if (!isStopped)
        {
            // �⺻ �������� �̵�
            transform.Translate(new Vector3(moveSpeed * -1, 0, 0));
        }

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) // ���� ���̾�
        {
            // ���ְ� ������ ��ǥ�� ������
            Vector3 unitPosition = collision.transform.position;
            Vector3 monsterPosition = transform.position;

            // ���ְ� ���Ͱ� ���� �ִ� ���(��ǥ ���� ����)
            if (Vector3.Distance(unitPosition, monsterPosition) < 0.7f) // ��ħ �Ÿ� ���� ����
            {
                targetPosition = unitPosition; // ���� ��ġ�� ��ǥ�� ����
                isApproachingTarget = true; // ���� ��ġ�� �̵� ����
            }
            else
            {
                // �������� �´ڶ߸� ��� ����
                isStopped = true;
            }
        }
        else
        {
            isStopped = false;
        }

    }
}
