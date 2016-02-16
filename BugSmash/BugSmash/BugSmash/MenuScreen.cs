using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BugSmash
{
    class MenuScreen
    {
        //detects if the play button on menu screen is pressed
        public bool clicked = false;
        MouseState oldState, hoverState;

        public void checkButton()
        {
            MouseState newState = Mouse.GetState();

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                //checks if click is within boundaries of the button
                if ((newState.X >= ((Vars.screenWidth * 78) / 100) && newState.X <= (Vars.screenWidth) && (newState.Y >= ((Vars.screenHeight * 78) / 100) && newState.Y <= Vars.screenHeight)))
                {
                    this.clicked = true;
                }
                else if ((newState.X >= ((Vars.screenWidth * 0) / 100) && newState.X <= (Vars.screenWidth * 22) / 100 && newState.Y >= ((Vars.screenHeight * 78) / 100) && newState.Y <= (Vars.screenHeight)))
                {
                    AdjustSettings changeGame = new AdjustSettings();
                    changeGame.ShowDialog();
                    //Thread myThread = new Thread(new ThreadStart(this.createMyExternalTool));
                    //myThread.Start();
                }
            }
            oldState = newState;
        }

        public void createMyExternalTool()
        {
            AdjustSettings changeGame = new AdjustSettings();
            while(changeGame.Enabled == true)
            {
                changeGame.ShowDialog();
                //changeGame.Focus();
                //changeGame.Update();

                //changeGame.Invoke(changeGame.Update);
            }
        }

        public int buttonHover()
        {
            hoverState = Mouse.GetState();
            if (hoverState.X > (Vars.screenWidth * 78) / 100 && hoverState.Y > (Vars.screenHeight * 78) / 100)
            {
                return 1;
            }
            else if (hoverState.X < (Vars.screenWidth * 22) / 100 && hoverState.Y > (Vars.screenHeight * 78) / 100)
            {
                return 2;
            }
            else { return 0; }
        }


    }
}
