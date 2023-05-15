using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region ���
    public static SaveManager instance
    {
        // ���H�ݭn��
        get
        {
            // �p�G�ڤ��s�b
            if (_instance == null)
            {
                // �N�ۤv�гy�ۤv
                _instance = new SaveManager();
            }
            // �^�Ǧۤv
            return _instance;
        }
    }
    // �O�����ڪ���m
    static SaveManager _instance = null;
    #endregion

    public List<Goods> goodsList = new List<Goods>();

    /// <summary>
    /// �K�[�D��(By ID)
    /// </summary>
    /// <param name="id">�D��s��</param>
    public void addItem(int id)
    {
        // �p�G�w�g���D�� �N�֭p
        if (checkItem(id) > 0)
        {
            // ���y�Ҧ��D��
            for (int i = 0; i < goodsList.Count; i++)
            {
                if (goodsList[i].id == id)
                {
                    Goods temp = goodsList[i];  // �ƻs�@���}�C
                    temp.number++;              // �N�ƻs���}�C�i��ק�
                    goodsList[i] = temp;        // �N�ק�᪺�}�C�л\�^�h
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
    /// ������
    /// </summary>
    [System.Serializable]
    public struct Goods
    {
        [SerializeField] public int id;
        [SerializeField] public int number;
    }
}
