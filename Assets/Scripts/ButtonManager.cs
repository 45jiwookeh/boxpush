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

        // ���콺 ������ ��� + ����
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
        // ���� ���� ��: ���콺 �����ʹ� ���̰�
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� ���� ESC ������ �޴� ���ٰų�, GM.Playing�� false �Ǹ� �ٽ� ���콺 ���̰� �ϰ� �ʹٸ� ���⿡ �߰� ����
        // ����:
        // if (!GM.Playing)
        // {
        //     Cursor.lockState = CursorLockMode.None;
        //     Cursor.visible = true;
        // }
    }
}
