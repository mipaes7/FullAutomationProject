using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Builders
{
    public class CreditCard
    {
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CardPINCode { get; set; }
        public string CardExpirationDateMM { get; set; }
        public string CardExpirationDateYYYY { get; set; }
    }

    public class CreditCardBuilder
    {
        private CreditCard creditCard;

        public CreditCardBuilder()
        {
            creditCard = new CreditCard();
        }

        public CreditCardBuilder WithNameOnCard(string nameOnCard)
        {
            creditCard.NameOnCard = nameOnCard;
            return this;
        }

        public CreditCardBuilder WithCardNumber(string cardNumber)
        {
            creditCard.CardNumber = cardNumber;
            return this;
        }

        public CreditCardBuilder WithCardPINCode(string cardPINCode)
        {
            creditCard.CardPINCode = cardPINCode;
            return this;
        }

        public CreditCardBuilder WithCardExpirationDateMM(string expirationDateMM)
        {
            creditCard.CardExpirationDateMM = expirationDateMM;
            return this;
        }

        public CreditCardBuilder WithCardExpirationDateYYYY(string expirationDateYYYY)
        {
            creditCard.CardExpirationDateYYYY = expirationDateYYYY;
            return this;
        }

        public CreditCard Build()
        {
            return creditCard;
        }
    }

}
