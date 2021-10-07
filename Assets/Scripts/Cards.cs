using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class Card
    {
        private int typeCard; // Тип карты
        private int suitCard; // Масть карты

        public Card(int typeCard, int suitCard)
        {
            this.typeCard = typeCard;
            this.suitCard = suitCard;
        }
    }
}
