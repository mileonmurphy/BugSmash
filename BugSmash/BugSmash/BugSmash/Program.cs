#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
#endregion

namespace BugSmash
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (Game1 myGame = new Game1())
            {
                myGame.Run();
            }  
        }
    }
}
