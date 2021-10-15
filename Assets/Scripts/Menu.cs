using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame() // Переход на сцену MainGame 
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ExitGame() // Выход из программы
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
