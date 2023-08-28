using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField] Button PlayButton, FightButton, GachaButton;
    private static Button eosd, pcb, imp, imperishableN, pfv, stb, mof, swr, subAni, ufo;
    [SerializeField] Button[] GameButtons = { eosd, pcb, imp, imperishableN, pfv, stb, mof, swr, subAni, ufo };
    private static Button eosd1, eosd2, eosd3, eosd4, eosd5, eosd6, eosdextra;
    [SerializeField] Button[] EOSDStageSelectionButtons = { eosd1, eosd2, eosd3, eosd4, eosd5, eosd6, eosdextra };
    private static Button eosd1weak, eosd1normal, eosd1strong, eosd1midboss, eosd1boss;
    [SerializeField] Button[] EOSDStage1Buttons = { eosd1weak, eosd1normal, eosd1strong, eosd1midboss, eosd1boss };
    public AudioSource musicSource;
    public AudioClip mmBGM, EOSDFightBGM, CharaSelBGM, GachaBGM;
    [SerializeField] Button[] BackButtons;

    //Fight Canvas UI Elements
    public TextMeshProUGUI battleLog, playerTitle, enemyTitle, playerHealth, enemyHealth;
    public Image playerSprite, enemySprite;
    public Sprite[] enemySpriteList;

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

        for (int i = 0; i < EOSDStageSelectionButtons.Length; i++)
        {
            int CI = i;
            EOSDStageSelectionButtons[CI].onClick.AddListener(delegate { StageSelectionListener("eosd", EOSDStageSelectionButtons[CI].gameObject.name); });
        }

        for (int i = 0; i < EOSDStage1Buttons.Length; i++)
        {
            int CI = i;
            EOSDStage1Buttons[CI].onClick.AddListener(delegate { StartFight(CheckButtonType(EOSDStage1Buttons[CI].gameObject.name), CheckButtonGame(EOSDStage1Buttons[CI].gameObject.name), CheckButtonStage(EOSDStage1Buttons[CI].gameObject.name), CheckButtonLevel(EOSDStage1Buttons[CI].gameObject.name), CheckButtonDifficulty(EOSDStage1Buttons[CI].gameObject.name)); });
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        switch (buttonName)
        {
            case "eosd":
                GameObject EOSDStageSelection = gameObject.transform.Find("LevelSelectCanvas").gameObject.transform.Find("EOSDStageSelection").gameObject;
                GameObject EOSDStage1 = gameObject.transform.Find("LevelSelectCanvas").gameObject.transform.Find("EOSDStage1").gameObject;
                /*  foreach (Transform child in transform)
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
                  break; */
                if (EOSDStageSelection.activeInHierarchy)
                {
                    EOSDStageSelection.SetActive(false);
                    EOSDStage1.SetActive(false);

                } else
                {
                    EOSDStageSelection.SetActive(true);
                    EOSDStageSelection.transform.position = mousePosition;
                }
                break;
        }
    }

    void StageSelectionListener(string game, string stage)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject EOSDStage1 = gameObject.transform.Find("LevelSelectCanvas").gameObject.transform.Find("EOSDStage1").gameObject;

        if (game == "eosd")
        {
            if (stage == "eosdstage1")
            {
                if (EOSDStage1.activeInHierarchy)
                {
                    EOSDStage1.SetActive(false);
                }
                else
                {
                    EOSDStage1.SetActive(true);
                    EOSDStage1.transform.position = mousePosition;
                }
            }
        }
    }   

    string CheckButtonType(string buttonName)
    {
        if (buttonName.Contains("Enemy"))
            return "enemy";

        if (buttonName.Contains("Midboss"))
            return "midboss";

        if (buttonName.Contains("Boss"))
            return "boss";

        return "err";
    }

    string CheckButtonGame(string buttonName)
    {
        if (buttonName.Contains("EOSD"))
            return "eosd";

        return "err";
    }

    string CheckButtonStage(string buttonName)
    {
        if (buttonName.Contains("Stage1"))
            return "stage1";

        return "err";
    }

    string CheckButtonLevel(string buttonName)
    {
        if (buttonName.Contains("enemy1"))
            return "enemy1";

        if (buttonName.Contains("enemy2"))
            return "enemy2";

        if (buttonName.Contains("enemy3"))
            return "enemy3";

        if (buttonName.Contains("enemy4"))
            return "enemy4";

        if (buttonName.Contains("enemy5"))
            return "enemy5";

        return "err";
    }

    int CheckButtonDifficulty(string buttonName)
    {
        if (buttonName.Contains("Easy"))
            return 1;

        return -1;
    }

    // type: enemy, midboss, boss;
    void StartFight(string type, string game, string stage, string level, int difficulty)
    {
        Debug.Log($"StartFight invoked with arguments: {type}, {game}, {stage}, {level}, {difficulty}");

        if (type == "enemy")
        {
            if (game == "eosd")
            {
                if (stage == "stage1")
                {
                    if (level == "enemy1")
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
                        CurrentMenu = gameObject.transform.Find("FightCanvas").gameObject.name;
                        musicSource.clip = EOSDFightBGM;
                        musicSource.Play();

                        battleLog.text = "Weak fairy has appeared !!!";
                        playerTitle.text = "Lv1 Reimu"; //change later
                        enemyTitle.text = "Lv1 Fairy";
                        enemyHealth.text = "100 / 100"; // change later
                        playerHealth.text = "100 / 100"; //change later
                        enemySprite.sprite = enemySpriteList[0];
                        enemySprite.preserveAspect = true;

                        Debug.Log($"{LastMenu}, {LastBGM}, current canvas is {CurrentMenu}");
                    }
                }
            }
        }

        if (type == "midboss")
        {
            if (game == "eosd")
            {
                if (stage == "stage1")
                {
                    if (level == "enemy4")
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
                        CurrentMenu = gameObject.transform.Find("FightCanvas").gameObject.name;
                        if (musicSource.clip != EOSDFightBGM)
                        {
                            musicSource.clip = EOSDFightBGM;
                            musicSource.Play();
                        }

                        battleLog.text = "A mysterious individual has appeared !!!";
                        playerTitle.text = "Lv1 Reimu"; //change later
                        enemyTitle.text = "Lv5 ???";
                        enemyHealth.text = "100 / 100"; // change later
                        playerHealth.text = "500 / 500"; //change later
                        enemySprite.sprite = enemySpriteList[1];
                        enemySprite.preserveAspect = true;

                        Debug.Log($"{LastMenu}, {LastBGM}, current canvas is {CurrentMenu}");
                    }
                }
            }
        }

        if (type == "boss")
        {

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
                musicSource.clip = CharaSelBGM;
                musicSource.Play();

                foreach (Transform child in transform)
                {
                    if (child.gameObject.activeInHierarchy)
                    {
                        CurrentMenu = child.name;
                    }
                }

                Debug.Log($"back button pressed, last menu is {LastMenu}, last bgm is {LastBGM}, current menu is {CurrentMenu}");
            } else if (CurrentMenu == "FightCanvas")
            {
                gameObject.transform.Find(LastMenu).gameObject.SetActive(true);

                foreach (Transform child in transform)
                {
                    if (child.gameObject.activeInHierarchy)
                    {
                        CurrentMenu = child.name;
                    }
                }

                Debug.Log($"back button pressed back to level select canvas, last menu is {LastMenu}, last bgm is {LastBGM}, current menu is {CurrentMenu}");
            }
            else
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
