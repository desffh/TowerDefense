using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class UnitDelete : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject currentUnit;

    public Sprite currentUnitSprite;

    public LayerMask Object;

    public Transform detectionCenter; // 감지 범위의 중심점 (필요시 카메라 위치나 특정 오브젝트 사용)

    public float detectionRadius = 2f; // 감지 범위 반경

    public void DeleteUnit(GameObject unit, Sprite sprite)
    {
        currentUnit = unit;
        currentUnitSprite = sprite;
    }


    // 범위 내에 유닛이 있는지 확인하는 함수
    public bool IsUnitInRange(GameObject unit)
    {
        float distance = Vector2.Distance(detectionCenter.position, unit.transform.position);
        return distance <= detectionRadius;
    }



}
