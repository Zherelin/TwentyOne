using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryCard;

// � ������ �������� ������ ����������� � ������������ ��� �� ���� �������

public class Player : MonoBehaviour
{
    private int score = 100; // ��������� ������
    List<Card> deck = new List<Card>(); // �������� ������ ��� ������

    public int Size // ����� ���������� ���� � ������
    {
        get { return deck.Count; }
    }

    public Card SetCard // ���������� �����
    {
        set { deck.Add(value); }
    }

    public Card GetCard(int number) // ����� �����
    {
        return deck[number];
    }


}
