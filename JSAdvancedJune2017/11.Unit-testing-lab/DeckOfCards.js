function getCards(cards) {
    const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const suits = ['S', 'H', 'D', 'C'];
    const cardsImages = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663'
    };
    let deck = [];

    for (let card of cards) {
        let suit = card.substring(card.length - 1);
        let face = card.substring(0, card.length - 1);

        try {
            if(!faces.includes(face)) {
                throw new Error(`Invalid card: ${card}`);
            }
            if(!suits.includes(suit)){
                throw new Error(`Invalid card: ${card}`);
            }
        } catch (err){
            console.log(err.message);
            return;
        }

        deck.push(`${face}${cardsImages[suit]}`);
    }

    console.log(deck.join(' '));
}

getCards(['AS', '10D', 'KH', '1C']);