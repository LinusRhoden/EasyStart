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
        public Goblin(Player player)
        {
            this.player = player;
        }
        public override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TurnTowards(player.X, player.Y);
            Move(deltaTime * 200);
        }
    }
}
