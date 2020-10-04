using System;

namespace Academits.Dorosh.Csv
{
    class CsvProgram
    {
        static void Main(string[] args)
        {

            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Необходимо указать путь к исходному файлу.");
                }
                else if (args.Length == 1)
                {
                    CsvConverter.ConvertFromCsv(args[0]);

                    Console.WriteLine("Конвертирование выполнено.");
                }
                else
                {
                    CsvConverter.ConvertFromCsv(args[0], args[1]);

                    Console.WriteLine("Конвертирование выполнено.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("ОШИБКА: {0}", e.Message);
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}