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

    public void ��J���(SaveManager.Goods data)
    {
        ItemData ��l = ItemManager.instance.FindItemData(data.id);

        �ϥ�.transform.localScale = Vector3.one;
        �ϥ�.sprite = ��l.icon;
        ����.color = ��l.category;
        �W��.text = ��l.name;
        �y�z.text = ��l.info;
        �ƶq.text = data.number.ToString();
    }
}
