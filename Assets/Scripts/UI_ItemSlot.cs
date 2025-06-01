using UnityEngine;
using UnityEngine.UI;

public class UI_ItemSlot : MonoBehaviour
{
    public Image[] itemSlots; // 이미지 배열 제작
    public int SlotIndex = 0; // 나중에 외부에서 써야됨. 그래서 private에서 public으로 바꿈
    // 인덱스정보. 인덱스 카운트를 세기 위해서

    public void AddItem(string itemName)
    {
        if (SlotIndex < itemSlots.Length)
        {
            itemSlots[SlotIndex].color = Color.white;
            itemSlots[SlotIndex].sprite = Resources.Load<Sprite>("img/slot01");
            SlotIndex++;
        }
        else
        {
            Debug.Log("정상실행");
        }
    }
}
