using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfoData : MonoBehaviour
{
    public static string NowScene; // static을 적는이유: 메모리 효율성, 모든 인스턴스가 동일한 값을 공유.
    void Start()
    {
        NowScene = SceneManager.GetActiveScene().name;
    }

    public static void Load_NextScene()
    {
        // 현재 씬 인덱스 정도 받기
        int nowSceneIndex = SceneManager.GetActiveScene().buildIndex; //buildIndex; 빌드 인덱스 정보 불러오기
        // 현재 인덱스에서 +1 씬으로 이동
        SceneManager.LoadScene(nowSceneIndex + 1);
    }
}
