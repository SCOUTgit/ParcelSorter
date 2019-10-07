using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Text scoreText;
    [SerializeField]
    private int scoreIncreaseAmount;

    private int score = 0;

    private void Start()
    {
        parcelQueue = new Queue<Parcel>();
        parcelList.ForEach((parcel) => parcelQueue.Enqueue(parcel.GetComponent<Parcel>()));
        sorterList.ForEach((sorter) => sorter.clickEvent = TrySort);
    }

    public void TrySort(Parcel.Direction direction)
    {
        if (parcelQueue.Peek().CanSort(direction))
        {
            timer.SetTimer();

            score += scoreIncreaseAmount;
            scoreText.text = $"Score : {score}";

            Parcel parcel = parcelQueue.Peek();
            parcelQueue.Dequeue();
            parcel.StartCoroutine("Sort");
            foreach (var item in parcelQueue)
                item.StartCoroutine("Move");
            parcelQueue.Enqueue(parcel);
        }
    }
}
