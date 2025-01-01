using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Transform monsterTransform; // ������ ��ġ

    private void Update()
    {
        UpdatePosition(); // �� ������ ü�¹� ��ġ ����
    }

    public void SetTarget(Transform newTarget)
    {
        monsterTransform = newTarget;

        // ü�¹��� �ʱ� ��ġ�� ��� ����
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (monsterTransform == null) return;

        // 1. ������ ���� ��ǥ�� �������� ����
        Vector3 adjustedWorldPosition = monsterTransform.position + new Vector3(0, 1, 0);

        // 2. ȭ�� ��ǥ�� ��ȯ
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(adjustedWorldPosition);

        // 3. HP ���� ȭ�� ��ǥ ����
        transform.position = screenPosition;
    }

}
