//
// License: GPLv2
// Authors: C.Fallins and V.Ivanovic
//
// Visual Studio Express 2013
// .NET Framework 4.0
// SFML.net 2.1 x86
//
// Note: Start without debugging.
//

using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace wakarimasen
{
    class Program
    {
        
        static void Main(string[] args)
        {

            // Create the main window
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Asialaide");
            window.Closed += new EventHandler(OnClose);
            window.SetFramerateLimit(60);
            window.SetVerticalSyncEnabled(true);

            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);

            Color windowColor = new Color(135, 206, 250);
            RenderStates renderAlpha = new RenderStates(BlendMode.Alpha);

            Image testGraphic = new Image("data\\sprites\\testing.png");

            testGraphic.CreateMaskFromColor(new Color(255, 255, 255), 0);

            Sprite testSprite = new Sprite(new Texture(testGraphic), new IntRect(0, 0, 16, 16));
            testSprite.Position = new Vector2f(10, 10);
            testSprite.Scale = new Vector2f(6, 6);
            //littleDude.Color = new Color(255, 255, 255, 200);

            Console.WriteLine("Sprite's position: " + testSprite.Position.X + ", " + testSprite.Position.Y);
            Console.WriteLine("Sprite's scale: " + testSprite.Scale.X + ", " + testSprite.Scale.Y);

            // Start the game loop
            while (window.IsOpen())
            {
                // Process events.
                window.DispatchEvents();

                // Clear the window.
                window.Clear(windowColor);

                // Drawing!
                window.Draw(testSprite, renderAlpha);

                // Update the window.
                window.Display();
            }
        }    

        static void OnKeyPressed(object sender, EventArgs e)
        {

        }

        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when the OnClose event is received.
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

    }
}
