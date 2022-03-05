using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public void loadlevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void exit()
    {
        Application.Quit();
    }
}
