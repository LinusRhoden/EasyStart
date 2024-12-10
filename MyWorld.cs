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
        //private Waves waves;
        private int current_wave = 0;
        private double time = 5;
        private Player my_player = new Player();

        public MyWorld() : base(1920, 1080)
        {
            BackgroundTileName = "pixel_back";

            // Spawn the sprites
            Add(my_player, "rsz_player_img", 960, 540);
        }

        public override void Update(GameTime gameTime)
        {
            // Display the current wave
            ShowText("Wave: " + current_wave, 960, 50);

            base.Update(gameTime);

            // Make the time decrease each update
            time -= gameTime.ElapsedGameTime.TotalSeconds;

            // Spawn new goblins with each wave
            if (time < 0 && current_wave < 10)
            {
                time = 5;
                current_wave += 1;

                for (int i = 0; i < current_wave; i++)
                {
                    Add(new Goblin(my_player), "rsz_goblin_idle", 500, 500);
                }
            }



        }

    }
}
