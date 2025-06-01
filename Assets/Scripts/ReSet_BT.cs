using UnityEngine;

public class ReSet_BT : MonoBehaviour
{
    public void Reset()
    {
        PlayerPrefs.DeleteKey(GameInfoData.NowScene + "HighScore");
        // 또는 전체 삭제
        // PlayerPrefs.DeleteAll();
    }
}
