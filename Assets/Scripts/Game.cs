using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static bool isGameover = false;
    public static int Score { get; private set; }

    public AllParametrs AllParametrs { get; private set; }

    [SerializeField] private ShowingSkipVideo skipAd;

    [SerializeField] private AudioSource startGameSound;
    [SerializeField] private AudioSource endGameSound;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text crystalText;

    [SerializeField] private Image fadePanel;

    [SerializeField] private GameObject gameElements;

    [Space]
    //[SerializeField] private GameObject startGamePanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject resultPanel;

    [Space]
    [SerializeField] private Text endScoreText;
    [SerializeField] private Text bestScoreText;

    private int addedScore;
    private int collectedCrystal;

    private static int numberGamesBeforeAdvertising = 5;

    public static Game Instance;

    private void Awake()
    {
        Instance = this;
        AllParametrs = new AllParametrs();
        AllParametrs = JsonUtility.FromJson<AllParametrs>(PlayerPrefs.GetString("allParametrs"));
    }

    private void Start()
    {
        Subscribe();
        StartAgainGame();
    }

    private void Subscribe()
    {
        PlayerCollision.onCorrectCollision += CorrectCollision;
        PlayerCollision.onLose += Gameover;
    }
    private void UnSubscribe()
    {
        PlayerCollision.onCorrectCollision -= CorrectCollision;
        PlayerCollision.onLose -= Gameover;
    }

    private void GetResult()
    {
        endScoreText.text = Score.ToString();
        if(Score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", Score);
            bestScoreText.text = $"NEW BEST: {Score}";
        }
        else
        {
            bestScoreText.text = $"BEST: {PlayerPrefs.GetInt("BestScore", 0)}";
        }
    }

    private void CorrectCollision()
    {
        Score++;
        UpdateUI();
    }
    private void UpdateUI()
    {
        scoreText.text = Score.ToString();
        if (Score - addedScore >= 10)
        {
            addedScore += 10;
            collectedCrystal++;
        }
        crystalText.text = collectedCrystal.ToString();
    }
    private void FadeStart()
    {
        fadePanel.DOFade(0f, 0.8f).From(1f);
    }

    private bool CheckCanPlaySound()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
            return true;
        else
            return false;
    }

    public void Gameover()
    {
        LeaderBoard.AddScoreToLeaderboard(Score);
        if (CheckCanPlaySound()) endGameSound.Play();
        isGameover = true;
        if (numberGamesBeforeAdvertising <= 0)
        {
            skipAd.ShowRewardedVideo();
            numberGamesBeforeAdvertising = 5;
        }
    }

    public void StartAgainGame()
    {
        if (CheckCanPlaySound()) startGameSound.Play();
        FadeStart();
        Score = 0;
        addedScore = 0;
        collectedCrystal = 0;
        EnemyMovement.Speed = EnemyMovement.StartSpeed;
        StartGame();
    }
    public void StartGame()
    {
        UpdateUI();

        isGameover = false;

        gameElements.SetActive(true);

        resultPanel.SetActive(false);
        gamePanel.SetActive(true);

        numberGamesBeforeAdvertising--;
    }

    public void ShowResultPanel()
    {
        GetResult();
        FadeStart();

        gameElements.SetActive(false);
        gamePanel.SetActive(false);
        resultPanel.SetActive(true);
    }

    public void ToMenu()
    {
        FadeStart();
        SceneManager.LoadScene("Menu");
    }

    public void ToShop()
    {
        FadeStart();
        SceneManager.LoadScene("Shop");
    }

    public void ClickPlay()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1) Click.Instance.Play();
    }
    private void OnDestroy()
    {
        UnSubscribe();
        AllParametrs.Crystal += collectedCrystal;
        AllParametrs.SaveAllParametrs(AllParametrs);
    }
}
