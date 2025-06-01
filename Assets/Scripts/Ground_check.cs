using UnityEngine;

public class Ground_check : MonoBehaviour
{
    public Player_Move player_move;

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            player_move.isGround = true;
            Debug.Log("점프가능");
        }
    }
}
