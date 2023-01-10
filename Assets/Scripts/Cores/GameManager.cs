using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private List<GameObject> stagePrefabs;
    public bool isClear;
    private GameObject playground;
    private GameObject titleText;
    private GameObject pressStartText;
    private GameObject playButton;
    private GameObject currentStageObject;
    private Animator timAnimator;
    private AudioSource audioSource;
    private TextMeshProUGUI playText;
    private TextMeshProUGUI stageText;
    private Sequence pressStartTextSequence;
    private bool isBeforeStart = true;
    private bool isBeforePlay;
    private bool isPlaying;
    private int currentStage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        playground = GameObject.Find("Playground");
        titleText = GameObject.Find("TitleText");
        pressStartText = GameObject.Find("PressStartText");
        playButton = GameObject.Find("PlayButton");
        playText = playButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        stageText = GameObject.Find("StageText").GetComponent<TextMeshProUGUI>();
        timAnimator = GameObject.Find("TiM").GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PressStartText();
    }

    private void Update()
    {
        if (isBeforeStart && Input.anyKeyDown)
        {
            isBeforeStart = false;
            Sequence sequence = DOTween.Sequence();

            sequence.Append(playground.transform.DOScale(new Vector3(9f, 9f), 1f).SetEase(Ease.OutQuart))
                .Join(titleText.transform.DOScale(new Vector3(0f, 0.1f), 1f).SetEase(Ease.OutQuart))
                .Join(pressStartText.transform.DOScale(new Vector3(0f, 0.1f), 1f).SetEase(Ease.OutQuart))
                .AppendCallback(() =>
                {
                    Destroy(titleText.gameObject);
                    Destroy(pressStartText.gameObject);

                    playground.layer = 0;
                    isBeforePlay = true;
                })
                .Append(playButton.GetComponent<UnityEngine.UI.Image>().DOFade(1f, 1f));
        }
        else if (!isBeforeStart)
        {
            pressStartTextSequence.Kill();
        }

        if (audioSource.isPlaying && isPlaying)
        {
            stageText.text = $"Current Stage\nStage {currentStage}";
        }
        else if (!audioSource.isPlaying && isPlaying)
        {
            GameStop();
        }
    }

    public void GameStart()
    {
        if (isBeforePlay)
        {
            isBeforePlay = false;

            Sequence sequence = DOTween.Sequence();

            sequence.Append(playButton.GetComponent<UnityEngine.UI.Image>().DOFade(0f, 1f))
                .Join(playText.DOColor(Color.white, 1f))
                .AppendCallback(() =>
                {
                    playText.text = "Pla";
                })
                .AppendInterval(0.25f)
                .AppendCallback(() =>
                {
                    playText.text = "Pl";
                })
                .AppendInterval(0.25f)
                .AppendCallback(() =>
                {
                    playText.text = "P";
                })
                .AppendInterval(0.25f)
                .AppendCallback(() =>
                {
                    playText.text = "";
                })
                .AppendInterval(1f)
                .AppendCallback(() =>
                {
                    audioSource.Play();
                    playText.text = "5";
                })
                .AppendInterval(1f)
                .AppendCallback(() =>
                {
                    playText.text = "4";
                })
                .AppendInterval(1f)
                .AppendCallback(() =>
                {
                    playText.text = "3";
                })
                .AppendInterval(1f)
                .AppendCallback(() =>
                {
                    playText.text = "2";
                })
                .AppendInterval(1f)
                .AppendCallback(() =>
                {
                    playText.text = "1";
                })
                .AppendInterval(1f)
                .AppendCallback(() =>
                {
                    Destroy(playButton.gameObject);
                    timAnimator.SetTrigger("Run");

                    Timer.instance.StartRecord();
                    isPlaying = true;

                    GamePlaying();
                });
        }
    }

    public void GamePlaying()
    {
        if (currentStageObject != null)
        {
            Destroy(currentStageObject);
        }

        if (currentStage != stagePrefabs.Count)
        {
            currentStageObject = Instantiate(stagePrefabs[++currentStage - 1]);
        }
        else
        {
            GameStop();
        }
    }

    public void GameStop()
    {
        isPlaying = false;
        Timer.instance.StopRecord();

        if (currentStage == stagePrefabs.Count)
        {
            isClear = true;
            audioSource.Stop();
        }
        else
        {
            isClear = false;
        }

        SceneManager.LoadScene("EndScene");
    }

    private void PressStartText()
    {
        pressStartTextSequence = DOTween.Sequence();

        pressStartTextSequence.Append(pressStartText.transform.DOScale(new Vector3(0.9f, 0.9f), 1f))
            .Append(pressStartText.transform.DOScale(Vector3.one, 1f))
            .OnComplete(() =>
            {
                PressStartText();
            });
    }
}
