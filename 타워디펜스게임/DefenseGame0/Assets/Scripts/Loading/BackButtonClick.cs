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
        // ��ư ù ���� ��Ȱ��ȭ 
        stage1.gameObject.SetActive(false);
        stage2.gameObject.SetActive(false);
    }

    public void Stage1Click()
    {
        stage1.gameObject.SetActive(true);
        stage1.interactable = true;
    }
    public void Stage2Click()
    {
        stage2.gameObject.SetActive(true);
        stage2.interactable = true;
    }

    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Stage1StartClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
