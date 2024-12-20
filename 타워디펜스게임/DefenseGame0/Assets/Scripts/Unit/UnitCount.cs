using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitCount : MonoBehaviour
{
    TextMeshProUGUI totalUnitText; // ���� ī��Ʈ �� �ؽ�Ʈ

    [SerializeField] TextMeshProUGUI totalUnit;

    static public int unitCount;

    public int totalCount;

    private Tile tile;


    private void Start()
    {
        totalUnitText = GetComponent<TextMeshProUGUI>();

        unitCount = 0; // ���� ���� ī��Ʈ

        totalCount = 7; // �Ѱ� ���� ī��Ʈ
    }

    // Ÿ�Ͽ� ��ġ�� ������Ʈ�� �����ϰ�, ������ ��ġ�������� 
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
                    if(unitCount < totalCount)
                    {
                        unitCount += 1;
                        break;
                    }
                }
            }
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
