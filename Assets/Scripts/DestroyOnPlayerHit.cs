using UnityEngine;

// "Player" �±׿� �浹 �� �Ҹ� ��� �� ��ü ����
public class DestroyOnPlayerHit : MonoBehaviour
{
    public AudioClip explosion; // �ν����Ϳ� ���� ���� Ŭ��
    public GameObject soundPrefab; // ���� ����� ������Ʈ ������ (������ �ڵ�� ����)

    private bool isTriggered = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!isTriggered && collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;

            // 1. �Ҹ� ����� ������Ʈ ����
            GameObject go = new GameObject("ExplosionSound");
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = explosion;
            source.Play();

            Destroy(go, explosion.length); // ���� ������ ����

            // 2. ��ü ����
            Destroy(gameObject);
        }
    }
}
