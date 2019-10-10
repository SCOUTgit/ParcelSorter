using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Queue<Parcel> parcelQueue { get; private set; }

    [SerializeField]
    private List<GameObject> parcelList;
    [SerializeField]
    private List<Sorter> sorterList;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private Belt belt;
    [SerializeField]
    private Score score;

    private void Start()
    {
        parcelQueue = new Queue<Parcel>();
        parcelList.ForEach((parcel) => parcelQueue.Enqueue(parcel.GetComponent<Parcel>()));
        sorterList.ForEach((sorter) => sorter.clickEvent = TrySort);
        timer.fail = Fail;
    }

    public void TrySort(Parcel.Direction direction)
    {
        if(parcelQueue.Peek().isMoving)
            return;
        if (parcelQueue.Peek().CanSort(direction))
        {
            timer.SetTimer(score.score);
            score.SetText();

            Parcel parcel = parcelQueue.Peek();
            parcelQueue.Dequeue();
            parcelQueue.Peek().moveAnimation = belt.SetAnimationSpeed;
            parcel.StartCoroutine("Sort");
            foreach (var item in parcelQueue)
                item.StartCoroutine("Move");
            parcelQueue.Enqueue(parcel);
        }

        else
        {
            Fail();
        }
    }
    
    private void Fail(){
        score.SaveScore();
        timer.StopAllCoroutines();
    }
}
