using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sorter : MonoBehaviour
{
    public event System.Action sort;

    [SerializeField]
    private Parcel.Direction direction;
    [SerializeField]
    ParcelManager parcelManager;
    [SerializeField]
    Timer timer;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => Sort());
        sort += parcelManager.Sort;
        sort += timer.SetTimer;
    }

    private void Sort()
    {
        if (parcelManager.CheckSort(direction))
            sort.Invoke();
    }
}
