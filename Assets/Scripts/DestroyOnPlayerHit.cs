using UnityEngine;

// "Player" 태그와 충돌 시 소리 재생 후 본체 제거
public class DestroyOnPlayerHit : MonoBehaviour
{
    public AudioClip explosion; // 인스펙터에 넣을 사운드 클립
    public GameObject soundPrefab; // 사운드 재생용 오브젝트 프리팹 (없으면 코드로 생성)

    private bool isTriggered = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!isTriggered && collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;

            // 1. 소리 재생용 오브젝트 생성
            GameObject go = new GameObject("ExplosionSound");
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = explosion;
            source.Play();

            Destroy(go, explosion.length); // 사운드 끝나면 삭제

            // 2. 본체 제거
            Destroy(gameObject);
        }
    }
}
