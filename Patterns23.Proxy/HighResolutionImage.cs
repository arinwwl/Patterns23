using System;
using System.Threading;

namespace Patterns23.Proxy
{
    public class HighResolutionImage : IGraphic
    {
        private readonly string _filename;

        public HighResolutionImage(string filename)
        {
            _filename = filename;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine($" Загрузка ВЫСОКОКАЧЕСТВЕННОГО изображения: {_filename}");
            Console.WriteLine(" Эта операция требует много времени и ресурсов...");

            
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($" Загрузка... {(i + 1) * 33}%");
            }

            Console.WriteLine($" Изображение {_filename} успешно загружено!\n");
        }

        public void Draw()
        {
            Console.WriteLine($" Отрисовка высококачественного изображения: {_filename}");
        }

        public string GetName()
        {
            return _filename;
        }
    }
}