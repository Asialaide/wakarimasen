using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using SFML;
using SFML.Window;

namespace wakarimasen
{
    class Input
    {

        public static void OnKeyPressed(object sender, KeyEventArgs e)
        {

            Console.WriteLine("Key pressed: " + e.Code);

            switch (e.Code)
            {
                // Movement.
                case SFML.Window.Keyboard.Key.A:
                case SFML.Window.Keyboard.Key.Left:
                    {
                        // Move character left.
                        Character.getCharacter(0).position[0] -= 25;

                        break;
                    }
                case SFML.Window.Keyboard.Key.D:
                case SFML.Window.Keyboard.Key.Right:
                    {
                        // Move character right.
                        Character.getCharacter(0).position[0] += 25;

                        break;
                    }
                case SFML.Window.Keyboard.Key.W:
                case SFML.Window.Keyboard.Key.Up:
                    {
                        // Move character up / jump.

                        break;
                    }
                case SFML.Window.Keyboard.Key.S:
                case SFML.Window.Keyboard.Key.Down:
                    {
                        // Move character down / crouch.

                        break;
                    }

                // Game function.
                case SFML.Window.Keyboard.Key.Escape:
                    {
                        Drawing.window.Close();
                        Console.Title = "Asialaide (ended)";

                        break;
                    }

                default:
                    
                    break;
            }
        }

    }
}
