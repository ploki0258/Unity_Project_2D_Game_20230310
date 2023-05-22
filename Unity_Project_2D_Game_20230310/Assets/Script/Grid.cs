using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    [SerializeField] Image 圖示;
    [SerializeField] Image 底色;
    [SerializeField] Text 數量;
    [SerializeField] Text 名稱;
    [SerializeField] Text 描述;

    public void 輸入資料(SaveManager.Goods data)
    {
        ItemData 格子 = ItemManager.instance.FindItemData(data.id);

        圖示.transform.localScale = Vector3.one;
        圖示.sprite = 格子.icon;
        底色.color = 格子.category;
        名稱.text = 格子.name;
        描述.text = 格子.info;
        數量.text = data.number.ToString();
    }
}
