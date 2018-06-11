function tickets(arr, order) {
    let result = [];

    class Ticket {
        constructor(destination, price, status){
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    function produceTicket(destinationName, price, status) {
        return new Ticket(destinationName, price, status);
    }

    for (let line of arr) {
        let tokens = line.split("|");
        let destinationName = tokens[0];
        let price = tokens[1];
        let status = tokens[2];

        result.push(produceTicket(destinationName, price, status));
    }

    if(order === "destination"){
        result.sort((a, b) => a.destination > b.destination);
    } else if(order === "status"){
        result.sort((a, b) => a.status > b.status);
    } else if(order === "price"){
        result.sort((a, b) => a.price > b.price);
    }

    return result;
}

console.log(tickets(['Philadelphia|94.20|available'], 'status'));