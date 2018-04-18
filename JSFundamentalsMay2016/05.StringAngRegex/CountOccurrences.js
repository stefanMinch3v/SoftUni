function countSame(pattern, text) {
    let counter = 0;
    let index = text.indexOf(pattern, 0);

    while(index !== -1){
        counter++;
        index = text.indexOf(pattern, ++index)
    }

    return counter;
}

console.log(countSame('ma', 'Marine mammal training is the training and caring for marine life such as, dolphins, killer whales, sea lions, walruses, and other marine mammals. It is also a duty of the trainer to do mental and physical exercises to keep the animal healthy and happy.'));