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

        // 카메라의 뷰포트 좌표를 가져오기
        Camera mainCamera = Camera.main;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(boxCenter);


        if (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1)
        {
            // OverlapBoxAll(시작위치, 박스크기, 레이어)
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(boxCenter, BoxSize, 11);

            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.CompareTag("Monster"))
                {
                    Debug.Log("몬스터와 충돌");
                }
            }
        }
        else
        {
           // Debug.Log("충돌 범위가 카메라 화면 밖입니다.");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)Pos.position + Offset, BoxSize);
    }
}
