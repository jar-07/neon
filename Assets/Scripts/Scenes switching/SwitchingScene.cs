using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchingScene : MonoBehaviour
{
    public void SwitchToIntro()
    {
        SceneManager.LoadScene("Intro");
        //Debug.Log("Loading Intro");
    }
    public void SwitchToStartingMenu()
    {
        SceneManager.LoadScene("StartingMenu");
        //Debug.Log("Loading StartingMenu");
    }
    public void SwitchToGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
        //Debug.Log("Loading GamePlay");
    }
}
