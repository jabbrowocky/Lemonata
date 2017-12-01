using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    
    
    class musicplayer


    {
        static public void MenuMusic()
        {
             
            System.Media.SoundPlayer titleLoop = new System.Media.SoundPlayer();
            titleLoop.SoundLocation = /*C:\Users\DalekMyBalls\Desktop\DevCodeCamp\c#\LemonadeRightHurr\lemonata\LemonadeFoSale\LemonadeFoSale*/"POL-magical-sun-short.wav";
            titleLoop.PlayLooping();
               
        }
        static public void StopMenuMusic(System.Media.SoundPlayer titleLoop)
        {
            titleLoop.Stop();
        }
    }
}
