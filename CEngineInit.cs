///////////////////////////////////////////////////
///                                             ///
///         DO NOT EDIT THINGS IN HERE!         ///
///      Unless you know what you're doing      ///
///                                             ///
///                    GO TO                    ///
///               data.cs INSTEAD               ///
///            (engine/CORE/data.cs)            ///
///                                             ///
///////////////////////////////////////////////////


using CEngine.engine.CORE;
using CEngine.engine.data;
using System.Reflection;

namespace CEngine
{
    public class CEngineInit()
    {

        //please do NOT edit this!
        //if you do, you are responsible for stability issues and possible crashes
        //if you did NOT edit any code outside of yours, please try to contact me.
        //or go on | github -> ConsoleEngine -> issues | and create one there

        static CEngineInit()
        {
            new Logger(); //initialize logger
                          //notice: the logger logs in the same directory your game is built

            Console.CursorVisible = false; //make the console-cursor invisible
            new Screen(_DATA.ScreenSize); //initialize screen

            //get all classes that have the CEngineBehaviour as base class
            var engineBehaviourTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(CEngineBehaviour)) && !t.IsAbstract)
                .ToList();

            foreach (var type in engineBehaviourTypes)
            {
                CEngineBehaviour behaviour = (CEngineBehaviour)Activator.CreateInstance(type)!;
                _DATA.behaviours.Add(behaviour);
            }
            //afterwards, start the refresh thread

            Input.Initialize();

            ScreenRefresh screenRefresh = new ScreenRefresh(_DATA.TargetFPS); //create screen refresh stuff
            screenRefresh.StartThread(); //start the thread for the updating

            KeepActive();
        }

        static void KeepActive()
        {
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
