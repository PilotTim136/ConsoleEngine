using CEngine;

public class Example : CEngineBehaviour //you can make as many scripts as you like, as long as you have CEngineBehaviour!
{
    GameObject player = null!;
    GameObject obj = null!;
    GameObject random = null!;

    public override void Start()
    {
        //you can log with Logger.Log("");
        //notice: that will log to a log.txt which is saved locally in the app-path this is in!

        //the player
        player = new GameObject(Center, ConsoleColor.White);

        //an object that's affected by physics
        obj = new GameObject(new Vector2(Center.x, 0), ConsoleColor.Cyan);
        obj.AffectByGravity(true);

        //a random object
        random = new GameObject(new Vector2(2, 3), ConsoleColor.Red);
    }

    public override void Update()
    {
        BorderCheck();
        KeyCheck();

        //only close app, if the player is touching the object
        if (player.IsTouching(obj))
        {
            Environment.Exit(0);
        }
    }

    void BorderCheck()
    {
        Logger.Log($"playerPos: {player.position.ToString()} | ScreenHeight: {ScreenSize.y}");
        if (player.position.y < 0) //top
        {
            player.position.y = 0;
        }

        if (player.position.x < 0) //left
        {
            player.position.x = 0;
        }

        if (player.position.y > VisibleScreenSize.y) //bottom
        {
            player.position.y = VisibleScreenSize.y;
        }

        if (player.position.x > VisibleScreenSize.x) //right
        {
            player.position.x = VisibleScreenSize.x;
        }
    }

    void KeyCheck()
    {
        if (Input.IsKeyHeld(ConsoleKey.W))
        {
            player.Move(Vector2.up);
        }

        if (Input.IsKeyHeld(ConsoleKey.A))
        {
            player.Move(Vector2.left);
        }

        if (Input.IsKeyHeld(ConsoleKey.S))
        {
            player.Move(Vector2.down);
        }

        if (Input.IsKeyHeld(ConsoleKey.D))
        {
            player.Move(Vector2.right);
        }
    }
}
