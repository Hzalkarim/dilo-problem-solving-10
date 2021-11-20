using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneGameManager : MonoBehaviour
{
    public Dropdown buildPicker;
    public int currentActive = 0;

    public GameObject secondaryCam;

    public BuildInfoDisplay infoDisplay;

    void Start()
    {
        buildPicker.onValueChanged.AddListener(OnChangeBuild);
    }

    public void OnChangeBuild(int index)
    {
        if (index > 0)
        {
            secondaryCam.SetActive(false);
            if (currentActive != 0)
            {
                SceneManager.UnloadSceneAsync(currentActive);
            }

            SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            currentActive = index;

            infoDisplay.ShowInfo(index - 1);
        }
        else
        {
            SceneManager.UnloadSceneAsync(currentActive);
            secondaryCam.SetActive(true);
            currentActive = 0;

            infoDisplay.ClearInfo();
        }

    }

    public void GameQuit()
    {
        Application.Quit();
    }

}
