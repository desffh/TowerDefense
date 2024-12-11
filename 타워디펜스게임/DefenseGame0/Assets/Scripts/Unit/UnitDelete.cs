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

    public Transform detectionCenter; // ���� ������ �߽��� (�ʿ�� ī�޶� ��ġ�� Ư�� ������Ʈ ���)

    public float detectionRadius = 2f; // ���� ���� �ݰ�

    public void DeleteUnit(GameObject unit, Sprite sprite)
    {
        currentUnit = unit;
        currentUnitSprite = sprite;
    }


    // ���� ���� ������ �ִ��� Ȯ���ϴ� �Լ�
    public bool IsUnitInRange(GameObject unit)
    {
        float distance = Vector2.Distance(detectionCenter.position, unit.transform.position);
        return distance <= detectionRadius;
    }



}
