using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // �������� �˾� �̹���
    [SerializeField] GameObject exitMenu;

    private bool isPause;

    private void Start()
    {
        isPause = false;
    }


    // ���ۺ��� ��Ȱ��ȭ
    private void Awake()
    {
        exitMenu.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("Ŭ��");
        Time.timeScale = 0;
        exitMenu.SetActive(true);
    }

    public void Exitcancel()
    {
        Debug.Log("â�ݱ�");
        exitMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    // ���� Ŭ�� �� �Ͻ�����
    public void Pause()
    {
        if (isPause == false)
        {
            Debug.Log("�Ͻ�����");
            Time.timeScale = 0;
            isPause = true;
            return;
        }
        if (isPause == true)
        {
            Debug.Log("�Ͻ����� ����");
            Time.timeScale = 1;
            isPause = false;
            return;
        }
        
    }    
}
