using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource bgmSource;

    void Start()
    {
        if (bgmSource != null)
        {
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }
}
