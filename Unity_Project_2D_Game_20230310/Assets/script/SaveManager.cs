using System.Collections.Generic;
using UnityEngine;

public class SaveManager
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

    [Header("�̤j�����D��ƶq")]
    [SerializeField] int itemNumberMax = 999;

    // �������~�C��
    public List<Goods> goodsList = new List<Goods>();

    // �D��o���ܤơG�s�W�B���
    public System.Action Act_goodsChange;

    /// <summary>
    /// �K�[�D��(By ID)
    /// </summary>
    /// <param name="id">�D��s��</param>
    public bool addItem(int id)
    {
        // �p�G�w�g���D�� �N�֭p
        if (checkItem(id) > 0)
        {
            // ���y�Ҧ��D��
            for (int i = 0; i < goodsList.Count; i++)
            {
                // �p�G�J��ۦPID���D�� �B�ثe�����ƶq <= �̤j�����ƶq �N�u��¼W�[�ƶq
                if (goodsList[i].id == id && goodsList[i].number <= itemNumberMax)
                {
                    Goods temp = goodsList[i];  // �ƻs�@�Ӱ}�C
                    temp.number++;              // �N�ƻs���}�C�i��ק�
                    goodsList[i] = temp;        // �N�ק�᪺�}�C�л\�^�h
                    break;                      // �w���\�������| �����j��
                }
            }
        }
        else
        {
            // �p�G�D����w�� �B�L�k���|
            if (goodsList.Count == 20)
            {
                // �^�ǧ_�w��ܸӹD��å��K�[ �B�K�[����
                return false;
            }

            // �S���F��i�H���|
            // �W�[�@�ӹD�����
            Goods newItem = new Goods();
            newItem.id = id;
            newItem.number = 1;
            // ���}�C�s�W�@�Ӥ���
            goodsList.Add(newItem);
        }

        // �L�׬O���|�D���٬O�K�[�s�D���� ���n�q����s
        if (Act_goodsChange != null)
        {
            Act_goodsChange.Invoke();
        }
        // �p�G�{�������̫�å����� ��ܸӹD�㦨�\�K�[
        return true;
    }

    /// <summary>
    /// ��ֹD��
    /// </summary>
    /// <param name="id">�D��s��</param>
    public void removeItem(int id)
    {
        int thisItem = checkItem(id);

        // �p�G�D��ƶq����өΥH�W�� �u�ݴ�֧Y�i
        if (thisItem >= 2)
        {
            for (int i = 0; i < goodsList.Count; i++)
            {
                if (goodsList[i].id == id)
                {
                    Goods temp = goodsList[i];  // �ƻs�@�Ӱ}�C
                    temp.number--;              // �N�ƻs���}�C�i��ק�
                    goodsList[i] = temp;        // �N�ק�᪺�}�C�л\�^�h
                    break;                      // �w���\�������| �����j��
                }
            }
        }
        // �D��ƶq�u�Ѥ@�Ӯ� �N�n�R����Ӷ���
        else if (thisItem == 1)
        {
            for (int i = 0; i < goodsList.Count; i++)
            {
                if (goodsList[i].id == id)
                {
                    // ������I�Ӷ���
                    goodsList.RemoveAt(i);
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("���ղ������s�b���D��");
        }

        // �q���D����o���ܤ�
        if (Act_goodsChange != null)
        {
            Act_goodsChange.Invoke();
        }
    }

    /// <summary>
    /// �d�߹D��ƶq
    /// </summary>
    /// <param name="id">�D��s��</param>
    /// <returns></returns>
    public int checkItem(int id)
    {
        for (int i = 0; i < goodsList.Count; i++)
        {
            // �p�G�J��ۦPID���D��
            if (goodsList[i].id == id)
            {
                // �N�^�ǸӹD�㪺�ƶq
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
        [SerializeField] public int id;     // ������˪��D��(ID)
        [SerializeField] public int number; // ���X�ӳo�ӹD��(�ƶq)
    }
}
