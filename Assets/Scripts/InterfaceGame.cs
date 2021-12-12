using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGame : MonoBehaviour // Прикреплён к Canvas 
{
    public MainGame mainGame;
    public Text bank;         // Кол-во монет у банкира и игроков
    public Text coinsPlayer1; // 
    public Text coinsPlayer2; //
    public Text bet;                // Текст ставок
    public GameObject bettingPanel; // Панель ставок
    public GameObject checkPanel;   // Панель выбора действий игры
    public GameObject buttonTake;   // Кнопка взятия карты

    public void Update()
    {
        bank.text = mainGame.Banker.Coins.ToString();          // Демонстрация монет у игроков и банкира
        coinsPlayer1.text = mainGame.Player1.Coins.ToString(); // 
        coinsPlayer2.text = mainGame.Player2.Coins.ToString(); //

        if(mainGame.CheckBet() == false)
        {
            bettingPanel.SetActive(true);
            checkPanel.SetActive(false);
            bet.text = mainGame.Bet().ToString();
        }
        else
        {
            bettingPanel.SetActive(false);
            checkPanel.SetActive(true);

            if (mainGame.MaxCards() == true)
                buttonTake.SetActive(false);
            else
                buttonTake.SetActive(true);
        }
    }
}
