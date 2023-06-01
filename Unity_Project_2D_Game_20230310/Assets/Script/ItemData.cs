using UnityEngine;

/// <summary>
/// �D��t�ΡG�إ߹D�㪺��Ʈ榡
/// </summary>
[CreateAssetMenu(fileName ="�s�D��", menuName ="�إ߷s�D��")]
public class ItemData : ScriptableObject
{
    // ScriptableObject = ���ƪ����

    // �@�P
    public int id;                      // ID
    public string title;                // ���D
    public Sprite icon;                 // �ϥ�
    [TextArea(5,5)] public string info; // �ԭz
    public bool canUse;                 // �O�_�i�ϥ�
    public bool Consumables;            // �ϥΫ�O�_�|����
    public Color category;              // ���O���C��

    // �ӧO
    // public float regainHp;   // �^��
    // public float regainMp;   // ���]
    public float regainStr;  // �^��O

    // �b Awake �ɳ]�w�w�]��
    /*private void Awake()
    {
        title = "���R�W";
        info = "�L�ԭz";
        canUse = false;
        Consumables = false;
    }
    */
}
