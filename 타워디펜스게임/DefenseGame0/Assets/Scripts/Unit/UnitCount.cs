using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitCount : MonoBehaviour
{
    TextMeshProUGUI totalUnitText; // 유닛 카운트 수 텍스트

    [SerializeField] TextMeshProUGUI totalUnit;

    static public int unitCount;

    public int totalCount;

    private Tile tile;


    private void Start()
    {
        totalUnitText = GetComponent<TextMeshProUGUI>();

        unitCount = 0; // 현재 유닛 카운트

        totalCount = 7; // 한계 유닛 카운트
    }

    // 타일에 배치된 오브젝트가 존재하고, 유닛이 배치되있을때 
    public void Counting()
    {

        if (Tile.grid == null)
        {
            Debug.LogError("Tile이 초기화되지 않았습니다.");
            return;
        }

        for (int row = 0; row < Tile.grid.GetLength(0); row++)
        {
            for (int col = 0; col < Tile.grid.GetLength(1); col++)
            {
                GameObject tileObject = Tile.grid[row, col];
                
                if (tileObject != null && tileObject.GetComponent<Tile>().hasUnits)
                {
                    if(unitCount < totalCount)
                    {
                        unitCount += 1;
                        break;
                    }
                }
            }
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
