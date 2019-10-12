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
    [SerializeField]
    private List<AudioClip> boxSound;
    [SerializeField]
    private GameObject gameOverBoardPrefab;
    [SerializeField]
    private GameObject pauseBoardPrefab;
    [SerializeField]
    private CameraEffect mainCamera;

    private Parcel lastParcel;

    private void Start()
    {
        parcelQueue = new Queue<Parcel>();
        parcelList.ForEach((parcel) => parcelQueue.Enqueue(parcel.GetComponent<Parcel>()));
        sorterList.ForEach((sorter) => sorter.clickEvent = TrySort);
        lastParcel = parcelQueue.Peek();
        timer.GameOver = GameOver;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OpenPauseBoard();
        }
    }

    public void TrySort(Direction direction)
    {
        if (parcelQueue.Peek().isMoving || lastParcel.isMoving)
            return;
        if (parcelQueue.Peek().CanSort(direction))
        {
            timer.SetTimer(score.score);
            score.SetText();
            SoundManager.instance.PlaySound(boxSound[Random.Range(0, boxSound.Count)]);
            mainCamera.StartCoroutine(mainCamera.Shake(direction));

            lastParcel = parcelQueue.Peek();
            parcelQueue.Dequeue();
            parcelQueue.Peek().moveAnimation = belt.SetAnimationSpeed;
            lastParcel.StartCoroutine("Sort");
            foreach (var item in parcelQueue)
                item.StartCoroutine("Move");
            parcelQueue.Enqueue(lastParcel);
        }

        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        score.SaveScore();
        timer.StopAllCoroutines();
        var failBoard = Instantiate(gameOverBoardPrefab).GetComponent<GameOverBoard>();
        failBoard.SetGameOverBoard(score.score);
    }

    public void OpenPauseBoard()
    {
        Instantiate(pauseBoardPrefab);
    }
}
