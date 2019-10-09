using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel : MonoBehaviour
{
    public enum Direction { down, left, right }
    public bool isMoving { get; private set; }
    public System.Action<bool> moveAnimation;

    [SerializeField]
    private float moveDistance;
    [SerializeField]
    private float sortDistance;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float sortSpeed;
    [SerializeField]
    private Vector3 createPosition;

    private SpriteRenderer spriteRenderer;
    private Direction direction;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetDirection();
    }

    public void SetDirection()
    {
        direction = (Direction)Random.Range(0, System.Enum.GetValues(typeof(Direction)).Length);
        spriteRenderer.color = new Color(0, 255, 0);
        switch (direction)
        {
            case Direction.left:
                spriteRenderer.color = new Color(255, 0, 0);
                break;
            case Direction.right:
                spriteRenderer.color = new Color(0, 0, 255);
                break;
        }
    }

    public bool CanSort(Direction selectedDirection) => direction == selectedDirection;

    private IEnumerator Move()
    {
        isMoving = true;
        moveAnimation?.Invoke(isMoving);
        Vector3 startPosition = gameObject.transform.position;

        while (Vector3.SqrMagnitude(startPosition - gameObject.transform.position) < moveDistance * moveDistance)
        {
            gameObject.transform.Translate(moveSpeed * Vector2.down * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
        moveAnimation?.Invoke(isMoving);
        yield break;
    }

    private IEnumerator Sort()
    {
        Vector3 startPosition = gameObject.transform.position;

        Vector2 sortDirection = Vector2.down;
        switch (direction)
        {
            case Direction.left:
                sortDirection = Vector2.left;
                break;
            case Direction.right:
                sortDirection = Vector2.right;
                break;
        }

        while (Vector3.SqrMagnitude(startPosition - gameObject.transform.position) < sortDistance * sortDistance)
        {
            gameObject.transform.Translate(sortSpeed * sortDirection * Time.deltaTime);
            yield return null;
        }

        gameObject.transform.position = createPosition;
        SetDirection();

        yield break;
    }
}
