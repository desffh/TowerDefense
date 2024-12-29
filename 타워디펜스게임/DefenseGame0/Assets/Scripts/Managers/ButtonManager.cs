using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // 게임중지 팝업 이미지
    [SerializeField] GameObject exitMenu;

    private bool isPause;

    private void Start()
    {
        isPause = false;
    }


    // 시작부터 비활성화
    private void Awake()
    {
        exitMenu.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("클릭");
        Time.timeScale = 0;
        exitMenu.SetActive(true);
    }

    public void Exitcancel()
    {
        Debug.Log("창닫기");
        exitMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    // 정지 클릭 시 일시정지
    public void Pause()
    {
        if (isPause == false)
        {
            Debug.Log("일시정지");
            Time.timeScale = 0;
            isPause = true;
            return;
        }
        if (isPause == true)
        {
            Debug.Log("일시정지 해제");
            Time.timeScale = 1;
            isPause = false;
            return;
        }
        
    }    
}
