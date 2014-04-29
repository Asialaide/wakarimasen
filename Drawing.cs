using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace wakarimasen
{

    class Drawing
    {

        private const int RESOLUTION_X = 800;
        private const int RESOLUTION_Y = 600;
        private const int FRAME_LIMIT = 60;
        private const bool VSYNC = true;
        private static Color BACKGROUND_COLOUR = new Color(135, 206, 250); // Sky blue.
        private static Color MASK_COLOUR = new Color(255, 174, 201); // Pink. 
        private static RenderStates renderAlpha = new RenderStates(BlendMode.Alpha); // Allows use of masks.

        // Create the main window.
        private static RenderWindow gameWindow;
        public static RenderWindow window
        {
            get { return gameWindow; }
            set { gameWindow = value; }
        }

        public static void initialise()
        {
            window = new RenderWindow(new VideoMode(RESOLUTION_X, RESOLUTION_Y), "Asialaide");

            // Video settings.
            window.SetFramerateLimit(FRAME_LIMIT);
            window.SetVerticalSyncEnabled(VSYNC);
        }

        public static void drawWindow()
        {
            // Clear the window with a fill (apply background layer).
            window.Clear(BACKGROUND_COLOUR);

            //Image testGraphic = new Image("data\\graphics\\crf_char.png");
            //testGraphic.CreateMaskFromColor(MASK_COLOUR, 0);

            // Drawing!
            //window.Draw(new Sprite(Files., new IntRect(0, 0, 32, 32)), renderAlpha);
            drawSprite(1, 4, (int)Character.getCharacter(0).position[0], (int)Character.getCharacter(0).position[1]);
            

            // Update the window.
            window.Display();
        }

        // Integers x and y are coordinates in the window, not a position in the game world.
        public static void drawSprite(int spriteID, float scale, int x, int y)
        {
            Texture loaded = Files.getSprite(spriteID);
            Sprite sprite = new Sprite(loaded, new IntRect(0, 0, 32, 32));
            sprite.Scale = new Vector2f(scale, scale);
            sprite.Position = new Vector2f(x, y);

            window.Draw(sprite, renderAlpha);
        }
        // An overload that doesn't require a scale to be specified. 
        public static void drawSprite(int spriteID, int x, int y)
        {
            drawSprite(spriteID, 1, x, y);
        }

        public static Texture removeMask(Image image)
        {
            image.CreateMaskFromColor(MASK_COLOUR, 0);
            return new Texture(image, new IntRect(0, 0, (int)(image.Size.X), (int)(image.Size.Y)));
        }

    }
}
