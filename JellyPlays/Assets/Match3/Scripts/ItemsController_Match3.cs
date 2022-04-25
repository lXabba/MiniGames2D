using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ItemsController_Match3 : MonoBehaviour
{
    [SerializeField] private int height;
    [SerializeField] private int weight;
    public static ItemsController_Match3 instance;
    public Item_Match3 itemPrefab;
    public List<Item_Match3> litems;


    private List<Image_Match3> lswitch;

    private void Awake()
    {
        instance = GetComponent<ItemsController_Match3>();
    }
    void Start()
    {
        litems = new List<Item_Match3>();
        lswitch = new List<Image_Match3>();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < weight; x++)
            {
                var item = Instantiate(itemPrefab);
                item.transform.parent = this.transform;
                item.transform.localScale = new Vector3(1, 1, 1);

                var type = DBImages_Match3.types[Random.Range(0, DBImages_Match3.types.Length)];
                item.GetComponent<Item_Match3>().SetComponents(x, y, type.cost, type.image);

                litems.Add(item);
            }
        }





    }

    public void SwitchImages(Image_Match3 image)
    {

        if (!lswitch.Contains(image))
        {
            lswitch.Add(image);
        }
        if (lswitch.Count < 2) return;

        var item1 = lswitch[0].GetComponentInParent<Item_Match3>();
        var item2 = lswitch[1].GetComponentInParent<Item_Match3>();

        if (!CheckImages(item1, item2)){
            lswitch.Clear();
            return;
        }

        var itemImage = item1.image;
        item1.ChangeImage(item2.image);
        item2.ChangeImage(itemImage);

        lswitch.Clear();

    }

    private bool CheckImages(Item_Match3 item1, Item_Match3 item2)
    {
        if ((item1.x + 1 == item2.x || item1.x - 1 == item2.x) && item1.y == item2.y) return true;
        if ((item1.y + 1 == item2.y || item1.y - 1 == item2.y) && item1.x == item2.x) return true;
        return false;
    }
}
