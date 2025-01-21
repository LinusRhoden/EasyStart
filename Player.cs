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
    internal class Player : Actor
    {
        private float Speed = 500;
        private bool IsDead = false;
        private float attack_cooldown = 1;
        private int attack_range = 300;
        private double last_attack = 0;

        public override void Update(GameTime gameTime)
        {
            World.ShowText("Attack Cooldown: " + last_attack, 1500, 50);
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var keyboardState = Keyboard.GetState();

            // Movement logic
            if (keyboardState.IsKeyDown(Keys.A))
            {
                X -= deltaTime * Speed;
                IsFlippedHorizontally = true;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                X += deltaTime * Speed;
                IsFlippedHorizontally = false;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                Y -= deltaTime * Speed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                Y += deltaTime * Speed;
            }

            // Reduce attack timer
            if (last_attack > 0)
            {
                last_attack -= deltaTime;
            }

            // Check for attack 
            if (keyboardState.IsKeyDown(Keys.Space) && last_attack <= 0)
            {
                Attack();
                last_attack = attack_cooldown; 
            }

            // Check for collision with enemies
            if (IsTouching(typeof(Goblin)) || IsTouching(typeof(Alucard)))
            {
                World.ShowText("Game Over", 960, 540);
                IsDead = true;
            }

        }

        private void Attack()
        {
            List<Actor> goblins = World.GetActors(typeof(Goblin));
            
            if (goblins != null)
            {
                foreach (var goblin in goblins)
                {
                    float distance = Vector2.Distance(Position, goblin.Position);


                    if (distance <= attack_range)
                    {
                        World.RemoveActor(goblin);
                    }
                }
            }

            List<Actor> alucards = World.GetActors(typeof(Alucard));
            //((Alucard)alucards[0]).Hp = 2;
            if (alucards != null)
            {
                Alucard alucard = (Alucard)alucards[0];

    
                float distance = Vector2.Distance(Position, alucard.Position);
                
                if (distance <= attack_range)
                {
                    alucard.Hp -= 1;
                    
                    if (alucard.Hp <= 0)
                    {
                        World.RemoveActor(alucard);
                    }
                }

            }
        }
    }
}
