using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EasyStart
{
    internal class Goblin : Actor
    {
        private float Speed = 500;
        private Player player;
        private float standStillTimer = 0f;
        private bool isStandingStill = true;
        private float standStillDuration = 1f;

        public Goblin(Player player)
        {
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (isStandingStill)
            {
                standStillTimer += deltaTime;

                if (standStillTimer >= standStillDuration)
                {
                    isStandingStill = false;
                }
            }
            else
            {
                TurnTowards(player.X, player.Y);
                Move(deltaTime * 200);
            }
        }
    }
}
