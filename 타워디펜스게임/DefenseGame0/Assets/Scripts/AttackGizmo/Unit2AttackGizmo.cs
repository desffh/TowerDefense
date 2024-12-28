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
        // 스크립트 가져오기
        unit2Snow = GetComponent<Unit2Snow>();
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

            bool monsterDetected = false;

            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.CompareTag("Monster") && !hasSnow)
                {
                    //Debug.Log("몬스터와 충돌");


                    // 몬스터와 충돌함
                    monsterDetected = true;
                    break;


                }
            }
            if (monsterDetected && !unit2Snow.hasSnow)
            {
                //Debug.Log("몬스터 감지: 눈 생성 시작");
                unit2Snow.StartSnowCreation(); // 눈 생성 반복 시작
            }
            else if (!monsterDetected)
            {
                //Debug.Log("몬스터 없음: 눈 생성 중단");
                unit2Snow.StopSnowCreation(); // 반복 중단
            }
        }
        else
        {
            //Debug.Log("충돌 범위가 카메라 화면 밖");
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
