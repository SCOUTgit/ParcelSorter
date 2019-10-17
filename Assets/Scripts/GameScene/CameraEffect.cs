using System.Collections;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    [SerializeField]
    private float moveDistance;
    [SerializeField]
    private float moveTime;
    [SerializeField]
    private int shakeCount;

    private WaitForSeconds waitForMoveTime;

    private void Start()
    {
        waitForMoveTime = new WaitForSeconds(moveTime);
    }

    public IEnumerator Shake()
    {
        var firstPosition = gameObject.transform.position;

        for (int i = 0; i < shakeCount; i++)
        {
            gameObject.transform.Translate((Vector2)Random.insideUnitCircle * moveDistance);
            yield return waitForMoveTime;
        }

        gameObject.transform.position = firstPosition;
        yield break;
    }
}
