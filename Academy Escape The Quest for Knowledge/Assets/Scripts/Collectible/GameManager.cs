using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static MusicSO;

public class GameManager : MonoBehaviour
{
    [Header("Oyuncu Çantası")]
    [SerializeField] public short pageNum;
    [Header("UI")]
    [SerializeField] TextMeshProUGUI pageText;
    [SerializeField] Image enerygBar;
    [SerializeField] public Image reloadImage;
    [Header("AudioSources")]
    [SerializeField] AudioSource mainMusicSource;
    [SerializeField] AudioSource playerMusicSource;
    [SerializeField] MusicSO musics;

    [SerializeField] float amountOfDamage = 0.1f;
    public bool isDead = false;
    bool control = true;
    void Awake()
    {
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        UpdatePageView();
        PlayMainMusic(AuidioTypes.MainGameMusic);
    }
    private void Update() 
    {
        if (pageNum == 3 && control)
        {
            SceneManager.LoadSceneAsync(2);
            control = false;
        }
    }
    public void ReduceEnergy()
    {
        enerygBar.fillAmount -= amountOfDamage;
        if (enerygBar.fillAmount <= 0)
        {
            isDead = true;
        }
    }
    public void ReduceEnergy(float amountDamage)
    {
        enerygBar.fillAmount -= amountDamage;
        if(enerygBar.fillAmount <= 0)
        {
            isDead = true;
        }
    }
    public void IncreaseEnergy(float amountOfHeal)
    {
        if(enerygBar.fillAmount == 1)
        {
            return;
        }
        enerygBar.fillAmount += amountOfHeal;
    }
    private void UpdatePageView()
    {
        pageText.text = pageNum.ToString();
    }
    public void IncreasePageNum()
    {
        pageNum++;
        UpdatePageView();
    }
    public short ShowPageNum()
    {
        return pageNum;
    }
    public void PlayPlayerMusic(MusicSO.AuidioTypes auidioType)
    {
       playerMusicSource.PlayOneShot(musics.audioClips.FirstOrDefault(p => p.type == auidioType).audioClips,0.3f);
    }
    public void PlayMainMusic(MusicSO.AuidioTypes audioType)
    {
       mainMusicSource.PlayOneShot(musics.audioClips.FirstOrDefault(p => p.type == audioType).audioClips,0.3f);
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(2);
    }
    public void UpdateViewReloadImage(float delayTime,float timerMultiplier)
    {
        reloadImage.fillAmount += (1 / delayTime) * Time.deltaTime * timerMultiplier;
    }
    public void UpdateViewReloadImage()
    {
        reloadImage.fillAmount = 0;
    }
}
