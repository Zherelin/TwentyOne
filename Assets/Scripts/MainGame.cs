using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryCard;

public class MainGame : MonoBehaviour
{
    List<Card> deck = new List<Card>(); // Создание колоды
    public Transform Player1;

    void Shuffling(ref List<Card> deck) // Функция перетасовки карт
    {
        // Усовершенствовать перетасовку!!!
        for (int i = 0; i < 32; i++)
        {
            int random1 = Random.Range(0, 32);
            int random2 = Random.Range(0, 32);

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

        Debug.Log(Player1.position.x + " " + Player1.position.y);
    }
}
