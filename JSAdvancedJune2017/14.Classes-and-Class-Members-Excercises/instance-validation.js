class CheckingAccount {
    constructor(clientId, email, firstName, lastName){

        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }
    set clientId(value) {
        if(typeof value === "string" &&
        value.length === 6){
            this._clientId = value;
        } else {
            throw new TypeError("Client ID must be a 6-digit number");
        }
    }

    get email() {
        return this._email;
    }
    set email(value) {
        const regex = /^([a-zA-Z0-9]+@[a-zA-Z0-9\.]+)$/g;
        if(!regex.test(value)){
            throw new TypeError("Invalid e-mail");
        }

        this._email = value;
    }

    get firstName() {
        return this._firstName;
    }
    set firstName(value) {
        const regex = /^[a-zA-Z]+$/g;

        if(value.length < 3 ||
        value.length > 20){
            throw new TypeError("First name must be between 3 and 20 characters long");
        }

        if(!regex.test(value)){
            throw new TypeError("First name must contain only Latin characters");
        }

        this._firstName = value;
    }

    get lastName() {
        return this._lastName;
    }
    set lastName(value) {
        const regex = /^[a-zA-Z]+$/g;

        if(value.length < 3 ||
            value.length > 20){
            throw new TypeError("Last name must be between 3 and 20 characters long");
        }

        if(!regex.test(value)){
            throw new TypeError("Last name must contain only Latin characters");
        }

        this._lastName = value;
    }
}

let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov')