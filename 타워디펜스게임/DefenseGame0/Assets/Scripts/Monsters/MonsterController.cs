using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Vector3 FinalDestination; // 도착 지점

    public float moveSpeed = 0.2f;
    public float approachSpeed = 0.2f; // 유닛 위치로 이동하는 속도


    private bool isStopped;
    private bool isApproachingTarget = false; // 유닛 위치로 이동 중인지 확인
    private Vector3 targetPosition; // 목표 위치(유닛 위치)


    private void FixedUpdate()
    {
        if (isApproachingTarget)
        {
            Vector3 targetPositionXOnly = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
            // 천천히 유닛 위치로 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPositionXOnly, approachSpeed * Time.fixedDeltaTime);

            // 목표 위치에 도달하면 멈춤
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isApproachingTarget = false;
                isStopped = true; // 도달 후 멈춤
            }
        }
        else if (!isStopped)
        {
            // 기본 왼쪽으로 이동
            transform.Translate(new Vector3(moveSpeed * -1, 0, 0));
        }

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) // 유닛 레이어
        {
            // 유닛과 몬스터의 좌표를 가져옴
            Vector3 unitPosition = collision.transform.position;
            Vector3 monsterPosition = transform.position;

            // 유닛과 몬스터가 겹쳐 있는 경우(좌표 거의 동일)
            if (Vector3.Distance(unitPosition, monsterPosition) < 0.7f) // 겹침 거리 기준 설정
            {
                targetPosition = unitPosition; // 유닛 위치를 목표로 설정
                isApproachingTarget = true; // 유닛 위치로 이동 시작
            }
            else
            {
                // 정면으로 맞닥뜨린 경우 멈춤
                isStopped = true;
            }
        }
        else
        {
            isStopped = false;
        }

    }
}
