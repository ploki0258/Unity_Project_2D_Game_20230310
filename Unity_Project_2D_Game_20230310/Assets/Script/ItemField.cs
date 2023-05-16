using UnityEngine;

public class ItemField : Windows<ItemField>
{
    [SerializeField] GameObject 道具模板 = null;
    [SerializeField] RectTransform BG = null;

    protected override void Awake()
    {
        base.Awake();
        openSpeed = 15f;    // 視窗開啟速度 = 15
        ItemManager.instance.初始化();
    }

    protected override void Start()
    {
        base.Start();
        刷新道具();
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

    void 刷新道具()
    {
        for (int i = 0; i < ItemManager.instance.AllItem.Length; i++)
        {
            GameObject tempItem = Instantiate(道具模板, BG);
            tempItem.SetActive(true);
            RectTransform UITra = tempItem.GetComponent<RectTransform>();

            UITra.anchoredPosition = new Vector2(UITra.anchoredPosition.x, -20f - (i * 220f));
        }
        BG.sizeDelta = new Vector2(BG.sizeDelta.x, 20f + (ItemManager.instance.AllItem.Length * 22f));
    }
}
