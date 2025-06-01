using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float speed = 50f;
    Transform target;
    void Start()
    {
        // 하이라키 이름으로 검색
        target = GameObject.Find("CubeEndPoint").transform;
        //target = GameObject.FindWithTag("CloudsEndPoint").transform;
        if (target == null)
        {
            Debug.LogError("Target not found!");
            return;
        }
    }
    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) < 0.1f){
            Destroy(gameObject);
        }
    }
}
