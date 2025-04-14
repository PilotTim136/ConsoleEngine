using CEngine.engine.data;
using System.Diagnostics;

namespace CEngine.engine.CORE
{
    internal class ScreenRefresh
    {
        private int _targetFPS;
        private int _frameTimeMs;
        private Stopwatch _stopwatch;
        private bool _running = true;
        bool __DODEBUG = false;

        public Thread updateThread = null!;

        public ScreenRefresh(int targetFPS = 60)
        {
            _targetFPS = targetFPS;
            _frameTimeMs = 1000 / _targetFPS;
            _stopwatch = new Stopwatch();

            screenUpdater.UpdateS(true);
        }

        public void Stop()
        {
            _running = false;
            updateThread.Join();
        }

        public void Start()
        {
            foreach (CEngineBehaviour behaviours in _DATA.behaviours)
            {
                behaviours.Start();
            }

            while (_running)
            {
                Input.Update();
                //before frame

                _stopwatch.Restart();
                screenUpdater.UpdateS(__DODEBUG);
                //after frame

                foreach (CEngineBehaviour behaviours in _DATA.behaviours)
                {
                    behaviours.Update();
                }

                Input.Clear();

                Gravity.UpdateGravity();

                foreach (CEngineBehaviour behaviours in _DATA.behaviours)
                {
                    behaviours.LateUpdate();
                }


                Time.deltaTime = _stopwatch.ElapsedMilliseconds / 1000f;

                float fps = (Time.deltaTime > 0) ? (1f / Time.deltaTime) : _targetFPS;
                string fpsStr = $"FPS: {fps:F0} | TARGET: {_targetFPS} | DeltaTime: {Time.deltaTime:F4}";

                if(screenUpdater.log.Count > 0)
                {
                    screenUpdater.log[0] = fpsStr;
                }
                else
                {
                    screenUpdater.log.Add(fpsStr);
                }

                int elapsed = (int)_stopwatch.ElapsedMilliseconds;
                int waitTime = _frameTimeMs - elapsed;
                if (waitTime > 0)
                    Thread.Sleep(waitTime);
            }
        }

        public void StartThread()
        {
            updateThread = new Thread(Start);
            updateThread.IsBackground = true;
            updateThread.Start();
        }
    }
}
