using System;

namespace Patterns23.Proxy
{
    public class ImageProxy : IGraphic
    {
        private readonly string _filename;
        private HighResolutionImage _realImage;
        private bool _isLoaded = false;

        public ImageProxy(string filename)
        {
            _filename = filename;
            Console.WriteLine($" Создан прокси для изображения: {_filename}");
            Console.WriteLine(" Реальное изображение еще НЕ загружено в память\n");
        }

        public void Draw()
        {
           
            if (_realImage == null)
            {
                Console.WriteLine(" Прокси: Первый вызов Draw() - загружаем реальное изображение...");
                _realImage = new HighResolutionImage(_filename);
                _isLoaded = true;
            }
            else
            {
                Console.WriteLine(" Прокси: Используем уже загруженное изображение");
            }

          
            _realImage.Draw();
        }

        public string GetName()
        {
            return _filename + " (proxy)";
        }

       
        public bool IsImageLoaded()
        {
            return _isLoaded;
        }

        public void Preload()
        {
            if (!_isLoaded)
            {
                Console.WriteLine(" Прокси: Принудительная предзагрузка изображения...");
                _realImage = new HighResolutionImage(_filename);
                _isLoaded = true;
            }
        }
    }
}