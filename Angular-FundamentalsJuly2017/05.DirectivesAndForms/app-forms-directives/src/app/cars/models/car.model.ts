export class Car {
    constructor(
        public id: number,
        public make: string,
        public model: string,
        public imageUrl: string,
        public engine: number,
        public dateOfCreation: Date) { }
}