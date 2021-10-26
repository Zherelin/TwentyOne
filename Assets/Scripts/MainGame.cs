using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibraryCard;

public class MainGame : MonoBehaviour
{
    List<Card> deck = new List<Card>(); // �������� ������
    List<Card> deckWagered = new List<Card>(); // ���������� ������
    int bank = 300; // ���� ����
    public Player Banker;
    public Player Player1; 
    public Player Player2;
    private int queue = 0; // ������� ������ � ������� ������ ������
    private bool showCards = false; // �������������  ��� ������ ������ ����
    private int bet = 0; // ������
    private bool checkBet = false; // ������������� ��� ������ ������

    private Player[] players = new Player[2]; // ������ �������
    

    void Shuffling(ref List<Card> deck) // ������� ����������� ����
    {
        // ����������������� �����������!!!
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
        for(int type = 2; type <= 11; type++) // ���������� ������ �������
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

        Banker.Coins = bank;  // ���������� ������� ����� �����
        Player1.Coins = 100; //
        Player2.Coins = 100; // ���������� ������� ��������� �����

        players[0] = Player1; // ���������� ������� � ����� ������
        players[1] = Player2; //

        StartCoroutine(StartGame());
    }

    IEnumerator StartGame() // ������� ������ ����
    {
        while (Banker.Coins > 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                queue = i;
                TakeCard(ref players[queue]); // ���������� ����� ������
                TakeCard(ref Banker); // ���������� ����� ������� (������ ����� ��� ������ ����� ����� �������� ����� ������� ������)

                // �������� !!!
                // ������ ������
                bet = 5;
                players[queue].Coins -= 5;
                yield return new WaitUntil(() => checkBet == true);
                Banker.Coins -= bet;
                bet *= 2;
                //

                yield return new WaitUntil(() => showCards == true);
                Debug.Log("Score player" + i + ": " + players[i].Score); // !!! �������� !!!

                // �������� ������ �������

                DeckWagered(ref players[queue]);
                DeckWagered(ref Banker);
                checkBet = false;
                showCards = false;
            }
            DeckWageredDelete();
        }
    }


    //
    // �������� �������
    //
    public void TakeCard(ref Player player) // ����� ����� ������
    {
        int num = Random.Range(0, deck.Count);
        player.SetCard = deck[num];
        deck.RemoveAt(num);
    }

    public void TakeCard() // ����� ����� ������ �� ������� ������
    {
        int num = Random.Range(0, deck.Count);
        players[queue].SetCard = deck[num];
        deck.RemoveAt(num);
    }

    public void ShowCards() { showCards = true; } // ������������� ��� ������ ���� 

    public void SetCard() // !!! ��������� ������� ��� ������ ������ ������ !!!
    {
        Debug.Log("Player" + (queue + 1));
        for (int i = 0; i < players[queue].Size; i++)
            Debug.Log("Card " + (i + 1) + ": " + players[queue].GetCard(i).Type + " " + players[queue].GetCard(i).Suit);

        Debug.Log("Banker card: " + Banker.GetCard(0).Type + " " + Banker.GetCard(0).Suit);

        Debug.Log("Deck Wagered = " + deckWagered.Count);
        for (int i = 0; i < deckWagered.Count; i++)
            Debug.Log("Wagered Card " + (i + 1) + ": " + deckWagered[i].Type + " " + deckWagered[i].Suit);
    }

    public void DeckWagered(ref Player player) // ����������� ������ ���� ������ � ������� � ���������� ������
    {
        int size = player.Size;
        for(int i = 0; i < size; i++)
        {
            deckWagered.Add(player.GetCard(0));
            player.DeleteCard(0);
        }
    }

    private void DeckWageredDelete() // �������� ���������� ������ � �������������� ���������
    {
        int size = deckWagered.Count;
        for (int i = 0; i < size; i++)
        {
            deck.Add(deckWagered[0]);
            deckWagered.RemoveAt(0);
        }
    }

    public void SizeDeck() // �������� !!!
    {
        Debug.Log("Size deck = " + deck.Count);
    }

    // ! �� ������ � ������������� ���� 3 ������� !
    public int Queue() { return queue; } 
    public int Bet() { return bet; }
    public bool CheckBet() { return checkBet; }

    public void BetPlace() { checkBet = true; } // ������� ������

    public void BetIncrease() // ���������� ������
    {
        if(players[queue].Coins > 0 && bet < Banker.Coins)
        {
            players[queue].Coins -= 5;
            bet += 5;
        }
    }
    public void BetReduction() // ���������� ������
    {
        if (bet > 5)
        {
            players[queue].Coins += 5;
            bet -= 5;
        }
    }
}
