using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image progressBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene"); // �� �ҷ�����
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    // �ڷ�ƾ ���
    IEnumerator LoadSceneProcess()
    {
        // ���� �񵿱�� �ҷ����� ��
        // ���� �ε��� ������ �ڵ����� �ҷ��� ������ �̵��� �������� ����
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;

        while (!op.isDone)
        {
            yield return null;
        
            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);

                if(progressBar.fillAmount >= 1f && Input.GetKeyDown(KeyCode.Space))
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
