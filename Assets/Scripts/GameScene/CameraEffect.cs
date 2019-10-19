using System.Collections;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    [SerializeField]
    private float shakeDistance;
    [SerializeField]
    private float shakeTime;
    [SerializeField]
    private int shakeCount;

    private WaitForSeconds waitForMoveTime;

    private void Start()
    {
        waitForMoveTime = new WaitForSeconds(shakeTime / shakeCount);
    }

    public IEnumerator Shake()
    {
        var firstPosition = gameObject.transform.position;

        for (int i = 0; i < shakeCount; i++)
        {
            gameObject.transform.Translate((Vector2)Random.insideUnitCircle * shakeDistance);
            yield return waitForMoveTime;
        }

        gameObject.transform.position = firstPosition;
        yield break;
    }
}
