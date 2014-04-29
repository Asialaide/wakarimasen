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

        // Used as a local reference. 
        private static RenderWindow window;
        
        static void Main(string[] args)
        {

            Files.log("Game started.");

            Console.Title = "Asialaide";

            new Character("Player", 1, 200, 300);
           
            Drawing.initialise();
            window = Drawing.window; // A local reference. 

            // Create events.
            window.Closed += new EventHandler(Program.OnClose);
            window.KeyPressed += new EventHandler<KeyEventArgs>(Input.OnKeyPressed);

            // Load files. 
            Files.load("data\\graphics\\crf_char.png");

            // The game loop.
            while (window.IsOpen())
            {
                // Process events.
                window.DispatchEvents();

                // Draw everything. 
                Drawing.drawWindow();
            }
           
        }

        public static void OnClose(object sender, EventArgs e)
        {
            // Close the window (end the program) when the OnClose event is received.
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

    }
}
