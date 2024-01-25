using System;
using System.Collections.Generic;

namespace ChumaClasses.Chuma
{
    public abstract class Agent : IEquatable<Agent>, IComparable<Agent>, ICloneable, IComparer<Agent>
    {
        public readonly Guid id; // уникальный идентификатор агента
        public int X { get; set; } // координата X
        public int Y { get; set; } // координата Y
        public int Speed { get; set; } // скорость перемещения

        public Agent(int x, int y, int speed, Guid id)
            => (X, Y, Speed, this.id) = (x, y, speed, id);

        /// <summary>
        /// Обновляет позицию агента
        /// </summary>
        /// <param name="timePassed"></param>
        public void UpdatePosition(double timePassed)
        {
            // изменяем координаты в соответствии со скоростью и временем
            X += (int)(Speed * timePassed);
            Y += (int)(Speed * timePassed);
        }

        /// <summary>
        /// Сериализует объект в формат Json
        /// </summary>
        /// <returns></returns>
        public abstract string SerializeToJson();

        // ниже переопределения методов для хранения и правильной обработки их в коллекциях (обязательно в паре GetHashCode и Equals)
        public override bool Equals(object obj) => base.Equals(obj);
        public bool Equals(Agent other) => other != null && id == other.id;
        public override int GetHashCode() => HashCode.Combine(id, X, Y, Speed);
        public override string ToString() => $"Агент {id} \nX {X} Y {Y} Speed {Speed}";

        public int CompareTo(Agent other)
        {
            if (other == null)
            {
                return 1;
            }

            // сравниваем агентов по их id
            return id.CompareTo(other.id);
        }

        public object Clone()
        {
            // с абстрактным классом только через рефлексию
            Agent agent = (Agent)Activator.CreateInstance(this.GetType(), X, Y, Speed, id);
            return agent;
        }

        public int Compare(Agent x, Agent y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }

            // сравниваем агентов по их id
            return x.id.CompareTo(y.id);
        }
    }
}