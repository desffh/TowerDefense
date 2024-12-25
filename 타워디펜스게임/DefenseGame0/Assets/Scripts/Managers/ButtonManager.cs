using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // �������� �˾� �̹���
    [SerializeField] GameObject exitMenu;


    // ���ۺ��� ��Ȱ��ȭ
    private void Awake()
    {
        exitMenu.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("Ŭ��");
        exitMenu.SetActive(true);
    }

    public void Exitcancel()
    {
        Debug.Log("â�ݱ�");
        exitMenu.SetActive(false);
    }

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
