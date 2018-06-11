class Rat {
    constructor(name) {
        this.name = name;
        this.unitedRats = [];
    }

    unite(obj) {
        if(obj instanceof Rat){
            this.unitedRats.push('##' + obj);
        }
    }

    toString() {
        let result = this.name + '\n';
        for (let rat of this.unitedRats) {
            result += `${rat.name}\n`;
        }

        return result.trim();
    }

    getRats() {
        return this.unitedRats;
    }
}

let test = new Rat("Pesho");
console.log(test.toString()); //Pesho

console.log(test.getRats()); //[]

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());


console.log(test.toString());
