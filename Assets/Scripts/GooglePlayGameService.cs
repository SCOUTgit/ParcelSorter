using System.Collections;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayGameService : MonoBehaviour
{
    [SerializeField]
    private BestScoreText bestScoreText;

    private AndroidToast androidToast;
    private static bool isTriedLogin = false;

    private void Awake()
    {
        if (!isTriedLogin)
        {
            isTriedLogin = true;
            androidToast = gameObject.AddComponent<AndroidToast>();
            PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate(AuthenticateCallback);
        }
    }

    private void AuthenticateCallback(bool success)
    {
        if (success)
            LoadScore();
        else
            StartCoroutine(fail());
    }

    private IEnumerator fail()
    {
        androidToast.ShowToast("로그인 실패");
        yield return new WaitForSeconds(2f);
        androidToast.CancelToast();
        yield break;
    }

    private void LoadScore()
    {
        PlayGamesPlatform.Instance.LoadScores(
            GPGSIds.leaderboard_ranking, LeaderboardStart.PlayerCentered, 1, LeaderboardCollection.Public, LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                if (data.PlayerScore.value > PlayerPrefs.GetInt("BestScore"))
                {
                    PlayerPrefs.SetInt("BestScore", (int)data.PlayerScore.value);
                    bestScoreText.UpdateBestScore();
                }
                else if (data.PlayerScore.value < PlayerPrefs.GetInt("BestScore"))
                    UpdateScore(PlayerPrefs.GetInt("BestScore"));
            }
        );
    }

    public static void UpdateScore(int score) => Social.ReportScore(score, GPGSIds.leaderboard_ranking, (b) => { });

    public static void OpenLeaderBoard() => Social.Active.ShowLeaderboardUI();
}
