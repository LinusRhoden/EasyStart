using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
using Microsoft.Xna.Framework;

namespace EasyStart
{
    internal class MyWorld : World
    {

        private int current_wave = 0;
        private double time = 5;
        private Player my_player = new Player();

        public MyWorld() : base(1920, 1080)
        {
            BackgroundTileName = "pixel_back";

            Add(my_player, "rsz_player_img", 960, 540);
            
        }

        public override void Update(GameTime gameTime)
        {
           

            base.Update(gameTime);

            time -= gameTime.ElapsedGameTime.TotalSeconds;

            if (time < 0 && current_wave < 10)
            {
                time = 5; 
                current_wave++;

                ShowText("Wave: " + current_wave, 960, 50);

                Random random = new Random(); // Random generator

               
                for (int i = 0; i < current_wave; i++)
                {
                    int randomX = random.Next(100, 1820); 
                    int randomY = random.Next(100, 980);  
                    Add(new Goblin(my_player), "rsz_goblin_idle", randomX, randomY);
                }
            }

            if (time > 0 && current_wave == 10)
            {
                current_wave++;

                ShowText("BOSS WAVE!", 960, 50);
                
                Add(new Alucard(my_player), "alucard-removebg-preview", 100, 100);
                
            }


        }


    }
}
