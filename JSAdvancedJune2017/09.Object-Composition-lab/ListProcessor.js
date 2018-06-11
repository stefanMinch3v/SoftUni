function processor(arr) {
    let result = [];

    for (let element of arr) {
        let command = element.split(' ');

        switch (command[0]){
            case 'add':
                add(command[1]);
                break;
            case 'remove':
                remove(command[1]);
                break;
            case 'print':
                print();
                break;
        }
    }

    function add(value) {
        result.push(value);
    }

    function remove(value) {
        result = result.filter(e => e !== value);
    }

    function print() {
        console.log(result.join(','));
    }
}

processor(['add pesho', 'add gosho', 'add pesho', 'remove pesho','print']);