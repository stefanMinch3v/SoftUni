function isPalindrome(input) {
    for (let i = 0; i < input.length / 2; i++) {
        // console.log(input[input.length - i - 1]);
        if(input[i] != input[input.length - i - 1]){
            return false;
        }
    }

    return true;
}

console.log(isPalindrome('racecar'));