using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 對話系統
/// </summary>
public class DialogSystem : MonoBehaviour
{
    // 將 DialogSystem 設定為單例模式
    public static DialogSystem instance = null;

    [SerializeField, Header("角色圖示 左")] Image 角色圖示_左 = null;
    [SerializeField, Header("角色圖示 右")] Image 角色圖示_右 = null;
    [SerializeField, Header("對話人名 左")] Text 對話人名_左 = null;
    [SerializeField, Header("對話人名 右")] Text 對話人名_右 = null;
    [SerializeField, Header("對話內容")] Text 對話內容 = null;
    [SerializeField, Header("提示繼續圖示")] Transform 繼續提示 = null;
    [SerializeField, Header("對話框")] CanvasGroup talkUI;
    //[SerializeField, Header("角色對話文本")] 對話文本 測試文本 = null;
    //[SerializeField, Header("提示對話圖示")] GameObject Button;

    對話文本 當前文本;
    public bool 對話中 = false;  // 是否在對話
    bool pressEnter = false;    // 是否按了繼續
    bool wait = false;          // 是否在等待
    
    private void Awake()
    {
        instance = this;    // 讓單例等於自己
        talkUI.alpha = 0f;  // 一開始隱藏對話框 α值為0
    }

    /// <summary>
    /// 開始對話
    /// </summary>
    /// <param name="文本">文本內容</param>
    public void 開始對話(對話文本 文本)
    {
        // 如果正在對話就忽略此命令
        if (對話中 == true)
        {
            // Debug.Log("已經在對話了");
            return;
        }
        // 取得文本 (當前文本 等於 傳入的文本)
        當前文本 = 文本;
        // 開始異步執行對話
        StartCoroutine(對話());
    }

    IEnumerator 對話()
    {
        對話中 = true;
        talkUI.alpha = 1f;
        // 顯示正在對話的角色名稱
        // 對話人名.text = 當前文本.表[0].角色名稱;
        // 顯示正在對話的角色圖示
        // 如果是左邊的角色 就顯示角色圖示左
        // 如果是右邊的角色 就顯示角色圖示右
        // 條件 ? 成立做的事情 : 不成立做的事情
        角色圖示_左.sprite = 當前文本.對話列表[0].左邊角色 ? 當前文本.對話列表[0].角色圖示_左 : null;
        角色圖示_右.sprite = 當前文本.對話列表[0].左邊角色 ? null : 當前文本.對話列表[0].角色圖示_右;

        // 角色圖示左.transform.localScale = 如果角色圖示左為 null 就隱藏 否則就顯示
        // 角色圖示右.transform.localScale = 如果角色圖示右為 null 就隱藏 否則就顯示
        角色圖示_左.transform.localScale = (角色圖示_左.sprite == null) ? Vector3.zero : Vector3.one;
        角色圖示_右.transform.localScale = (角色圖示_右.sprite == null) ? Vector3.zero : Vector3.one;
		#region 測試
		/*
        if (當前文本.表[0].左邊角色 == true)
        {
            角色圖示_左 = 當前文本.表[0].角色圖示左;
        }
        else if(當前文本.表[0].左邊角色 == false)
        {
            角色圖示_右 = 當前文本.表[0].角色圖示右;
        }
        */
		#endregion

		// 如果是左邊的人名 就顯示人名在左邊的文字方塊中 如果不是就填入空白
		對話人名_左.text = 當前文本.對話列表[0].左邊角色 ? 當前文本.對話列表[0].角色名稱 : "";
        對話人名_右.text = 當前文本.對話列表[0].左邊角色 ? "" : 當前文本.對話列表[0].角色名稱;
        對話內容.text = "";
        繼續提示.localScale = Vector3.zero;
        //等待0.5秒
        yield return new WaitForSeconds(0.5f);

        // 對話總表
        for (int j = 0; j < 當前文本.對話列表.Count; j++)
        {
            // 開始這句話之前設定好人名並且關閉提示
            角色圖示_左.sprite = 當前文本.對話列表[j].左邊角色 ? 當前文本.對話列表[j].角色圖示_左 : null;
            角色圖示_右.sprite = 當前文本.對話列表[j].左邊角色 ? null : 當前文本.對話列表[j].角色圖示_右;

            角色圖示_左.transform.localScale = (角色圖示_左.sprite == null) ? Vector3.zero : Vector3.one;
            角色圖示_右.transform.localScale = (角色圖示_右.sprite == null) ? Vector3.zero : Vector3.one;

            對話人名_左.text = 當前文本.對話列表[j].左邊角色 ? 當前文本.對話列表[j].角色名稱 : "";
            對話人名_右.text = 當前文本.對話列表[j].左邊角色 ? "" : 當前文本.對話列表[j].角色名稱;
            繼續提示.localScale = Vector3.zero;
            //逐步顯示每一個字到畫面上
            string textFinal = "";
            for (int i = 0; i < 當前文本.對話列表[j].文本內容.Length; i++)
            {
                // 有幾個字跑幾個迴圈
                textFinal = textFinal + 當前文本.對話列表[j].文本內容[i];
                // 顯示到畫面上
                對話內容.text = textFinal;
                yield return new WaitForSeconds(0.05f);
            }
            // 顯示繼續提示 讓玩家按了繼續
            繼續提示.localScale = Vector3.one;
            // 按下Enter繼續開始下段對話
            wait = true;
            while (pressEnter == false)
            {
                yield return new WaitForSeconds(0.1f);
            }
            wait = false;
            pressEnter = false;
        }

        talkUI.alpha = 0f;
        yield return new WaitForSeconds(0.5f);
        對話中 = false;
    }

    private void Update()
    {
        // 按 Enter 繼續下段對話
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && wait == true)
        {
            pressEnter = true;
        }
    }
}
