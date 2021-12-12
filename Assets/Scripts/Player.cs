using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryCard;

// � ������ �������� ������ ����������� � ������������ ��� �� ���� �������

public class Player : MonoBehaviour
{
    private int coins = 0; // ��������� ������
    List<Card> deck = new List<Card>(); // �������� ������ ��� ������

    public int Size { get { return deck.Count; } } // ����� ���������� ���� � ������

    public Card SetCard { set { deck.Add(value); } } // ���������� �����

    public Card GetCard(int number) { return deck[number]; } // ����� �����

    public void DeleteCard(int number) { deck.RemoveAt(number); } // �������� �����

    public int Score // ����� ���������� ����� ������
    {
        get
        {
            int score = 0;
            for (int i = 0; i < deck.Count; i++)
                score += deck[i].Type;
            return score;
        }
    }

    public int Coins // ��������� � ����� �����
    {
        get { return coins; }
        set { coins = value; }
    }
}
