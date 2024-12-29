using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCount : MonoBehaviour
{
    public static MonsterCount Instance; // Singleton���� ����

    private int monsterCount = 0;        // Ȱ��ȭ�� ������ ��
    public Text monsterCountText;       // UI Text�� ���� ī��Ʈ ǥ��

    GameResult GameResult;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateMonsterCountUI();
        GameResult = gameObject.GetComponent<GameResult>();
    }

    public void IncreaseCount()
    {
        monsterCount++;
        UpdateMonsterCountUI();
    }

    public void DecreaseCount()
    {
        monsterCount--;
        UpdateMonsterCountUI();

        if (monsterCount <= 0)
        {
            EndGame();
        }
    }

    private void UpdateMonsterCountUI()
    {
        if (monsterCountText != null)
        {
            monsterCountText.text = $"���� ��: {monsterCount}";
        }
    }

    private void EndGame()
    {
        Debug.Log("���� ����");
        Time.timeScale = 0;
        GameResult.Victory();
    }
}
