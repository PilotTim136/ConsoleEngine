using CEngine.engine.data;

public class ColoredCharacter
{
    public char Character { get; set; }
    public ConsoleColor Color { get; set; }

    public ColoredCharacter(char character, ConsoleColor color)
    {
        Character = character;
        Color = color;
    }
}

namespace CEngine.engine.CORE
{
    internal class screenUpdater
    {
        private static readonly object _consoleLock = new object();
        private static readonly object _dataLock = new object();

        public static List<string> log = new List<string>();

        public static void UpdateS(bool initialization = false)
        {
            lock (_consoleLock)
            {
                ColoredCharacter[,] buffer = new ColoredCharacter[_DATA.wiHeight, _DATA.wiWidth];

                lock (_dataLock)
                {
                    for (int y = 0; y < _DATA.wiHeight; y++)
                    {
                        for (int x = 0; x < _DATA.wiWidth; x++)
                        {
                            ConsoleColor charColor = ConsoleColor.Black;

                            foreach (GameObject obj in _DATA.objects)
                            {
                                if (obj.position.x == x && obj.position.y == y)
                                {
                                    charColor = obj.color;
                                    break;
                                }
                            }

                            buffer[y, x] = new ColoredCharacter('#', charColor);
                            if (x + 1 < _DATA.wiWidth)
                            {
                                buffer[y, x + 1] = new ColoredCharacter('#', charColor);
                            }
                        }
                    }
                }

                Console.SetCursorPosition(0, 0);
                for (int y = 0; y < _DATA.wiHeight; y++)
                {
                    for (int x = 0; x < _DATA.wiWidth; x++)
                    {
                        Console.ForegroundColor = buffer[y, x].Color;
                        Console.BackgroundColor = buffer[y, x].Color;
                        Console.Write(buffer[y, x].Character);
                    }
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}

/*using CEngine.engine.data;
using System.Text;

namespace CEngine.engine.CORE
{
    internal class screenUpdater
    {
        private static readonly object _consoleLock = new object();
        public static List<string> log = new List<string>();

        public static void UpdateS(bool initialization = false)
        {
            lock (_consoleLock)
            {
                //currentX and currentY
                int cX = 0, cY = 0;

                StringBuilder str = new StringBuilder();

                SetColor(ConsoleColor.Black);
                cY = 0;
                for (int i = 0; i < _DATA.wiHeight; i++)
                {
                    cX = 0;
                    for (int j = 0; j < _DATA.wiWidth; j++)
                    {
                        foreach(GameObject obj in _DATA.objects)
                        {
                            if (obj.position.x == cX && obj.position.y == cY)
                            {
                                SetColor(obj.color);
                            }
                            break;
                        }
                        str.Append("#");
                        SetColor(ConsoleColor.Black);
                        cX++;
                    }
                    cY++;
                    str.AppendLine();
                }

                string stri = str.ToString();
                stri = stri.Replace("\r", "").Replace("\n", "");
                int len = stri.Length;

                Console.SetCursorPosition(0, 0);

                if (len != _DATA.wiHeight * _DATA.wiWidth)
                {
                    log.Add("Not the same size as intended!");
                    Thread.Sleep(1000);
                }

                SetDefault();
                //Console.Clear();
                Console.Write(str);

                Console.Write("\n\n");
                SetDefault();
                foreach (string error in log)
                {
                    Console.WriteLine(error);
                }
                Console.SetCursorPosition(0, 0);
            }
        }

        public static void SetColor(ConsoleColor col)
        {
            Console.ForegroundColor = col;
            Console.BackgroundColor = col;
        }

        public static void SetDefault()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}*/
