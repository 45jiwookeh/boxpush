using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int BoxCount = 0;
    public int finishBoxCount = 0;
    public float BC_Time = 0f;
    public bool Playing = false;
    private bool GameOver = false;

    public Text GameTime;
    public TextMeshProUGUI RcTime;
    public TextMeshProUGUI FallenBoxCnt;
    public TextMeshProUGUI Text_NewRecord;

    public GameObject finishBoxs;
    public int FinishBox = 24;

    public GameObject Restart_UI;
    public GameObject Success_UI;
    public GameObject GameStart_UI;

    void Start()
    {
        GameOver = false;
        Playing = false;

        BoxCount = 0;
        finishBoxCount = 0;

        Restart_UI.SetActive(false);
        Success_UI.SetActive(false);
        GameStart_UI.SetActive(true);
        Text_NewRecord.gameObject.SetActive(false);

        UpdateBoxCount();
        UpdateUI();
    }

    void Update()
    {
        if (Playing && !GameOver)
        {
            BC_Time += Time.deltaTime;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        GameTime.text = "시간: " + BC_Time.ToString("F2");
        FallenBoxCnt.text = "상자: " + finishBoxCount + " / " + FinishBox;
    }

    void UpdateBoxCount()
    {
        finishBoxCount = BoxCount;
    }

    public void StartGame()
    {
        GameOver = false;
        Playing = true;

        BC_Time = 0f;
        BoxCount = 0;
        finishBoxCount = 0;

        Restart_UI.SetActive(false);
        Success_UI.SetActive(false);
        GameStart_UI.SetActive(false);
        Text_NewRecord.gameObject.SetActive(false);

        UpdateUI();
    }

    // 트리거 충돌 처리
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BOX"))
        {
            BoxCount++;
            UpdateBoxCount();
            Debug.Log("상자 닿음: " + BoxCount);
        }

        if ((other.CompareTag("Player") || other.CompareTag("NoBox")) && !GameOver)
        {
            GameOver = true;
            Playing = false;
            Restart_UI.SetActive(true);
            Debug.Log("게임 오버");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (finishBoxCount >= FinishBox && !GameOver)
        {
            GameOver = true;
            Playing = false;
            Success_UI.SetActive(true);
            RcTime.text = BC_Time.ToString("F2");
            Text_NewRecord.gameObject.SetActive(true);
            Text_NewRecord.text = "새로운 기록: " + BC_Time.ToString("F2");
            Debug.Log("게임 클리어");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
