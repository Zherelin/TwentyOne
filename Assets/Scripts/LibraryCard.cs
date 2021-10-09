namespace LibraryCard
{
    enum Suit
    {
        Hearts, // Черви
        Spades, // Пики
        Diamonds, // Бубны
        Clubs // Крести
    }
    class Card
    {
        private int typeCard; // Значение карты
        private Suit suitCard; // Масть карты

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
