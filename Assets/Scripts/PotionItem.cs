using UnityEngine;

public class PotionItem : MonoBehaviour
{
    public Player_Move player_move;
    public UI_ItemSlot uiItemSlot;

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            player_move.isJumping = true;
            Destroy(gameObject);

            uiItemSlot.AddItem("potion");
        }
    }
}
