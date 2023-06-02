using UnityEngine;

/// <summary>
/// �D��t�ΡG�إ߹D�㪺��Ʈ榡
/// </summary>
[CreateAssetMenu(fileName ="�s�D��", menuName ="�إ߷s�D��")]
public class ItemData : ScriptableObject
{
    // ScriptableObject = ���ƪ����
    public string userInput;
    const string PlayerPrefsKey = "UserInputKey";
    // �@�P
    [Header("�D��ID")]
    public int id;                      // �D��ID
    [Header("�D��W��")]
    public string title;                // �D����D
    [Header("�D��ϥ�")]
    public Sprite icon;                 // �D��ϥ�
    [Header("�D�㻡��"), TextArea(5, 5)]
    public string info; // �D��ԭz
    [Header("�D��i�_�ϥ�")]
    public bool canUse;                 // �O�_�i�ϥ�
    [Header("�D��O�_�|����")]
    public bool Consumables;            // �ϥΫ�O�_�|����
    [Header("�D���C��")]
    public Color category;              // ���O���C��

    // �ӧO
    // public float regainHp;   // �^��
    // public float regainMp;   // ���]
    [Header("��_��O��")]
    public float regainStr;  // �^��O

    // �b Awake �ɳ]�w�w�]��
    // �p�G�ϥΪ̦���J�� �hŪ���ϥΪ̪���
    // �p�G�ϥΪ̨S����J�� �h�Ȭ��w�]��
    private void Awake()
    {
        if (PlayerPrefs.HasKey(userInput))
        {
            userInput = PlayerPrefs.GetString(PlayerPrefsKey);
        }
        else
        {
            title = "���R�W";
            info = "�L�ԭz";
            canUse = false;
            Consumables = false;
            regainStr = 0f;
        }
    }

    public void SaveUserInput(string value)
    {
        userInput = value;
        PlayerPrefs.SetString(PlayerPrefsKey, userInput);
    }
}
