using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject MainMenu, FightMenu;
    [SerializeField] Button PlayButton;
    public AudioSource musicSource;
    public AudioClip mmBGM, fightBGM;

    void Start()
    {
        PlayButton.onClick.AddListener(SwitchMenu);
        musicSource.clip = mmBGM;
        musicSource.Play();
    }

    void SwitchMenu()
    {
        if (MainMenu.activeInHierarchy)
        {
            MainMenu.SetActive(false);
            FightMenu.SetActive(true);
            musicSource.clip = fightBGM;
            musicSource.Play();
        }
    }
}
