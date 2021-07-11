using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Image fadePanel;
    [SerializeField] private Text bestScoreText;

    public AllParametrs AllParametrs { get; private set; }

    public static Menu Instance;

    private void Awake()
    {
        Instance = this;

        LeaderBoard.Initialize(false);
        LeaderBoard.Auth((result) => { });

        AllParametrs = new AllParametrs();

        if (!PlayerPrefs.HasKey("allParametrs"))
        {
            string json = JsonUtility.ToJson(AllParametrs);
            PlayerPrefs.SetString("allParametrs", json);
        }
        else
        {
            AllParametrs = JsonUtility.FromJson<AllParametrs>(PlayerPrefs.GetString("allParametrs"));
        }
    }

    private void Start()
    {
        bestScoreText.text = "BEST: " + PlayerPrefs.GetInt("BestScore", 0).ToString();
        FadeStart();
    }

    private void FadeStart()
    {
        fadePanel.DOFade(0f, 0.8f).From(1f);
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void ClosePanel(GameObject panel)
    {
        FadeStart();
        panel.SetActive(false);
    }
    public void OpenPanel(GameObject panel)
    {
        FadeStart();
        panel.SetActive(true);
    }

    public void ShowLeaderBoard()
    {
        LeaderBoard.ShowLeaderboard();
    }

    public void ClickPlay()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1) Click.Instance.Play();
    }
    public void BGMusic()
    {
        if(BackgroundMusic.Instance == null)
        {
            return;
        }
        if (PlayerPrefs.GetInt("Music", 1) == 1)
            BackgroundMusic.Instance.Music.enabled = true;
        else
            BackgroundMusic.Instance.Music.enabled = false;
    }
}
