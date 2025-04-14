using CEngine.engine.data;

namespace CEngine
{
    public abstract class CEngineBehaviour
    {
        /// <summary>
        /// Start function: called once the game starts
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        /// Update function: called every frame
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// LateUpdate function: called after the gravity & render update
        /// </summary>
        public virtual void LateUpdate() { }

        /// <summary>
        /// the (accurate) screen size
        /// </summary>
        public Vector2 ScreenSize => _DATA.AccurateScreenSize;
        public Vector2 VisibleScreenSize => new Vector2(ScreenSize.x - 1, ScreenSize.y - 1);

        /// <summary>
        /// the screen center
        /// </summary>
        public Vector2 Center => new Vector2(ScreenSize.x / 2, ScreenSize.y / 2);
    }
}
