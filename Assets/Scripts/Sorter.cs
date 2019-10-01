using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sorter : MonoBehaviour
{
    [SerializeField]
    private Parcel.Direction direction;
    [SerializeField]
    ParcelManager parcelManager;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>Sort());
    }

    private void Sort()
    {
        if(parcelManager.parcelQueue.Peek().CompareDirection(direction) && !parcelManager.parcelQueue.Peek().isMoving)
        {
            parcelManager.Sort();
        }
    }
}
