using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] Button PlayButton, FightButton, GachaButton;
    private static Button eosd, pcb, imp, imperishableN, pfv, stb, mof, swr, subAni, ufo;
    [SerializeField] Button[] GameButtons = { eosd, pcb, imp, imperishableN, pfv, stb, mof, swr, subAni, ufo };
    public AudioSource musicSource;
    public AudioClip mmBGM, fightBGM, CharaSelBGM, GachaBGM;
    [SerializeField] Button[] BackButtons;

#nullable enable
    private string? LastMenu, CurrentMenu;
#nullable disable
    private AudioClip LastBGM;

    public bool StartAtMainMenu = false;

    void Start()
    {
        for (int i = 0; i < GameButtons.Length; i++)
        {
            int closureIndex = i;
            GameButtons[closureIndex].onClick.AddListener(delegate { LevelSelectListener(GameButtons[closureIndex].gameObject.name); });
        }

        PlayButton.onClick.AddListener(PlayButtonListener);
        FightButton.onClick.AddListener(FightButtonListener);
        GachaButton.onClick.AddListener(GachaButtonListener);

        for (int i = 0; i < BackButtons.Length; i++)
        {
            int closureIndex = i;
            BackButtons[closureIndex].onClick.AddListener(GoBackMenu);
        }

        if (StartAtMainMenu)
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

            gameObject.transform.Find("MainMenuCanvas").gameObject.SetActive(true);
            CurrentMenu = gameObject.transform.Find("MainMenuCanvas").gameObject.name;
            musicSource.clip = mmBGM;
            musicSource.Play();
        }
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
        CurrentMenu = gameObject.transform.Find("CharacterSelectCanvas").gameObject.name;
        musicSource.clip = CharaSelBGM;
        musicSource.Play();
        Debug.Log($"{LastMenu}, {LastBGM}, current canvas is {CurrentMenu}");
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

        gameObject.transform.Find("LevelSelectCanvas").gameObject.SetActive(true);
        CurrentMenu = gameObject.transform.Find("LevelSelectCanvas").gameObject.name;
        Debug.Log($"{LastMenu}, {LastBGM}, current canvas is {CurrentMenu}");
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
        CurrentMenu = gameObject.transform.Find("GachaMenuCanvas").gameObject.name;
        musicSource.clip = GachaBGM;
        musicSource.Play();
        Debug.Log($"{LastMenu}, {LastBGM}, current canvas is {CurrentMenu}");
    }

    void LevelSelectListener(string buttonName)
    {
        switch (buttonName)
        {
            case "eosd":
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
                CurrentMenu = gameObject.transform.Find("FightCanvas").gameObject.name;
                musicSource.clip = fightBGM;
                musicSource.Play();
                Debug.Log($"{LastMenu}, {LastBGM}, current canvas is {CurrentMenu}");
                break;
        }
    }

    void GoBackMenu()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        if (LastMenu != null)
        {
            if (CurrentMenu == "LevelSelectCanvas")
            {
                gameObject.transform.Find("CharacterSelectCanvas").gameObject.SetActive(true);

                foreach (Transform child in transform)
                {
                    if (child.gameObject.activeInHierarchy)
                    {
                        CurrentMenu = child.name;
                    }
                }

                Debug.Log($"back button pressed, last menu is {LastMenu}, last bgm is {LastBGM}, current menu is {CurrentMenu}");
            } else
            {
                gameObject.transform.Find(LastMenu).gameObject.SetActive(true);
                musicSource.clip = LastBGM;
                musicSource.Play();

                foreach (Transform child in transform)
                {
                    if (child.gameObject.activeInHierarchy)
                    {
                        CurrentMenu = child.name;
                    }
                }

                Debug.Log($"back button pressed, last menu is {LastMenu}, last bgm is {LastBGM}, current menu is {CurrentMenu}");
            }
        } else
        {
            gameObject.transform.Find("MainMenuCanvas").gameObject.SetActive(true);
            musicSource.clip = mmBGM;
            musicSource.Play();

            foreach (Transform child in transform)
            {
                if (child.gameObject.activeInHierarchy)
                {
                    CurrentMenu = child.name;
                }
            }

            Debug.Log("no last menu found, returning to main menu");
        }
        
    }
}
