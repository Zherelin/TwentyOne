namespace LibraryCard
{
    enum Suit
    {
        Hearts, // �����
        Spades, // ����
        Diamonds, // �����
        Clubs // ������
    }
    class Card
    {
        private int typeCard; // �������� �����
        private Suit suitCard; // ����� �����

        public Card(int typeCard, Suit suitCard)
        {
            this.typeCard = typeCard;
            this.suitCard = suitCard;
        }

        public int Type
        {
            get { return typeCard; }
        }
        public Suit Suit
        {
            get { return suitCard; }
        }
    }
}
