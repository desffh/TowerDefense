using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitCount : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI totalUnitText;

    

    [SerializeField] int unitCount;

    private Tile tile;


    private void Start()
    {
        unitCount = 0;
    }

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
                    unitCount++;
                    break;
                }
            }
        }

        Debug.Log($"유닛 카운트: {unitCount}");


        // UI 업데이트
        UpdateUI();
    }


    public void UpdateUI()
    {
        // Hierarchy창에서 UnitCount_Text 오브젝트 찾아서 코스트 갱신
        GameObject.Find("UnitCount_Text").GetComponent<TextMeshProUGUI>().text = unitCount.ToString();
    }
}
