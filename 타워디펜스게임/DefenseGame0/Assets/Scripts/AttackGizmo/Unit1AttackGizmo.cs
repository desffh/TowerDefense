using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit1AttackGizmo : MonoBehaviour
{

    public Transform Pos;
    private Vector2 BoxSize = new Vector2(13.2f, 1.3f);
    private Vector2 Offset = new Vector2(7.4f, 0f);

    [SerializeField] private Unit1Arrow unit1Arrow;

    private bool hasArrow = false;

    private void Start()
    {
       
    }

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
                if (collider.CompareTag("Monster") && !hasArrow)
                {
                    Debug.Log("몬스터와 충돌");


                    // UnitArrow 생성

                    unit1Arrow.SpawnArrow();
                    unit1Arrow.bowObj.transform.SetParent(transform);
                    hasArrow = true;
                }
            }
        }
        else
        {
            Debug.Log("충돌 범위가 카메라 화면 밖입니다.");
        }
    }


    IEnumerator ResetArrowFlag()
    {
        yield return new WaitForSeconds(1f);  // Reset flag after 1 second
        hasArrow = false;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)Pos.position + Offset, BoxSize);
    }
}