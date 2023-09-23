using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 道具管理器
/// </summary>
public class ItemManager
{
    #region 單例
    public static ItemManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new ItemManager();
            return _instance;
        }
    }
    static ItemManager _instance = null;
    #endregion

    // 將所有道具放在一個陣列中
    public ItemData[] AllItem = new ItemData[0];

    /// <summary>
    /// 初始化道具：把所有道具放進資料庫內
    /// </summary>
    public void 初始化()
    {
        // 從專案中找出所有道具資料
        AllItem = Resources.LoadAll<ItemData>("");
    }

    /// <summary>
    /// 找道具資料：依照ID尋找
    /// </summary>
    /// <param name="id">道具編號</param>
    /// <returns></returns>
    public ItemData FindItemData(int id)
    {
        for (int i = 0; i < AllItem.Length; i++)
        {
            if (AllItem[i].id == id)
            {
                return AllItem[i];
            }
        }
        Debug.LogError("ID：" + id + "查無此ID");
        return new ItemData();
    }
}
