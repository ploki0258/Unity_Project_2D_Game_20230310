using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    [SerializeField] Image �ϥ�;
    [SerializeField] Image ����;
    [SerializeField] Text �ƶq;
    [SerializeField] Text �W��;
    [SerializeField] Text �y�z;

    ItemData dataGrid;
    bool isNone = true;

    public void ��J���(SaveManager.Goods data)
    {
        isNone = false;
        dataGrid = ItemManager.instance.FindItemData(data.id);

        �ϥ�.transform.localScale = Vector3.one;
        �ϥ�.sprite = dataGrid.icon;
        ����.color = dataGrid.category;
        �W��.text = dataGrid.name;
        �y�z.text = dataGrid.info;
        �ƶq.text = "��" + data.number.ToString();
    }

    /*
    private void OnEnable()
    {
        if (isNone == true)
        {
            �ϥ�.transform.localScale = Vector3.zero;
            ����.color = Color.clear;
            �W��.text = "";
            �y�z.text = "";
            �ƶq.text = "";
        }
    }
    */
}
