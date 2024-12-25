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


    public bool isStopped;
    private bool isApproachingTarget = false; // 유닛 위치로 이동 중인지 확인
    private Vector3 targetPosition; // 목표 위치(유닛 위치)
    private Collider2D collidedUnit; // 충돌한 유닛을 추적


    private void Awake()
    {
        FinalDestination = new Vector3(-19, 0, 0);    
    }

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

            if (Mathf.Abs(transform.position.x - FinalDestination.x) < 0.01f)
            {
                isStopped = true;
            }
        }

    }


    // OnTriggerEnter2D -> 오브젝트간 충돌이 일어날때 처음 한번 호출
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) // 유닛 레이어
        {
            
            collidedUnit = collision; // 충돌한 유닛 저장


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
    }

    // OnTriggerExit2D -> 오브젝트간 충돌에서 벗어날때
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision == collidedUnit)
        {
            collidedUnit = null;
            isStopped = false; // 다시 이동
        }
    }

}
