using UnityEngine;

public class ItemField : Windows<ItemField>
{
    [Header("��l�ҪO")]
    [SerializeField] GameObject tempGrid = null;
    [Header("�D����I��")]
    [SerializeField] RectTransform itemFieldBG = null;

    protected override void Awake()
    {
        base.Awake();
        openSpeed = 15f;    // �����}�ҳt�� = 15
        ItemManager.instance.��l��();
    }

    protected override void Start()
    {
        base.Start();
        ��s�D����();
    }

    protected override void Update()
    {
        base.Update();
        // �� Tab�� �}�ҹD���椶��
        if (Input.GetKeyDown(KeyCode.Tab))
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

    void ��s�D����()
    {
        // ��l�ҪO���������
        tempGrid.SetActive(false);
        // i�p���l�ƶq 20
        for (int i = 0; i < 20; i++)
        {
            // �p�Gi�p�󪱮a�������D��ƶq �N��ܹD��
            if (i < SaveManager.instance.goodsList.Count)
            {
                // ��ܫ����D��
                // �ƻs�@�Ӯ�l�ҪO �é�i�D����I����
                GameObject ��Ыت���l = Instantiate(tempGrid, itemFieldBG);
                ��Ыت���l.SetActive(true);
                ��Ыت���l.GetComponent<Grid>().��J���(SaveManager.instance.goodsList[i]);
            }
            // �_�h��ܪŮ�l
            else
            {
                
            }
        }
    }
}
