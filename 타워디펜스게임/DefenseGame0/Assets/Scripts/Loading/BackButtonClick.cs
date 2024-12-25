using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnStage1Click()
    {
        SceneManager.LoadScene("GameScene");
    }
}
