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
        private float attackCooldown = 0.5f; // Cooldown in seconds
        private float attackTimer = 0;      // Timer for cooldown

        public override void Update(GameTime gameTime)
        {
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
            if (attackTimer > 0)
            {
                attackTimer -= deltaTime;
            }

            // Check for attack input
            if (keyboardState.IsKeyDown(Keys.Space) && attackTimer <= 0)
            {
                Attack();
                attackTimer = attackCooldown; // Reset cooldown
            }

            // Check for collision with goblins
            if (IsTouching(typeof(Goblin)))
            {
                World.ShowText("Game Over", 960, 540);
                IsDead = true;
            }
        }

        private void Attack()
        {
            
        }
    }
}
