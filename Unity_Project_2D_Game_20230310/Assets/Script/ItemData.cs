using UnityEngine;

/// <summary>
/// 道具系統：建立道具的資料格式
/// </summary>
[CreateAssetMenu(fileName ="新道具", menuName ="建立新道具")]
public class ItemData : ScriptableObject
{
    // ScriptableObject = 把資料物件化
    public string userInput;
    const string PlayerPrefsKey = "UserInputKey";
    // 共同
    [Header("道具ID")]
    public int id;                      // 道具ID
    [Header("道具名稱")]
    public string title;                // 道具標題
    [Header("道具圖示")]
    public Sprite icon;                 // 道具圖示
    [Header("道具說明"), TextArea(5, 5)]
    public string info; // 道具敘述
    [Header("道具可否使用")]
    public bool canUse;                 // 是否可使用
    [Header("道具是否會消耗")]
    public bool Consumables;            // 使用後是否會消耗
    [Header("道具顏色")]
    public Color category;              // 類別的顏色

    // 個別
    // public float regainHp;   // 回血
    // public float regainMp;   // 補魔
    [Header("恢復體力值")]
    public float regainStr;  // 回體力

    // 在 Awake 時設定預設值
    // 如果使用者有輸入值 則讀取使用者的值
    // 如果使用者沒有輸入值 則值為預設值
    private void Awake()
    {
        if (PlayerPrefs.HasKey(userInput))
        {
            userInput = PlayerPrefs.GetString(PlayerPrefsKey);
        }
        else
        {
            title = "未命名";
            info = "無敘述";
            canUse = false;
            Consumables = false;
            regainStr = 0f;
        }
    }

    public void SaveUserInput(string value)
    {
        userInput = value;
        PlayerPrefs.SetString(PlayerPrefsKey, userInput);
    }
}
