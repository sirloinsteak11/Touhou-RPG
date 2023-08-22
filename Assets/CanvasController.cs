using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] Button PlayButton, FightButton, GachaButton;
    public AudioSource musicSource;
    public AudioClip mmBGM, fightBGM, CharaSelBGM, GachaBGM;
    [SerializeField] Button[] BackButtons;

    private string LastMenu;
    private AudioClip LastBGM;

    void Start()
    {
        PlayButton.onClick.AddListener(PlayButtonListener);
        FightButton.onClick.AddListener(FightButtonListener);
        GachaButton.onClick.AddListener(GachaButtonListener);

        for (int i = 0; i < BackButtons.Length; i++)
        {
            int closureIndex = i;
            BackButtons[closureIndex].onClick.AddListener(GoBackMenu);
        }

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                LastMenu = child.name;
                LastBGM = musicSource.clip;
            }

            child.gameObject.SetActive(false);
        }

        gameObject.transform.Find("MainMenuCanvas").gameObject.SetActive(true);

        musicSource.clip = mmBGM;
        musicSource.Play();
    }

    void PlayButtonListener()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                LastMenu = child.name;
                LastBGM = musicSource.clip;
            }

            child.gameObject.SetActive(false);
        }

        gameObject.transform.Find("CharacterSelectCanvas").gameObject.SetActive(true);
        musicSource.clip = CharaSelBGM;
        musicSource.Play();
        Debug.Log($"{LastMenu}, {LastBGM}");
    }

    void FightButtonListener()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                LastMenu = child.name;
                LastBGM = musicSource.clip;
            }

            child.gameObject.SetActive(false);
        }

        gameObject.transform.Find("FightCanvas").gameObject.SetActive(true);
        musicSource.clip = fightBGM;
        musicSource.Play();
        Debug.Log($"{LastMenu}, {LastBGM}");
    }

    void GachaButtonListener()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                LastMenu = child.name;
                LastBGM = musicSource.clip;
            }

            child.gameObject.SetActive(false);
        }

        gameObject.transform.Find("GachaMenuCanvas").gameObject.SetActive(true);
        musicSource.clip = GachaBGM;
        musicSource.Play();
        Debug.Log($"{LastMenu}, {LastBGM}");
    }

    void GoBackMenu()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        gameObject.transform.Find(LastMenu).gameObject.SetActive(true);
        musicSource.clip = LastBGM;
        musicSource.Play();
        Debug.Log("back button pressed " + LastMenu + " " + LastBGM);
    }
}
