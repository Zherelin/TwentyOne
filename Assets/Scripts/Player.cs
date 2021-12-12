using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryCard;

// В скрипт добавить логику противникам и использовать его ко всем игрокам

public class Player : MonoBehaviour
{
    private int coins = 0; // Начальный баланс
    List<Card> deck = new List<Card>(); // Создание колоды для игрока

    public int Size { get { return deck.Count; } } // Вывод количество карт в колоде

    public Card SetCard { set { deck.Add(value); } } // Добавление карты

    public Card GetCard(int number) { return deck[number]; } // Вывод карты

    public void DeleteCard(int number) { deck.RemoveAt(number); } // Удаление карты

    public int Score // Вывод количество очков игрока
    {
        get
        {
            int score = 0;
            for (int i = 0; i < deck.Count; i++)
                score += deck[i].Type;
            return score;
        }
    }

    public int Coins // Получение и вывод монет
    {
        get { return coins; }
        set { coins = value; }
    }
}
