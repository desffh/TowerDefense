using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitCount : MonoBehaviour
{
    TextMeshProUGUI totalUnitText; // 유닛 카운트 수 텍스트

    [SerializeField] TextMeshProUGUI totalUnit;

    static public int unitCount; // 현재 유닛 카운트 static

    public int totalCount;

    private Tile tile;


    private void Awake()
    {
        totalUnitText = GetComponent<TextMeshProUGUI>();

        unitCount = 0; // 현재 유닛 카운트 (시작 시 0)

        totalCount = 7; // 한계 유닛 카운트
    }

    // 유닛이 배치될때
    public void Counting()
    {

        if (unitCount < totalCount)
        {
            unitCount += 1;
        }
        Debug.Log($"유닛 카운트: {unitCount}");
    
    
        // UI 업데이트
        UpdateUI();
    }

    // 유닛이 배치되지않을때
    public void DelCounting()
    {

        if (unitCount <= totalCount)
        {
            unitCount -= 1;
        }
        Debug.Log($"유닛 카운트: {unitCount}");


        // UI 업데이트
        UpdateUI();
    }


    


    // 현재 배치된 유닛카운트
    public int GetUnitCount()
    {
        return unitCount;
    }

    // 최대 배치할 수 있는 유닛카운트
    public int GetUnitTotalCount()
    {
        return totalCount;
    }

    public void UpdateUI()
    {
        // Hierarchy창에서 UnitCount_Text 오브젝트 찾아서 코스트 갱신
        GameObject.Find("UnitCount_Text1").GetComponent<TextMeshProUGUI>().text = unitCount.ToString();
    }
}
