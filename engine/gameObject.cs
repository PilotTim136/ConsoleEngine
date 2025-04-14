using CEngine.engine.data;

namespace CEngine
{
    internal class GameObject
    {
        public Vector2 position;
        public ConsoleColor color { get; private set; }
        public bool affectedByGravity { get; private set; } = false;

        public float yVelocity { get; private set; } = 0;

        int indexInData;

        #region constructor
        public GameObject()
        {
            position = new Vector2(0, 0);
            color = ConsoleColor.White;
            _DATA.objects.Add(this);
            this.indexInData = _DATA.objects.IndexOf(this);
        }
        public GameObject(Vector2 position)
        {
            this.position = position;
            color = ConsoleColor.White;
            _DATA.objects.Add(this);
            this.indexInData = _DATA.objects.IndexOf(this);
        }
        public GameObject(ConsoleColor color)
        {
            position = new Vector2(0, 0);
            this.color = color;
            _DATA.objects.Add(this);
            this.indexInData = _DATA.objects.IndexOf(this);
        }
        public GameObject(Vector2 position, ConsoleColor color)
        {
            this.position = position;
            this.color = color;
            _DATA.objects.Add(this);
            this.indexInData = _DATA.objects.IndexOf(this);
        }
        #endregion

        /// <summary>
        /// The position it will move towards
        /// </summary>
        /// <param name="pos">position where it should go</param>
        public GameObject SetPosition(Vector2 pos)
        {
            position = pos;
            return this;
        }


        /// <summary>
        /// Moves into the direction given (Vector2.up/down/left/right)
        /// </summary>
        /// <param name="delta"></param>
        public GameObject Move(Vector2 delta)
        {
            position += delta;
            return this;
        }

        /// <summary>
        /// Set the color of the object
        /// </summary>
        /// <param name="color">The color it should be set to</param>
        public GameObject Color(ConsoleColor color)
        {
            this.color = color;
            return this;
        }

        /// <summary>
        /// If the object should be affected by gravity or not
        /// </summary>
        public GameObject AffectByGravity(bool affect)
        {
            affectedByGravity = affect;
            return this;
        }

        /// <summary>
        /// What the velocity will be set to
        /// </summary>
        /// <param name="yVelocity">Velocity</param>
        public GameObject SetVelocity(float yVelocity)
        {
            this.yVelocity = yVelocity;
            return this;
        }

        /// <summary>
        /// What the velocity will be changed by
        /// </summary>
        /// <param name="addYVelocity">Velocity</param>
        public GameObject AddVelocity(float addYVelocity)
        {
            this.yVelocity += addYVelocity;
            return this;
        }

        /// <summary>
        /// What it will do if something is touching it
        /// </summary>
        public bool IsTouching()
        {
            foreach (GameObject obj in _DATA.objects)
            {
                if (obj != this)
                {
                    if (obj.position == this.position)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// What it will do if something specific is touching it
        /// </summary>
        /// <param name="gameObject">The GameObject it needs to touch</param>
        public bool IsTouching(GameObject gameObject)
        {
            foreach (GameObject obj in _DATA.objects)
            {
                if (obj == gameObject)
                {
                    if (obj.position == this.position)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// NOTICE: This destroys the object from all the game-elements and will not be in the game anymore.
        /// BUT it will not remove the object from memory while a reference still exists.
        /// </summary>
        public void Destroy()
        {
            try
            {
                _DATA.objects.Remove(this);
            }
            catch (Exception e)
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine($"Error destroying object: {e}");
                Environment.Exit(0);
            }
        }
    }
}
