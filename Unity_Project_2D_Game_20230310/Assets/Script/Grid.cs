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

    ItemData dataGrid;
    bool isNoneGrid = true;

    public void 輸入資料(SaveManager.Goods data)
    {
        isNoneGrid = false;
        dataGrid = ItemManager.instance.FindItemData(data.id);

        圖示.transform.localScale = Vector3.one;
        圖示.sprite = dataGrid.icon;
        底色.color = dataGrid.category;
        名稱.text = dataGrid.title;
        描述.text = dataGrid.info;
        數量.text = "×" + data.number.ToString();
    }

    private void OnEnable()
    {
        if (isNoneGrid == true)
        {
            圖示.transform.localScale = Vector3.zero;
            底色.color = Color.black;
            名稱.text = "";
            描述.text = "";
            數量.text = "";
        }
    }
}
