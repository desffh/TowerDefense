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
            Debug.LogError("Tile�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
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

        Debug.Log($"���� ī��Ʈ: {unitCount}");


        // UI ������Ʈ
        UpdateUI();
    }


    public void UpdateUI()
    {
        // Hierarchyâ���� UnitCount_Text ������Ʈ ã�Ƽ� �ڽ�Ʈ ����
        GameObject.Find("UnitCount_Text").GetComponent<TextMeshProUGUI>().text = unitCount.ToString();
    }
}
