﻿using tp4.Models;

namespace tp4.CarRepository
{
	public interface ICarRepository
	{
		IEnumerable<Car> Get();
		Car Get(string id);
		Car Create(Car car);
		void Update(string id, Car carIn);
		void Remove(Car carIn);
		void Remove(string id);
	}
}
