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
}
