using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame() // ������� �� ����� MainGame 
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ExitGame() // ����� �� ���������
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
