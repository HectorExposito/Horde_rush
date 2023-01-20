using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceBarManager : MonoBehaviour
{
    public Image experienceBar;

    public int currentExperience;
    public int experienceToNextLevel;
    public int level;
    public TMP_Text text;
    public PlayerManager playerManager;
    void Start()
    {
        currentExperience = 0;
        level = 0;
        experienceToNextLevel = 100;
        updateExperienceBar(0);
    }

    public void updateExperienceBar(int experience)
    {
        currentExperience += experience;
        if (currentExperience >= experienceToNextLevel)
        {
            levelUp();
        }
        experienceBar.fillAmount = (float)currentExperience / experienceToNextLevel;
        text.text = "LEVEL " + level.ToString();
    }

    private void levelUp()
    {
        level++;
        playerManager.levelUp();
        currentExperience -= experienceToNextLevel;
        setExperienceToNextLevel();
    }

    private void setExperienceToNextLevel()
    {
        if (level < 3)
        {
            experienceToNextLevel =(int) (experienceToNextLevel * 1.2f);
        }else if(level < 6)
        {
            experienceToNextLevel = (int)(experienceToNextLevel * 1.3f);
        }
        else
        {
            experienceToNextLevel = (int)(experienceToNextLevel * 1.5f);
        }
    }
}
