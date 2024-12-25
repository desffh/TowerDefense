using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit4AttackGizmo : MonoBehaviour
{
    public Transform Pos;
    private Vector2 BoxSize = new Vector2(10.2f, 1.3f);
    private Vector2 Offset = new Vector2(5.9f, 0f);



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

            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.CompareTag("Monster"))
                {
                    Debug.Log("���Ϳ� �浹");
                }
            }
        }
        else
        {
           // Debug.Log("�浹 ������ ī�޶� ȭ�� ���Դϴ�.");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)Pos.position + Offset, BoxSize);
    }
}
