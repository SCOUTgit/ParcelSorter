using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { down, left, right }
public class Parcel : MonoBehaviour
{
    public bool isMoving { get; private set; }
    public System.Action<float> moveAnimation;

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
        spriteRenderer.color = new Color(0, 1, 0);
        switch (direction)
        {
            case Direction.left:
                spriteRenderer.color = new Color(1, 0, 0);
                break;
            case Direction.right:
                spriteRenderer.color = new Color(0, 0, 1);
                break;
        }
    }

    public bool CanSort(Direction selectedDirection) => direction == selectedDirection;

    private IEnumerator Move()
    {
        isMoving = true;
        moveAnimation?.Invoke(moveSpeed);
        Vector3 startPosition = gameObject.transform.position;

        while (Vector3.SqrMagnitude(startPosition - gameObject.transform.position - moveSpeed * Vector3.down * Time.deltaTime) < moveDistance * moveDistance)
        {
            gameObject.transform.Translate(moveSpeed * Vector2.down * Time.deltaTime);
            yield return null;
        }

        gameObject.transform.position = startPosition - new Vector3(0, moveDistance, 0);

        isMoving = false;
        moveAnimation?.Invoke(0);
        yield break;
    }

    private IEnumerator Sort()
    {
        isMoving = true;
        Vector3 startPosition = gameObject.transform.position;

        spriteRenderer.color = new Color(161 / 255f, 113 / 255f, 34 / 255f);

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
        isMoving = false;

        yield break;
    }
}
