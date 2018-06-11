function cars(arrCommands) {
    let commandsIffy = (function () {
        let map = new Map();

        function create(name, param, parent) {
            if(param) {
                inherit(name, parent);
            } else {
                map.set(name, {});
            }
        }

        function inherit(name, parent) {
            map.set(name, Object.create(map.get(parent)));
        }

        function set(objName, propName, value) {
            map.get(objName)[propName] = value;
        }

        function print(name) {
            let object = map.get(name);
            let props = [];
            for (let prop in object) {
                props.push(`${prop}:${object[prop]}`);
            }
            console.log(props.join(', '));
        }

        return {
            create,
            inherit,
            set,
            print
        };
    })();

    for (let cmd of arrCommands) {
        let [command, name, param, value] = cmd.split(' ');

        commandsIffy[command](name, param, value);
    }
}

cars([
    'create c1',
    'create c2 inherit c1',
    'set c1 model bmw',
    'set c2 color black',
    'print c1',
    'print c2'
]);