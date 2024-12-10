using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static float cellSize = 1.0f; // �׸��� �� ũ��

    // ���� ��ǥ -> �׸��� ��ǥ ��ȯ
    public static Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        int row = Mathf.FloorToInt(worldPosition.y / cellSize);
        int col = Mathf.FloorToInt(worldPosition.x / cellSize);
        return new Vector2Int(row, col);
    }

    // �� ��ü�� ���� �׸��忡 �ִ��� Ȯ��
    public static bool IsSameGrid(Vector3 pos1, Vector3 pos2)
    {
        return GetGridPosition(pos1) == GetGridPosition(pos2);
    }
}
