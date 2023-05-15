using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
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

    public List<Goods> goodsList = new List<Goods>();

    /// <summary>
    /// 添加道具(By ID)
    /// </summary>
    /// <param name="id">道具編號</param>
    public void addItem(int id)
    {
        // 如果已經有道具 就累計
        if (checkItem(id) > 0)
        {
            // 掃描所有道具
            for (int i = 0; i < goodsList.Count; i++)
            {
                if (goodsList[i].id == id)
                {
                    Goods temp = goodsList[i];  // 複製一份陣列
                    temp.number++;              // 將複製的陣列進行修改
                    goodsList[i] = temp;        // 將修改後的陣列覆蓋回去
                }
            }
        }
    }

    public void removeItem()
    {

    }

    public int checkItem(int id)
    {
        for (int i = 0; i < goodsList.Count; i++)
        {
            if (goodsList[i].id == id)
            {
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
        [SerializeField] public int id;
        [SerializeField] public int number;
    }
}
