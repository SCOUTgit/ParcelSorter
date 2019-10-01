using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelManager : MonoBehaviour
{
    public Queue<Parcel> parcelQueue{get; private set;}
    [SerializeField]
    private List<GameObject> parcelList;

    private void Start() {
        parcelQueue = new Queue<Parcel>();
        parcelList.ForEach((parcel)=>{
            parcelQueue.Enqueue(parcel.GetComponent<Parcel>());
        });      
    }

    public void Sort()
    {
       // 점수 증가시키기
        Parcel parcel = parcelQueue.Peek();
        parcelQueue.Dequeue();
        parcel.StartCoroutine("Sort");
        foreach (var item in parcelQueue)
            item.StartCoroutine("Move");
        parcelQueue.Enqueue(parcel);
    }
}
