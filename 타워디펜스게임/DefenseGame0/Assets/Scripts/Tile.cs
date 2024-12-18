using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool hasUnits;

    public bool hasMonsters;

    public static GameObject[,] grid;

    static int gridRows = 5; // ����
    static int gridColumns = 10; // ����

    // ��ġ�� ���� ������Ʈ�� �����ϴ� ����
    public GameObject placedUnit;

    public Sprite PlacedUnitSprite;


    private void Awake()
    {
         grid = new GameObject[gridRows,gridColumns];

        // �� ĭ�� Square ������Ʈ�� �迭�� ����
        for (int row = 0; row < gridRows; row++)
        {
            for (int col = 0; col < gridColumns; col++)
            {
                // ������Ʈ�� ���� ã�ų� ����
                GameObject square = GameObject.Find($"Square_{row}_{col}");
                if (square != null)
                {
                    grid[row, col] = square;
                }
            }
        }
    }

    // ����(�̹���, ������Ʈ)�� Ÿ�Ͽ� �����ϴ� �Լ�
    public void PlaceUnit(GameObject unit, Sprite UnitSprite)
    {
        hasUnits = true;
        placedUnit = unit;
        PlacedUnitSprite = UnitSprite;
    }

    // ���� ��������
    public GameObject GetplacedUnit()
    {
        return placedUnit;
    }

    public Sprite GetplacedUnitSprite()
    {
        return PlacedUnitSprite;
    }

    // public void RemoveUnit()
    // {
    //     if (placedUnit != null)
    //     {
    //         
    //         placedUnit = null;
    //         hasUnits = false;
    //     }
    // }

    public void MoveUnitToHiddenTile(Transform hiddenTile)
    {
        if (placedUnit != null)
        {
            placedUnit.transform.position = hiddenTile.position; // ��� Ÿ�Ϸ� �̵�
        }
    }
}
