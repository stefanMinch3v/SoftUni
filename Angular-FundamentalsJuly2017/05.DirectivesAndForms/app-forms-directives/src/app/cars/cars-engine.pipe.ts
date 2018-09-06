import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'horsePowers'
})
export class CarsEnginePipe implements PipeTransform {
    transform(value: number) {
        return value + 'hp';
    }
}