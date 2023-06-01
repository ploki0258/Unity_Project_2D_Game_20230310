using UnityEngine;

/// <summary>
/// 道具系統：建立道具的資料格式
/// </summary>
[CreateAssetMenu(fileName ="新道具", menuName ="建立新道具")]
public class ItemData : ScriptableObject
{
    // ScriptableObject = 把資料物件化

    // 共同
    public int id;                      // ID
    public string title;                // 標題
    public Sprite icon;                 // 圖示
    [TextArea(5,5)] public string info; // 敘述
    public bool canUse;                 // 是否可使用
    public bool Consumables;            // 使用後是否會消耗
    public Color category;              // 類別的顏色

    // 個別
    // public float regainHp;   // 回血
    // public float regainMp;   // 補魔
    public float regainStr;  // 回體力

    // 在 Awake 時設定預設值
    /*private void Awake()
    {
        title = "未命名";
        info = "無敘述";
        canUse = false;
        Consumables = false;
    }
    */
}
