using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public GameObject hpBarPrefab; // HP �� ������
    private GameObject hpBarInstance; // ������ HP �� �ν��Ͻ�

    private void Start()
    {
        CreateHPBar();
    }

    void CreateHPBar()
    {
        if (hpBarPrefab == null)
        {
            Debug.LogError("hpBarPrefab�� ������� �ʾҽ��ϴ�!");
            return;
        }

        // Canvas�� ã�Ƽ� HP �ٸ� �߰�
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("���� Canvas�� �������� �ʽ��ϴ�!");
            return;
        }

        // HP �� �������� Canvas �Ʒ��� ����
        hpBarInstance = Instantiate(hpBarPrefab, canvas.transform);

        // ü�¹ٿ� ���� ����
        Slider hpSlider = hpBarInstance.GetComponentInChildren<Slider>();
        if (hpSlider == null)
        {
            Debug.LogError("hpBarPrefab ���ο� Slider�� �������� �ʽ��ϴ�!");
            return;
        }

        UnitStat unitstat = GetComponent<UnitStat>();
        if (unitstat == null)
        {
            Debug.LogError("UnitStat ������Ʈ�� Unit ������Ʈ�� �߰����� �ʾҽ��ϴ�!");
            return;
        }

        // ü�¹� ����
        unitstat.SetHPBar(hpSlider);

        // HP �ٸ� ���� ���� ��ġ
        HPBar hpBarScript = hpBarInstance.GetComponent<HPBar>();
        if (hpBarScript != null)
        {
            hpBarScript.SetTarget(this.transform);
        }
        else
        {
            Debug.LogError("hpBarPrefab�� HPBar ��ũ��Ʈ�� �������� �ʽ��ϴ�!");
        }
    }
}
