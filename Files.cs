using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using SFML.Graphics;

namespace wakarimasen
{
    class Files
    {

        //Dictionary<int, string> sprites = new Dictionary<int,string>()
        private static SortedDictionary<int, Texture> sprites = new SortedDictionary<int, Texture>();

        // Returns a boolean representing success or failure.
        public static bool load(string filename)
        {

            // Check for a valid filename? Either by using a try-catch statement or testing conditions, e.g. one and only one period. 
            
            // For now, the lazy try-catch.
            try
            {
                // Operate on file according to its extension.

                switch (filename.Substring(filename.Length - 4, 4))
                { 
                    case ".png":
                    case ".jpg":
                    case "jpeg":
                    case ".bmp":
                        {
                            // It's an image file.    
                            
                            // FIX: Can't add the key by total count of items. If some are lost or removed, shit will get retarded. 
                            // Graphics are held as textures so they're stored in speedy graphics memory. 
                            // Common scale figures could be generated at the same time to minimise effort later. 
                            sprites.Add(1, Drawing.removeMask(new Image(filename)));

                            //System.IO.
                            
                            log("File loaded (" + filename + ").");
                            return true;
                        }
                    default:
                        {
                            Console.WriteLine("Error: file format unsupported ({0}).", filename);

                            return false;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: file ({0}) failed to load. Check the log for details.", filename);
                log(e.ToString());

                return false;
            }
            finally
            {

            }
            
        }

        public static Texture getSprite(int ID)
        {
            return sprites[ID];
        }

        // Writes a line of text to the log file.
        public static void log(string line)
        {
            // Prefix with the date and exact time.

            // Store a copy in memory in case logging is disabled and a crash log needs, and is able, to be dumped. 
            // Delete last log, possibly buffering a few as well.

            // A copy for the debug feed.
            Debug.Print("[LOG] {0}", line);
        }

    }
}
