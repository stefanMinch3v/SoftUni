import { Owner } from '../models/owner.model';
import { Car } from '../models/car.model';
import { data } from './seed';

export class OwnerCarsData {
    getData(): Array<Owner> {
        const owners: Array<Owner> = [];
        for (let i = 0; i < data.length; i++) {
            const cars: Array<Car> = [];
            for (let j = 0; j < data[i].cars.length; j++) {
                let currentCar = data[i].cars[j];
                cars[j] = new Car(
                    currentCar.id,
                    currentCar.make,
                    currentCar.model,
                    currentCar.imageUrl,
                    new Date(currentCar.dateOfCreation),
                    currentCar.comments);
            }

            owners[i] = new Owner(
                data[i].id,
                data[i].firstName,
                data[i].lastName,
                data[i].age,
                cars);
        }

        return owners;
    }
}