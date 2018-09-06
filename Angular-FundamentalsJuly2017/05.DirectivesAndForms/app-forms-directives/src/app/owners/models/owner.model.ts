import { Car } from "../../cars/models/car.model";

export class Owner {
    constructor(
        public id: number,
        public firstName: string,
        public lastName: string,
        public age: number,
        public cars: Array<Car>) { }
}