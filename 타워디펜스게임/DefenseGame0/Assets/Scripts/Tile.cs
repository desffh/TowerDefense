using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool hasUnits;

    public bool hasMonsters;

    public static GameObject[,] grid;

    static int gridRows = 5; // 세로
    static int gridColumns = 10; // 가로

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

}
