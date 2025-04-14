# ConsoleEngine (CEngine)

A project I made, because I always wanted to make a Game-Engine.

It is pretty bad and laggy (and has messy code), but it's my first project where I don't do the most random things possible.

Note: Contains a small demonstration in `Example.cs`

## Installation

Download the Source code from Github

## Usage

First of all, you need to init the Engine.

You do that by adding "new CEngineInit();" in Your Program-entry point.

```cs
using CEngine;

public class Example : CEngineBehaviourlong as you have CEngineBehaviour!
{
    GameObject player = null!;

    public override void Start()
    {
        player = new GameObject(Center, ConsoleColor.White);
    }

    public override void Update()
    {
        KeyCheck();
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
```

# features

It contains a simple Input system, while also having support for custom FPS, and screen size.

NOTE: The bigger the screen, the more lag it has, because its only driven by the Console.
