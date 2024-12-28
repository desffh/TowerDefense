using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonClick : MonoBehaviour
{
    [SerializeField] Button stage1;

    [SerializeField] Button stage2;

    private void Awake()
    {
        stage1.gameObject.SetActive(false);
        stage2.gameObject.SetActive(false);
    }


    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnStage1Click()
    {
        SceneManager.LoadScene("GameScene");
    }
}
