using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace EasyStart
{
    public class Waves
    {
        public int _currentWave;     // Tracks the current wave
        private double _elapsedTime; // Tracks elapsed time since the last wave increase
        private const double WaveDuration = 30; // Duration in seconds for each wave

        public Waves()
        {
            _currentWave = 1; // Start from wave 1
            _elapsedTime = 0; // Initialize elapsed time
        }

        // Property to get the current wave
        public int CurrentWave => _currentWave;

        // Updates the wave based on elapsed time
        public void Update(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            // Check if 30 seconds have passed
            if (_elapsedTime >= WaveDuration)
            {
                _currentWave++;
                _elapsedTime -= WaveDuration; // Reset the elapsed time for the next wave
            }
        }


        // Resets the wave counter and timer (if needed)
        public void Reset()
        {
            _currentWave = 1;
            _elapsedTime = 0;
        }
    }
}
