using System;
using System.Collections.Generic;

namespace DemoWeek1
{
    public class CarsDataSet
    {

     private List<Car> cars = new List<Car>();

        public int getCount()
        {
            return cars.Count;
        }

        public void addNewCar(Car newCar)
        {
            cars.Add(newCar);
        }

    }
}
