using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // 게임중지 팝업 이미지
    [SerializeField] GameObject exitMenu;


    // 시작부터 비활성화
    private void Awake()
    {
        exitMenu.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("클릭");
        exitMenu.SetActive(true);
    }

    public void Exitcancel()
    {
        Debug.Log("창닫기");
        exitMenu.SetActive(false);
    }

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
