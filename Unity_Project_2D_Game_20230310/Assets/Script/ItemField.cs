using UnityEngine;

public class ItemField : Windows<ItemField>
{
    [Header("格子模板")]
    [SerializeField] GameObject tempGrid = null;
    [Header("道具欄背景")]
    [SerializeField] RectTransform itemFieldBG = null;

    protected override void Awake()
    {
        base.Awake();
        openSpeed = 15f;    // 視窗開啟速度 = 15
        ItemManager.instance.初始化();
    }

    protected override void Start()
    {
        base.Start();
        刷新道具欄();
    }

    protected override void Update()
    {
        base.Update();
        // 按 I 開啟道具欄介面
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen == false)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    // 打開視窗時 顯示滑鼠 時間暫停
    public override void Open()
    {
        base.Open();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    // 關閉視窗時 隱藏滑鼠 時間繼續
    public override void Close()
    {
        base.Close();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    void 刷新道具欄()
    {
        // 格子模板本身不顯示
        tempGrid.SetActive(false);
        // i小於格子數量
        for (int i = 0; i < 20; i++)
        {
            // 如果i小於玩家持有的道具數量 就顯示道具
            if (i < SaveManager.instance.goodsList.Count)
            {
                // 顯示持有道具
                // 複製一個格子模板 並放進道具欄背景中
                Instantiate(tempGrid, itemFieldBG);
            }
            // 否則顯示空格子
            else
            {
                
            }
        }
    }
}
