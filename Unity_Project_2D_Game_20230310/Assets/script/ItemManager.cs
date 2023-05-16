using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    #region ���
    public static ItemManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new ItemManager();
            return _instance;
        }
    }
    static ItemManager _instance = null;
    #endregion

    // �N�Ҧ��D���b�@�Ӱ}�C��
    public ItemData[] AllItem = new ItemData[0];

    /// <summary>
    /// ��l�ƹD��G��Ҧ��D���i��Ʈw��
    /// </summary>
    public void ��l��()
    {
        // �q�M�פ���X�Ҧ��D����
        AllItem = Resources.LoadAll<ItemData>("");
    }

    /// <summary>
    /// ��D���ơG�̷�ID�M��
    /// </summary>
    /// <param name="id">�D��s��</param>
    /// <returns></returns>
    public ItemData FindItemData(int id)
    {
        for (int i = 0; i < AllItem.Length; i++)
        {
            if (AllItem[i].id == id)
            {
                return AllItem[i];
            }
        }
        Debug.LogError("ID�G" + id + "�d�L��ID");
        return new ItemData();
    }
}
