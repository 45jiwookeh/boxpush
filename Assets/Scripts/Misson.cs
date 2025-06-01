using UnityEngine;

public class Misson : MonoBehaviour
{
    public static Misson instance;
    public bool isPaused;
    public GameObject Misson_UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(instance == null)
        {
            isPaused = false;
            Misson_UI.SetActive(true);
            instance = this;
        }
    }

    public void GameStart()
    {
        isPaused = true;
        Misson_UI.SetActive(false);
        instance = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused == false)
        {
            Time.timeScale = 0;
            return;
        }
        if(isPaused == true)
        {
            Time.timeScale = 1;
            return;
        }
    }
}
