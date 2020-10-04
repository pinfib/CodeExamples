using System.IO;

namespace Academits.Dorosh.Csv
{
    class CsvConverter
    {
        public static void ConvertFromCsv(string input, string output = "output.html")
        {
            using (StreamReader reader = new StreamReader(input))
            {
                using (StreamWriter writer = new StreamWriter(output))
                {
                    writer.WriteLine("<!DOCTYPE HTML>");
                    writer.WriteLine("<html>");
                    writer.WriteLine("<head>");
                    writer.WriteLine("<title>Таблица</title>");
                    writer.WriteLine("<meta charset=\"utf-8\">");
                    writer.WriteLine("</head>");
                    writer.WriteLine("<body>");
                    writer.WriteLine("<table border=\"1\">");

                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        if (currentLine.Equals(""))
                        {
                            continue;
                        }

                        writer.Write("<tr><td>");

                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            if (currentLine[i] == ',')
                            {
                                writer.Write("</td><td>");

                                continue;
                            }

                            if (currentLine[i] == '<')
                            {
                                writer.Write("&lt;");

                                continue;
                            }

                            if (currentLine[i] == '>')
                            {
                                writer.Write("&gt;");

                                continue;
                            }

                            if (currentLine[i] == '&')
                            {
                                writer.Write("&amp;");

                                continue;
                            }

                            if (currentLine[i] == '"')
                            {
                                i++;

                                while (true)
                                {
                                    if (i >= currentLine.Length)
                                    {
                                        writer.Write("<br/>");

                                        currentLine = reader.ReadLine();

                                        i = 0;

                                        continue;
                                    }

                                    if (currentLine[i] == '"' && i + 1 < currentLine.Length && currentLine[i + 1] == '"')
                                    {
                                        i += 2;

                                        writer.Write("\"");

                                        continue;
                                    }

                                    if (currentLine[i] == '"')
                                    {
                                        break;
                                    }

                                    writer.Write(currentLine[i]);

                                    i++;
                                }

                                continue;
                            }

                            writer.Write(currentLine[i]);
                        }

                        writer.WriteLine("</td></tr>");
                    }

                    writer.WriteLine("</table>");
                    writer.WriteLine("</body>");
                    writer.Write("</html>");
                }
            }
        }
    }
}