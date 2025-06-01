using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubess;
    public float spawnTimeMin = 5f;
    public float spawnTimeMax = 8f;
    float nextTime;

    public float Position_X = -800f;
    public float Position_Z = 0f;
    public float randomYMin = 110f;
    public float randomYMax = 140f;
    float randomY;

    void Start()
    {
        //함수 실행 예약
        nextTime = Random.Range(spawnTimeMin, spawnTimeMax);
        Invoke("SpawnCube", nextTime);
    }

    void SpawnCube()
    {
        randomY = Random.Range(randomYMin, randomYMax);
        Vector3 spawnPos = new Vector3(Position_X, randomY, Position_Z);
        //오브젝트 생성
        Instantiate(cubess, spawnPos, Quaternion.identity);

        //다음 생성 예약
        nextTime = Random.Range(spawnTimeMin, spawnTimeMax);
        Invoke("SpawnCube", nextTime);
    }
}
