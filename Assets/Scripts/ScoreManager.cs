using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static void Save_Time_Data(float score)
    {
        // 씬정보를 가져오기
        string ddd = GameInfoData.NowScene; // ddd엔 Level1이라는것이 들어감

        // 최고 점수 저장           key값으로 저장
        PlayerPrefs.SetFloat(ddd + "_HighScore", score);
        PlayerPrefs.Save(); // 저장

    }
}
