using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    #region 單例
    public static SaveManager instance
    {
        // 當有人需要我
        get
        {
            // 如果我不存在
            if (_instance == null)
            {
                // 就自己創造自己
                _instance = new SaveManager();
            }
            // 回傳自己
            return _instance;
        }
    }
    // 記憶體實際的位置
    static SaveManager _instance = null;
    #endregion

    [Header("最大持有道具數量")]
    [SerializeField] int itemNumberMax = 999;

    // 持有物品列表
    public List<Goods> goodsList = new List<Goods>();

    // 道具發生變化：新增、減少
    public System.Action Act_goodsChange;

    /// <summary>
    /// 添加道具(By ID)
    /// </summary>
    /// <param name="id">道具編號</param>
    public bool addItem(int id)
    {
        // 如果已經有道具 就累計
        if (checkItem(id) > 0)
        {
            // 掃描所有道具
            for (int i = 0; i < goodsList.Count; i++)
            {
                // 如果遇到相同ID的道具 且目前持有數量 <= 最大持有數量 就只單純增加數量
                if (goodsList[i].id == id && goodsList[i].number <= itemNumberMax)
                {
                    Goods temp = goodsList[i];  // 複製一個陣列
                    temp.number++;              // 將複製的陣列進行修改
                    goodsList[i] = temp;        // 將修改後的陣列覆蓋回去
                    break;                      // 已成功完成堆疊 結束迴圈
                }
            }
        }
        else
        {
            // 如果道具欄已滿 且無法堆疊
            if (goodsList.Count == 20)
            {
                // 回傳否定表示該道具並未添加 且添加失敗
                return false;
            }

            // 沒有東西可以堆疊
            // 增加一個道具欄位
            Goods newItem = new Goods();
            newItem.id = id;
            newItem.number = 1;
            // 為陣列新增一個元素
            goodsList.Add(newItem);
        }

        // 無論是堆疊道具還是添加新道具欄 都要通知更新
        if (Act_goodsChange != null)
        {
            Act_goodsChange.Invoke();
        }
        // 如果程式執行到最後並未停止 表示該道具成功添加
        return true;
    }

    /// <summary>
    /// 減少道具
    /// </summary>
    /// <param name="id">道具編號</param>
    public void removeItem(int id)
    {
        int thisItem = checkItem(id);

        // 如果道具數量有兩個或以上時 只需減少即可
        if (thisItem >= 2)
        {
            for (int i = 0; i < goodsList.Count; i++)
            {
                if (goodsList[i].id == id)
                {
                    Goods temp = goodsList[i];  // 複製一個陣列
                    temp.number--;              // 將複製的陣列進行修改
                    goodsList[i] = temp;        // 將修改後的陣列覆蓋回去
                    break;                      // 已成功完成堆疊 結束迴圈
                }
            }
        }
        // 道具數量只剩一個時 就要刪除整個項目
        else if (thisItem == 1)
        {
            for (int i = 0; i < goodsList.Count; i++)
            {
                if (goodsList[i].id == id)
                {
                    // 移除第I個項目
                    goodsList.RemoveAt(i);
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("嘗試移除不存在的道具");
        }

        // 通知道具欄發生變化
        if (Act_goodsChange != null)
        {
            Act_goodsChange.Invoke();
        }
    }

    /// <summary>
    /// 查詢道具數量
    /// </summary>
    /// <param name="id">道具編號</param>
    /// <returns></returns>
    public int checkItem(int id)
    {
        for (int i = 0; i < goodsList.Count; i++)
        {
            // 如果遇到相同ID的道具
            if (goodsList[i].id == id)
            {
                // 就回傳該道具的數量
                return goodsList[i].number;
            }
        }
        return 0;
    }

    /// <summary>
    /// 持有物
    /// </summary>
    [System.Serializable]
    public struct Goods
    {
        [SerializeField] public int id;     // 有什麼樣的道具(ID)
        [SerializeField] public int number; // 有幾個這個道具(數量)
    }
}
