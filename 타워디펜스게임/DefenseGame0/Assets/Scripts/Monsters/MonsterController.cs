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


    public bool isStopped;
    private bool isApproachingTarget = false; // ���� ��ġ�� �̵� ������ Ȯ��
    private Vector3 targetPosition; // ��ǥ ��ġ(���� ��ġ)
    private Collider2D collidedUnit; // �浹�� ������ ����


    private void Awake()
    {
        FinalDestination = new Vector3(-19, 0, 0);    
    }

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

            if (Mathf.Abs(transform.position.x - FinalDestination.x) < 0.01f)
            {
                isStopped = true;
            }
        }

    }


    // OnTriggerEnter2D -> ������Ʈ�� �浹�� �Ͼ�� ó�� �ѹ� ȣ��
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) // ���� ���̾�
        {
            
            collidedUnit = collision; // �浹�� ���� ����


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
    }

    // OnTriggerExit2D -> ������Ʈ�� �浹���� �����
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision == collidedUnit)
        {
            collidedUnit = null;
            isStopped = false; // �ٽ� �̵�
        }
    }

}
