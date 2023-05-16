using UnityEngine;

public class ItemField : Windows<ItemField>
{
    [SerializeField] GameObject �D��ҪO = null;
    [SerializeField] RectTransform BG = null;

    protected override void Awake()
    {
        base.Awake();
        openSpeed = 15f;    // �����}�ҳt�� = 15
        ItemManager.instance.��l��();
    }

    protected override void Start()
    {
        base.Start();
        ��s�D��();
    }

    protected override void Update()
    {
        base.Update();
        // �� I �}�ҹD���椶��
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

    // ���}������ ��ܷƹ� �ɶ��Ȱ�
    public override void Open()
    {
        base.Open();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    // ���������� ���÷ƹ� �ɶ��~��
    public override void Close()
    {
        base.Close();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    void ��s�D��()
    {
        for (int i = 0; i < ItemManager.instance.AllItem.Length; i++)
        {
            GameObject tempItem = Instantiate(�D��ҪO, BG);
            tempItem.SetActive(true);
            RectTransform UITra = tempItem.GetComponent<RectTransform>();

            UITra.anchoredPosition = new Vector2(UITra.anchoredPosition.x, -20f - (i * 220f));
        }
        BG.sizeDelta = new Vector2(BG.sizeDelta.x, 20f + (ItemManager.instance.AllItem.Length * 22f));
    }
}
