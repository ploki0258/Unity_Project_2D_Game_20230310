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
}
