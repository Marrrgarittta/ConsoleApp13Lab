using ChumaClasses.Chuma;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// Выводим количество и элементы списка на экран
        /// </summary>
        /// <param name="arlist"></param>
        static void PrintArrayList(ArrayList arlist)
        {
            Console.WriteLine($"Количество элементов в ArrayList: {arlist.Count}");
            foreach (object obj in arlist)
                Console.WriteLine(obj);           
        }
     
        static void PrintList(List<float> list)
        {
            Console.WriteLine($"Количество элементов в списке: {list.Count}");
            foreach (var el in list)
                Console.WriteLine(el);
        }

        static void PrintList(List<Agent> list)
        {
            Console.WriteLine($"Количество элементов в списке: {list.Count}");
            foreach (var el in list)
                Console.WriteLine(el);
        }

        static void PrintStack(Stack<float> stack)
        {
            Console.WriteLine($"Количество элементов в стеке: {stack.Count}");
            foreach (var el in stack)
                Console.WriteLine(el);            
        }

        static void PrintStack(Stack<Agent> stack)
        {
            Console.WriteLine($"Количество элементов в стеке: {stack.Count}");
            foreach (var el in stack)
                Console.WriteLine(el);
        }

        static void FirstStep()
        {
            // a
            ArrayList arlist = new ArrayList() { 5, 3, 9, 7, 4 };
            PrintArrayList(arlist);
            // b
            string elem = "ABC";
            arlist.Add(elem);
            // c
            arlist.Remove(elem);
            // d
            PrintArrayList(arlist);
            // e
            var i = arlist.IndexOf(elem);
            if (i == -1)
                Console.WriteLine("Элемент не найден");
            else
                Console.WriteLine("Элемент найден!");
        }

        static void SecondStep()
        {
            List<float> list = new List<float>();
            list.Add(1.2f);
            list.Add(3.4f);
            list.Add(5.6f);
            list.Add(7.8f);

            // a) Выведите коллекцию на консоль
            Console.WriteLine("Список до удаления:");
            PrintList(list);

            // b) Удалите из коллекции n элементов
            int n = 2;
            for (int i = 0; i < n; i++)
                list.RemoveAt(0);
            
            Console.WriteLine("Список после удаления:");
            PrintList(list);

            // c) Добавьте другие элементы(используйте все возможные методы добавления для вашей коллекции).
            list.Add(89.1f);
            list.AddRange(new float[] { 9.0f, 11.2f });
            list.Insert(0, 0.1f);
            list.InsertRange(2, new float[] { 2.3f, 4.5f });

            Console.WriteLine("Список после добавления:");
            PrintList(list);

            //d) Создайте вторую коллекцию Stack<T> и заполните ее данными из первой коллекции. 
            Stack<float> stack = new Stack<float>();

            foreach (float value in list)
                stack.Push(value);

            // e) Выведите вторую коллекцию на консоль.
            PrintStack(stack);
            // f) Найдите во второй коллекции заданное значение.
            var findEl = 2.3f;
            var isContains = stack.Contains(findEl);
            if (isContains)
                Console.WriteLine("Значение найдено в стеке");  
            else
                Console.WriteLine("Значение не найдено в стеке");
        }

        static void ThirdStep()
        {
            List<Agent> list = new List<Agent>();
            list.Add(new Person(x: 0, y: 0, speed: 7, isInfected: true, id: Guid.NewGuid()));
            list.Add(new Person(x: 1, y: 4, speed: 8, isInfected: false, id: Guid.NewGuid()));
            list.Add(new Person(x: 2, y: 5, speed: 9, isInfected: true, id: Guid.NewGuid()));
            var p = new Person(x: 3, y: 6, speed: 1, isInfected: false, id: Guid.NewGuid());
            list.Add(p);

            // a) Выведите коллекцию на консоль
            Console.WriteLine("Список до удаления:");
            PrintList(list);

            // b) Удалите из коллекции n элементов
            int n = 1;
            for (int i = 0; i < n; i++)
                list.RemoveAt(0);

            Console.WriteLine("Список после удаления:");
            PrintList(list);

            // c) Добавьте другие элементы(используйте все возможные методы добавления для вашей коллекции).
            list.Add(new Person(x: 21, y: 51, speed: 91, isInfected: true, id: Guid.NewGuid()));
            list.AddRange(new Agent[] { list[0], list[1] });
            list.Insert(0, list[0]);
            list.InsertRange(2, new Agent[] { list[0], list[1] });

            Console.WriteLine("Список после добавления:");
            PrintList(list);

            //d) Создайте вторую коллекцию Stack<T> и заполните ее данными из первой коллекции. 
            Stack<Agent> stack = new Stack<Agent>();

            foreach (Agent value in list)
                stack.Push(value);

            // e) Выведите вторую коллекцию на консоль.
            PrintStack(stack);
            // f) Найдите во второй коллекции заданное значение.
            var findEl = p;
            var isContains = stack.Contains(findEl);
            if (isContains)
                Console.WriteLine("Значение найдено в стеке");
            else
                Console.WriteLine("Значение не найдено в стеке");
        }

        //Создайте объект наблюдаемой коллекции ObservableCollection. Создайте произвольный метод и зарегистрируйте его на событие CollectionChange. Напишите демонстрацию с добавлением и удалением элементов. 
        static void FourthStep()
        {
            var collection = new ObservableCollection<Agent>();

            // регистрируем метод на событие CollectionChanged
            collection.CollectionChanged += CollectionChangedHandler;

            // добавляем элементы в коллекцию
            collection.Add(new Person(x: 0, y: 0, speed: 7, isInfected: true, id: Guid.NewGuid()));
            collection.Add(new Person(x: 1, y: 4, speed: 8, isInfected: false, id: Guid.NewGuid()));
            collection.Add(new Person(x: 2, y: 5, speed: 9, isInfected: true, id: Guid.NewGuid()));

            // удаляем элемент из коллекции
            collection.RemoveAt(1);

            Console.ReadLine();
        }

        // метод, который будет вызываться при изменении коллекции
        private static void CollectionChangedHandler(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"Коллекция была изменена. Тип изменения: {e.Action}");

            if (e.NewItems != null)
            {
                Console.WriteLine("Добавленные элементы:");
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(item);
                }
            }

            if (e.OldItems != null)
            {
                Console.WriteLine("Удаленные элементы:");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void Main(string[] args)
        {
            // 1 часть
            FirstStep();
            // 2 часть
            SecondStep();
            // 3 часть
            ThirdStep();
            // 4 часть
            FourthStep();
        }
    }
}
