using UnityEngine;
using UnityEngine.UI;

public class RankingButton : MonoBehaviour
{
    private void Start() => gameObject.GetComponent<Button>().onClick.AddListener(() => GooglePlayGameService.OpenLeaderBoard());
}