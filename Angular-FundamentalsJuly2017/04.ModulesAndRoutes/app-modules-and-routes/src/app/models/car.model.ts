export class Car {
    constructor(
        public id: Number,
        public make: string,
        public model: string,
        public imageUrl: string,
        public dateOfCreation: Date,
        public comments: Array<string>) { }
}