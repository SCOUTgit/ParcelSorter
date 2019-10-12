using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    [SerializeField]
    private float moveDistance;
    [SerializeField]
    private float moveTime;
    [SerializeField]
    private int shakeCount;

    public IEnumerator Shake(Direction direction)
    {
        var firstPosition = gameObject.transform.position;

        for (int i = 0; i < shakeCount; i++)
        {

            gameObject.transform.Translate((Vector2)Random.insideUnitCircle * moveDistance);
            yield return new WaitForSeconds(moveTime);
        }

        gameObject.transform.position = firstPosition;
        yield break;
    }
}
