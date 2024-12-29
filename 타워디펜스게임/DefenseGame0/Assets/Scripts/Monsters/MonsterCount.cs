using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCount : MonoBehaviour
{
    public static MonsterCount Instance; // Singleton으로 관리

    private int monsterCount = 0;        // 활성화된 몬스터의 수
    public Text monsterCountText;       // UI Text로 몬스터 카운트 표시

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
            monsterCountText.text = $"남은 몹: {monsterCount}";
        }
    }

    private void EndGame()
    {
        Debug.Log("게임 종료");
        Time.timeScale = 0;
        GameResult.Victory();
    }
}
