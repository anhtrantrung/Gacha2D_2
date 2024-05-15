using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using TMPro;

public class ShowItem : MonoBehaviour
{
    [SerializeField] List<Transform> items = new List<Transform>();
    public static ShowItem instance;
    public Transform hodler;
    public TextMeshPro itemData;

    public int itemRandom;

    protected void Awake()
    {
        ShowItem.instance = this;
    }

    private void Reset()
    {
        LoadHodler();

    }

    public void LoadHodler()
    {
        if (hodler != null) return;
        hodler = transform.Find("Horled");

        foreach (Transform item in hodler)
        {
            items.Add(item);
        }
    }

    private void FixedUpdate()
    {
        LoadItem();
    }

    public void LoadItem()
    {
        foreach (Transform item in items)
        {
            if (item.name == SpinnerMarker.instance.itenName)
            {
                itemData = item.GetComponent<TextMeshPro>();
                Spin.instance.ExportItem(itemData);
            }
        }
    }

    public string RandomIten()
    {
        itemRandom = Random.Range(1, items.Count +1);
        return itemRandom.ToString();
    }
}
