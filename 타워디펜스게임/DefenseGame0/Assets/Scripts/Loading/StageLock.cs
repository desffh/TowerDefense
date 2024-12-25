using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageLock : MonoBehaviour
{
    // ���� �������� ��ȣ
    private int stage;

    // ����������
    private Button stageButton;

    private void Awake()
    {
        // ��ư �迭
        Button[] stages = GetComponentsInChildren<Button>();

        // Ű�� ��������
        stage = PlayerPrefs.GetInt("StageReached");

        // ������������ ��ư ������Ʈ ��Ȱ��ȭ
        for (int i = stage + 1; i < stages.Length; i++)
        {
            stages[i].interactable = false;
        }
    }

}
