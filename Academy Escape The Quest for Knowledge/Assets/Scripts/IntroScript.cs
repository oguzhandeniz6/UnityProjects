using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] TextMeshProUGUI puanText;
    [SerializeField] Image[] panels; 
    private int basmaSayisi = 0;
    SoundSource soundSource;
    GameManager gameManager;
    private void Awake()
    {
        soundSource = FindFirstObjectByType<SoundSource>();
        gameManager = FindAnyObjectByType<GameManager>();
        puanText = FindObjectsOfType<TextMeshProUGUI>().FirstOrDefault(p => p.tag == "Point");
    }
    private void Start()
    {
        soundSource.PlayMainMusic(MusicSO.AuidioTypes.MainStoryMusic);
        if(puanText != null)
        {
            if(gameManager.pageNum == 3)
            {
                puanText.text = "Kazandýn Puan: " + (gameManager.pageNum * 100).ToString();
                return;
            }
            puanText.text = "Puan: " + (gameManager.pageNum * 100).ToString();
        }
    }
    public void OnClick()
    {
        Next();
        soundSource.PlayPlayerMusic(MusicSO.AuidioTypes.ButtonClickSound);
    }
    public void OnClickReStart()
    {
        SceneManager.LoadScene(0);
        Destroy(gameManager);
        soundSource.PlayPlayerMusic(MusicSO.AuidioTypes.ButtonClickSound);
    }
    void Next()
    {
        basmaSayisi++;
        switch (basmaSayisi)
        {
            case 4:
                buttonText.text = "Start";
                break;
            case 5:
                SceneManager.LoadScene(1);
                break;
            default:
                break;
        }
        if(panels.Length < basmaSayisi)
        {
            return;
        }
        for (int i = 0; i < basmaSayisi; i++)
        {
            panels[i].gameObject.SetActive(true);
            if (i > 0)
            {
                panels[i - 1].gameObject.SetActive(false);
            }
        }
    }
}
