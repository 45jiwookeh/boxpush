using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    // 이동 속도, 점프력, 상태 변수
    public int speed;
    public float jump;
    public bool isJumping = false;
    public bool isGround = false;

    int power;
    int damage;
    public int life;

    Vector3 Look; // 바라보는 방향
    public GameManager GM;
    public UI_ItemSlot ui_itemSlot;

    public Vector3 ptcset = new Vector3(); // 파티클 위치 보정용

    [SerializeField]
    ParticleSystem move_ptc; // 이동 시 파티클 효과

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 연결
    }

    void Move2()
    {
        // 키 입력 받기
        float inputZ = Input.GetAxisRaw("Vertical");   // W/S, ↑/↓
        float inputX = Input.GetAxisRaw("Horizontal"); // A/D, ←/→

        // 카메라 기준 방향 계산 (y = 0 으로 수평 방향만 사용)
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // 카메라 방향 기준 입력 방향
        Vector3 inputDir = (camForward * inputZ + camRight * inputX).normalized;

        // 방향 입력이 있을 때
        if (inputDir.magnitude > 0.1f)
        {
            if (!move_ptc.isPlaying)
                move_ptc.Play(); // 파티클 재생

            Look = inputDir; // 바라보는 방향 갱신
            Quaternion targetRotation = Quaternion.LookRotation(Look); // 회전 각도 계산
            rb.MoveRotation(targetRotation); // 회전 적용

            // 이동 벡터 계산 후 적용 (y속도 유지)
            Vector3 moveVelocity = inputDir * speed;
            rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
        }
        else
        {
            if (move_ptc.isPlaying)
                move_ptc.Stop(); // 입력 없으면 파티클 멈춤

            // 가만히 있을 땐 수평 속도 제거
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    void Update()
    {
        // 게임 진행 중일 때만 이동 및 점프 처리
        if (GM.Playing)
        {
            Move2();

            // 점프 처리
            if (isGround && !isJumping && Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                isGround = false;
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse); // 점프 힘 가함
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 땅에 닿았을 때 점프 상태 초기화
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            isJumping = false;
        }
    }

    void LateUpdate()
    {
        // 이동 파티클 위치, 방향 조정
        move_ptc.transform.position = this.transform.position + ptcset;
        move_ptc.transform.rotation = Quaternion.LookRotation(-this.transform.forward);
    }
}
