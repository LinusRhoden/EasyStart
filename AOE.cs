using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
namespace EasyStart
{
    internal class AOE : Actor
    {
        private float time;
        private Player player;

        public  AOE(Player player)
        {
            this.player = player;
        }

        public override void Act()
        {
            time = time + 1;
            X=player.X;
            Y=player.Y;

            if (time > 10)
            {
                World.RemoveActor(this);
            }


        }

    }
}
