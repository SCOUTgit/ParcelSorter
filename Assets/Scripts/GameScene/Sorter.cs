using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sorter : MonoBehaviour
{
    public System.Action<Direction> clickEvent;
    [SerializeField]
    private Direction direction;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => clickEvent(direction));
    }
}
