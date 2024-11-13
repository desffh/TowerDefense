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
        SceneManager.LoadScene("LoadingScene"); // 씬 불러오기
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    // 코루틴 사용
    IEnumerator LoadSceneProcess()
    {
        // 씬을 비동기로 불러들일 때
        // 씬의 로딩이 끝나면 자동으로 불러온 씬으로 이동할 것인지를 설정
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
