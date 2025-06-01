using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameManager GM;

    public void GameStart()
    {
        GM.Playing = true;
        GM.GameStart_UI.SetActive(false);

        // 마우스 포인터 잠금 + 숨김
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReStart(){
        Scene NowScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(NowScene.name);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 게임 시작 전: 마우스 포인터는 보이게
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 게임 도중 ESC 눌러서 메뉴 연다거나, GM.Playing이 false 되면 다시 마우스 보이게 하고 싶다면 여기에 추가 가능
        // 예시:
        // if (!GM.Playing)
        // {
        //     Cursor.lockState = CursorLockMode.None;
        //     Cursor.visible = true;
        // }
    }
}
