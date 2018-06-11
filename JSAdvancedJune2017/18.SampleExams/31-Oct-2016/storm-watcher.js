//let weather =
(function () {
    let idIncrement = 0;

    class StormWatcher {
        constructor(temperature, humidity, pressure, windSpeed) {
            this.id = idIncrement++;
            this.temperature = Number(temperature);
            this.humidity = Number(humidity);
            this.pressure = Number(pressure);
            this.windSpeed = Number(windSpeed);
        }

        checkWeatherStatus() {
            if(this.temperature < 20 &&
                (this.pressure < 700 || this.pressure > 900) &&
                this.windSpeed > 25) {
                return "Stormy";
            }

            return "Not stormy";
        }

        toString() {
            let result = '';
            result += `Reading ID: ${this.id}\n`;
            result += `Temperature: ${this.temperature}*C\n`;
            result += `Relative Humidity: ${this.humidity}%\n`;
            result += `Pressure: ${this.pressure}hpa\n`;
            result += `Wind Speed: ${this.windSpeed}m/s\n`;
            result += `Weather: ${this.checkWeatherStatus()}`;
            return result;
        }
    }

    return StormWatcher;
})();

// let result = new weather.StormWatcher(32, 66, 760, 12);
// let result2 = new weather.StormWatcher(10, 40, 680, 30);
//
// console.log(result.toString());
// console.log(result2.toString());

// solution with static func
class StormWatcher {
    constructor(temperature, humidity, pressure, windSpeed) {
        this.id = StormWatcher.getId();
        this.temperature = Number(temperature);
        this.humidity = Number(humidity);
        this.pressure = Number(pressure);
        this.windSpeed = Number(windSpeed);
    }

    checkWeatherStatus() {
        if(this.temperature < 20 &&
            (this.pressure < 700 || this.pressure > 900) &&
            this.windSpeed > 25) {
            return "Stormy";
        }

        return "Not stormy";
    }

    static getId() {
        if(StormWatcher.getId() === undefined) {
            StormWatcher.nextId = 0;
        }

        return StormWatcher.nextId++;
    }

    toString() {
        let result = '';
        result += `Reading ID: ${this.id}\n`;
        result += `Temperature: ${this.temperature}*C\n`;
        result += `Relative Humidity: ${this.humidity}%\n`;
        result += `Pressure: ${this.pressure}hpa\n`;
        result += `Wind Speed: ${this.windSpeed}m/s\n`;
        result += `Weather: ${this.checkWeatherStatus()}`;
        return result;
    }
}