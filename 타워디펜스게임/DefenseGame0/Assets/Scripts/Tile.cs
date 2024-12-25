using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool hasUnits;

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

    // �ڷ�ƾ ����ؼ� hasUnit�� 1�ʵڿ� true�� �ǰ�
    IEnumerator HasUnitActive()
    {
        yield return new WaitForSeconds(0.5f);

        hasUnits = true;
    }

    // ����(�̹���, ������Ʈ)�� Ÿ�Ͽ� �����ϴ� �Լ�
    public void PlaceUnit(GameObject unit, Sprite UnitSprite)
    {
        StartCoroutine(HasUnitActive());
        placedUnit = unit;
        PlacedUnitSprite = UnitSprite;

        if (unit == null && UnitSprite == null)
        {
            hasUnits = false;
        }
    }

    public void MoveTileUnit(GameObject unit,Sprite UnitSprite)
    {
        placedUnit = unit;
        PlacedUnitSprite = UnitSprite;

        if (unit == null && UnitSprite == null)
        {
            hasUnits = false;
        }
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


    public void MoveUnitToHiddenTile(Transform hiddenTile)
    {
        if (placedUnit != null)
        {
            placedUnit.transform.position = hiddenTile.position; // ��� Ÿ�Ϸ� �̵�
        }
    }
}
