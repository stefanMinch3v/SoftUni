let test = (function(){

    let Suits = {
        CLUBS: "\u2663",
        DIAMONDS: "\u2666",
        HEARTS: "\u2665",
        SPADES: "\u2660"
    };

    let Faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    class Card {
        constructor(face, suit){
            this.face = face;
            this.suit = suit;
        }

        get suit() {
            return this._suit;
        }
        set suit(value) {
            //!Array.from(Suits).map(k => Suits[k]).includes(value) // the same as below
            if (!Object.keys(Suits).map(k => Suits[k]).includes(value)){
                throw new Error("Invalid card suite: " + value);
            }

            this._suit = value;
        }

        get face() {
            return this._face;
        }
        set face(value) {
            if(!Faces.includes(value)){
                throw new Error("Invalid card face: " + value);
            }

            this._face = value;
        }

        toString() {
            return this._face + this._suit;
        }
    }

    return {
        Suits: Suits,
        Card: Card
    }
})();

let Card = test.Card;
let Suits = test.Suits;

let card = new Card('Q', Suits.DIAMONDS);

console.log(card.toString());