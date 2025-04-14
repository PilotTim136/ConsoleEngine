using CEngine.engine.data;

namespace CEngine.engine.CORE
{
    internal class Gravity
    {
        static float time = 0;
        
        public static void UpdateGravity()
        {
            time += Time.deltaTime;
            foreach (GameObject obj in _DATA.objects)
            {
                if (obj.affectedByGravity)
                {
                    if(time > (0.4f - obj.yVelocity))
                    {
                        obj.Move(Vector2.down);
                        obj.AddVelocity(0.01f);
                        time = 0;
                    }
                }
            }
        }
    }
}
