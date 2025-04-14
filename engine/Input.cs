using System.Collections.Concurrent;

namespace CEngine
{
    public static class Input
    {
        private static HashSet<ConsoleKey> _keysDown = new();
        private static HashSet<ConsoleKey> _keysHeld = new();
        private static HashSet<ConsoleKey> _keysUp = new();

        private static Thread _inputThread = null!;
        private static readonly ConcurrentQueue<ConsoleKey> _keyBuffer = new();

        public static void Initialize()
        {
            Logger.Log("Input started");
            _inputThread = new Thread(InputLoop)
            {
                IsBackground = true
            };
            _inputThread.Start();
        }

        private static void InputLoop()
        {
            while (true)
            {
                var key = Console.ReadKey(intercept: true).Key;
                _keyBuffer.Enqueue(key);
            }
        }

        public static void Update()
        {
            _keysDown.Clear();
            _keysUp.Clear();

            HashSet<ConsoleKey> processedKeysThisFrame = new();

            while (_keyBuffer.TryDequeue(out var key))
            {
                if (!_keysHeld.Contains(key))
                {
                    _keysDown.Add(key);
                }
                _keysHeld.Add(key);
                processedKeysThisFrame.Add(key);
            }

            List<ConsoleKey> toRemove = new();
            foreach (var key in _keysHeld)
            {
                if (!processedKeysThisFrame.Contains(key))
                {
                    _keysUp.Add(key);
                    toRemove.Add(key);
                }
            }

            foreach (var key in toRemove)
            {
                _keysHeld.Remove(key);
            }
        }

        public static void Clear()
        {
            _keysDown.Clear();
            _keysUp.Clear();
        }

        public static bool IsKeyDown(ConsoleKey key) => _keysDown.Contains(key);
        public static bool IsKeyHeld(ConsoleKey key) => _keysHeld.Contains(key);
        public static bool IsKeyUp(ConsoleKey key) => _keysUp.Contains(key);
    }
}