using UnityEngine;

public class TalkButton : MonoBehaviour
{
    [SerializeField, Header("提示對話圖示")] public GameObject TipTalkIcon;
    [SerializeField, Header("角色對話文本")] 對話文本 lines;
    //public GameObject talkUI;
    
    // 當 玩家 靠近NPC時 就顯示對話提示按鈕
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TipTalkIcon.SetActive(true);     //顯示對話提示按鈕
        }
    }

    // 當 玩家 離開NPC時 就隱藏對話提示按鈕
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TipTalkIcon.SetActive(false);    //隱藏對話提示按鈕
        }
    }

    private void Update()
    {
        HideUI();
    }

    /// <summary>
    /// 顯示對話介面，並執行開始對話
    /// </summary>
    public void HideUI()
    {
        if (TipTalkIcon.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            // 如果已經開始對話
            if (DialogSystem.instance.對話中 == false)
            {
                // 執行對話系統中的 開始對話
                DialogSystem.instance.開始對話(lines);
            }
        }
    }
}
