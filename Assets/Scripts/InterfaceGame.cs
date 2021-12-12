using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGame : MonoBehaviour // ��������� � Canvas 
{
    public MainGame mainGame;
    public Text bank;         // ���-�� ����� � ������� � �������
    public Text coinsPlayer1; // 
    public Text coinsPlayer2; //
    public Text bet;                // ����� ������
    public GameObject bettingPanel; // ������ ������
    public GameObject checkPanel;   // ������ ������ �������� ����
    public GameObject buttonTake;   // ������ ������ �����

    public void Update()
    {
        bank.text = mainGame.Banker.Coins.ToString();          // ������������ ����� � ������� � �������
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
