using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit2AttackGizmo : MonoBehaviour
{
    public Transform Pos;
    private Vector2 BoxSize = new Vector2(5.8f, 1.3f);
    private Vector2 Offset = new Vector2(3.7f, 0f);

    public Unit2Snow unit2Snow;

    private bool hasSnow = false;

    private void Start()
    {
        // ��ũ��Ʈ ��������
        unit2Snow = GetComponent<Unit2Snow>();
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
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(boxCenter, BoxSize, 11);

            bool monsterDetected = false;

            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.CompareTag("Monster") && !hasSnow)
                {
                    //Debug.Log("���Ϳ� �浹");


                    // ���Ϳ� �浹��
                    monsterDetected = true;
                    break;


                }
            }
            if (monsterDetected && !unit2Snow.hasSnow)
            {
                //Debug.Log("���� ����: �� ���� ����");
                unit2Snow.StartSnowCreation(); // �� ���� �ݺ� ����
            }
            else if (!monsterDetected)
            {
                //Debug.Log("���� ����: �� ���� �ߴ�");
                unit2Snow.StopSnowCreation(); // �ݺ� �ߴ�
            }
        }
        else
        {
            //Debug.Log("�浹 ������ ī�޶� ȭ�� ��");
        }
    }

    IEnumerator ResetSnowFlag()
    {
        yield return new WaitForSeconds(1f);  // Reset flag after 1 second
        hasSnow = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)Pos.position + Offset, BoxSize);
    }
}
