using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryCard;

public class MainGame : MonoBehaviour
{
    List<Card> deck = new List<Card>(); // Создание колоды
    List<Card> banker = new List<Card>(); // Создание колоды для банкира
    public Transform PosPlayer1;
    public Player Player1;
    bool show = false; // Переключатель ! Временно !

    void Shuffling(ref List<Card> deck) // Функция перетасовки карт
    {
        // Усовершенствовать перетасовку!!!
        for (int i = 0; i < deck.Count; i++)
        {
            int random1 = Random.Range(0, deck.Count);
            int random2 = Random.Range(0, deck.Count);

            Card nullCard = deck[random1];
            deck[random1] = deck[random2];
            deck[random2] = nullCard;
        }
    }
    public void Start()
    {
        for(int type = 2; type <= 11; type++) // Заполнение колоды картами
        {
            if (type == 5)
                continue;

            for(int suit = 0; suit < 4; suit++)
            {
                if (suit == 0)
                    deck.Add(new Card(type, Suit.Hearts));
                if (suit == 1)
                    deck.Add(new Card(type, Suit.Spades));
                if (suit == 2)
                    deck.Add(new Card(type, Suit.Diamonds));
                if (suit == 3)
                    deck.Add(new Card(type, Suit.Clubs));
            }
        }
        Shuffling(ref deck);

        BankerTakeCard();      //
        TakeCard(ref Player1); // Добавление карт банкиру и игроку (пока только одному)
        TakeCard(ref Player1); //

    }

    public void Update()
    {
        if(show == true)
        {
            int scorePlayer = Score(ref Player1);
            Debug.Log("Score player1 = " + scorePlayer);
            show = false;
        }
    }


    //
    // Основные функции
    //
    public void TakeCard(ref Player player) // Взять карту игроку
    {
        int num = Random.Range(0, deck.Count);
        player.SetCard = deck[num];
        deck.RemoveAt(num);
    }
    public void TakeCard() // Взять карту игроку, функция к кнопке
    {
        int num = Random.Range(0, deck.Count);
        Player1.SetCard = deck[num];
        deck.RemoveAt(num);
    }
    public void ShowCards() // Переключатель для показа карт !!! Возможно нужно изменить !!!
    {
        show = true;
    }
    private void BankerTakeCard() // Взять карту банкиру
    {
        int num = Random.Range(0, deck.Count);
        banker.Add(deck[num]);
        deck.RemoveAt(num);
    }
    public void SetCardGame() // !!! Временная функция для вывода колоды игрока
    {
        for (int i = 0; i < Player1.Size; i++)
            Debug.Log("Card " + i + ": " + Player1.GetCard(i).Type + " " + Player1.GetCard(i).Suit);
    }
    public int Score(ref Player player) // Подсчёт очков игрока
    {
        int score = 0;
        for (int i = 0; i < player.Size; i++)
            score += player.GetCard(i).Type;
        return score;
    }
}
