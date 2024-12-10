using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static float cellSize = 1.0f; // 그리드 셀 크기

    // 월드 좌표 -> 그리드 좌표 변환
    public static Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        int row = Mathf.FloorToInt(worldPosition.y / cellSize);
        int col = Mathf.FloorToInt(worldPosition.x / cellSize);
        return new Vector2Int(row, col);
    }

    // 두 객체가 같은 그리드에 있는지 확인
    public static bool IsSameGrid(Vector3 pos1, Vector3 pos2)
    {
        return GetGridPosition(pos1) == GetGridPosition(pos2);
    }
}
