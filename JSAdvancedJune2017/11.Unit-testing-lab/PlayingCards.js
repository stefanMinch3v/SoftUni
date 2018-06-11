function makeCard(face, suit) {
    const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const suits = ['S', 'H', 'D', 'C'];

    if(!faces.includes(face)) {
        throw new Error('Invalid face');
    }
    if(!suits.includes(suit)){
        throw new Error('Invalid suit');
    }

    let card = {
        suit: suit,
        face: face,
        toString: () => {
            let cardsImages = {
                'S': '\u2660',
                'H': '\u2665',
                'D': '\u2666',
                'C': '\u2663'
            };

            return `${face}${cardsImages[card.suit]}`;
        }
    };

    return card;
}

console.log(makeCard('h', 'S').toString());