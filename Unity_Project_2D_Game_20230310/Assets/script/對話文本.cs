using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ScriptableObject 自訂物件

[CreateAssetMenu(fileName = "New_File", menuName = "Create_New_File")]
public class 對話文本 : ScriptableObject
{
    // 表單
    public List<話> 對話列表;
}

[System.Serializable]
public struct 話
{
    public bool 左邊角色;
    public Sprite 角色圖示_左;
    public Sprite 角色圖示_右;
    public string 角色名稱;
    [TextArea(2, 5)] public string 文本內容;
}
