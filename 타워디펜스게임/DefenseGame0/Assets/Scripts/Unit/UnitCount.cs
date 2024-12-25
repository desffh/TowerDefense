using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitCount : MonoBehaviour
{
    TextMeshProUGUI totalUnitText; // ���� ī��Ʈ �� �ؽ�Ʈ

    [SerializeField] TextMeshProUGUI totalUnit;

    static public int unitCount; // ���� ���� ī��Ʈ static

    public int totalCount;

    private Tile tile;


    private void Awake()
    {
        totalUnitText = GetComponent<TextMeshProUGUI>();

        unitCount = 0; // ���� ���� ī��Ʈ (���� �� 0)

        totalCount = 7; // �Ѱ� ���� ī��Ʈ
    }

    // ������ ��ġ�ɶ�
    public void Counting()
    {

        if (unitCount < totalCount)
        {
            unitCount += 1;
        }
        Debug.Log($"���� ī��Ʈ: {unitCount}");
    
    
        // UI ������Ʈ
        UpdateUI();
    }

    // ������ ��ġ����������
    public void DelCounting()
    {

        if (unitCount <= totalCount)
        {
            unitCount -= 1;
        }
        Debug.Log($"���� ī��Ʈ: {unitCount}");


        // UI ������Ʈ
        UpdateUI();
    }


    


    // ���� ��ġ�� ����ī��Ʈ
    public int GetUnitCount()
    {
        return unitCount;
    }

    // �ִ� ��ġ�� �� �ִ� ����ī��Ʈ
    public int GetUnitTotalCount()
    {
        return totalCount;
    }

    public void UpdateUI()
    {
        // Hierarchyâ���� UnitCount_Text ������Ʈ ã�Ƽ� �ڽ�Ʈ ����
        GameObject.Find("UnitCount_Text1").GetComponent<TextMeshProUGUI>().text = unitCount.ToString();
    }
}
