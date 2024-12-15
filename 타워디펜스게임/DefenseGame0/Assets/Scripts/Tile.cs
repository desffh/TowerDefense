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

}
