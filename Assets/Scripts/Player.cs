using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryCard;

// В скрипт добавить логику противникам и использовать его ко всем игрокам

public class Player : MonoBehaviour
{
    private int score = 100; // Начальный баланс
    List<Card> deck = new List<Card>(); // Создание колоды для игрока

    public int Size // Вывод количество карт в колоде
    {
        get { return deck.Count; }
    }

    public Card SetCard // Добавление карты
    {
        set { deck.Add(value); }
    }

    public Card GetCard(int number) // Вывод карты
    {
        return deck[number];
    }


}
