using System;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EduvetKonovalov.ClassFolder
{
    internal class ClassImage
    {
        public static BitmapImage ConvertByteArrayToImage(byte[] array)
        {

            /// <summary>
            /// Метод для конвертации из БД в Image на окне
            /// </summary>
            /// <param name="array"></param>
            /// <returns>Изображение</returns>
            //если байт массив не пустой
            if (array != null)
            {
                //записываем полученные данные в массив для дальнейшей работы
                using (var ms = new MemoryStream(array, 0, array.Length))
                {
                    //инициализируется новый экземпляр класса BitmapImage,
                    //который необходим для поддержки синтаксиса XAML
                    //и предоставляет дополнительные свойства для загрузки
                    //битовой карты
                    var image = new BitmapImage();
                    //инициализируем объект BitmapImage
                    image.BeginInit();
                    //обработка кэша из хранилища
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    //получаем исходный поток
                    image.StreamSource = ms;
                    //завершаем инициализацию
                    image.EndInit();
                    return image;
                }
            }
            return null;
        }

        public static byte[] ConvertImageToArray(string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);
            ImageFormat bmpFormat = bitmap.RawFormat;
            var imageConvert = Image.FromFile(fileName);

            using (var ms = new MemoryStream())
            {
                imageConvert.Save(ms, bmpFormat);
                return ms.ToArray();
            }
        }
    }
}
