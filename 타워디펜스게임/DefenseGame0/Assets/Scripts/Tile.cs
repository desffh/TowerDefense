using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool hasUnits;

    public static GameObject[,] grid;

    static int gridRows = 5; // 세로
    static int gridColumns = 10; // 가로

    // 배치된 유닛 오브젝트를 저장하는 변수
    public GameObject placedUnit;

    public Sprite PlacedUnitSprite;


    private void Awake()
    {
         grid = new GameObject[gridRows,gridColumns];

        // 각 칸의 Square 오브젝트를 배열에 저장
        for (int row = 0; row < gridRows; row++)
        {
            for (int col = 0; col < gridColumns; col++)
            {
                // 오브젝트를 직접 찾거나 생성
                GameObject square = GameObject.Find($"Square_{row}_{col}");
                if (square != null)
                {
                    grid[row, col] = square;
                }
            }
        }
    }

    // 코루틴 사용해서 hasUnit이 1초뒤에 true가 되게
    IEnumerator HasUnitActive()
    {
        yield return new WaitForSeconds(0.5f);

        hasUnits = true;
    }

    // 유닛(이미지, 오브젝트)를 타일에 저장하는 함수
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
    // 유닛 가져오기
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
            placedUnit.transform.position = hiddenTile.position; // 대기 타일로 이동
        }
    }
}
