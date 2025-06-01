using UnityEngine;

public class oBject_Tracking : MonoBehaviour
{
    public Transform target_obj;
    public float distance = 8.0f;
    public float height = 3.0f;
    public float rotationSpeed = 5.0f;

    private float currentX = 0f;
    private float currentY = 0f;

    public float minY = -20f;
    public float maxY = 60f;

    void LateUpdate()
    {
        if (target_obj == null) return;

        // 마우스 입력 받기
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, minY, maxY); // 위아래 각도 제한

        // 회전 계산
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = new Vector3(0, 0, -distance);
        Vector3 position = rotation * direction + target_obj.position + new Vector3(0, height, 0);

        transform.position = position;
        transform.LookAt(target_obj);
    }
}
