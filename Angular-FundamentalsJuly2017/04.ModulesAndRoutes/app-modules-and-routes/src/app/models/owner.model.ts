import { Car } from '../models/car.model';

export class Owner {
    constructor(
        public id: Number,
        public firstName: string,
        public lastName: string,
        public age: number,
        public cars: Array<Car>) { }
}