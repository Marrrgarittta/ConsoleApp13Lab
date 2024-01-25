using Newtonsoft.Json;
using System;

namespace ChumaClasses.Chuma
{
    // Класс для человека
    public class Person : Agent
    {
        public Person(int x, int y, int speed, bool isInfected, Guid id) : base(x, y, speed, id)
        {
            SetInfectedState(isInfected);
        }

        public bool IsInfected { get; private set; } // заражен ли человек

        public void SetInfectedState(bool infected) => IsInfected = infected;

        public void TryInfect(Agent agent)
        {
            // если переданный агент - человек и этот человек здоров, то он заражается
            if (agent is Person person && !person.IsInfected)
            {
                person.SetInfectedState(true);
            }
        }

        public override string SerializeToJson() => JsonConvert.SerializeObject(this);
    }
}