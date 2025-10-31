using System;
using Patterns23.Proxy;

namespace Patterns23
{
    public class ProxyDemo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" ===== ДЕМОНСТРАЦИЯ ПАТТЕРНА ЗАМЕСТИТЕЛЬ =====\n");

           
            Console.WriteLine("Этап 1: Создание прокси объектов");
            var image1 = new ImageProxy("vacation_photo.jpg");
            var image2 = new ImageProxy("company_logo.png");
            var image3 = new ImageProxy("chart_diagram.svg");

            Console.WriteLine("\nЭтап 2: Проверка состояния до отрисовки");
            PrintImageStatus(image1, image2, image3);

            Console.WriteLine("\n Этап 3: Первая отрисовка изображения 1");
            image1.Draw();

            Console.WriteLine("\n Этап 4: Проверка состояния после первой отрисовки");
            PrintImageStatus(image1, image2, image3);

            Console.WriteLine("\n Этап 5: Вторая отрисовка изображения 1");
            image1.Draw();

            Console.WriteLine("\n Этап 6: Отрисовка изображения 2");
            image2.Draw();

            Console.WriteLine("\n Этап 7: Принудительная предзагрузка изображения 3");
            image3.Preload();

            Console.WriteLine("\n Этап 8: Финальное состояние всех изображений");
            PrintImageStatus(image1, image2, image3);

            Console.WriteLine("\n Демонстрация завершена!");
        }

        private static void PrintImageStatus(params ImageProxy[] images)
        {
            for (int i = 0; i < images.Length; i++)
            {
                Console.WriteLine($"Изображение {i + 1} ({images[i].GetName()}): " +
                                $"{(images[i].IsImageLoaded() ? "ЗАГРУЖЕНО " : "НЕ загружено ")}");
            }
        }
    }
}