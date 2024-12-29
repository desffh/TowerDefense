using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] GameObject ClearPanel;

    [SerializeField] GameObject LosePanel;

    // ù ���� ��Ȱ��ȭ
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
