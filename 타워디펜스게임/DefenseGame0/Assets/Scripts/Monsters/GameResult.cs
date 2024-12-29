using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] GameObject ClearPanel;

    [SerializeField] GameObject LosePanel;

    // 첫 셋팅 비활성화
    private void Awake()
    {
        ClearPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    public void Victory()
    {
        ClearPanel.SetActive(true);
    }
    
    public void Lose()
    {
        LosePanel.SetActive(true);
    }
}
