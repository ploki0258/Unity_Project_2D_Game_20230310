using UnityEngine;

public class ItemField : Windows<ItemField>
{
    protected override void Awake()
    {
        base.Awake();
        openSpeed = 15f;    // 視窗開啟速度 = 15
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
}
