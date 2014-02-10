using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
namespace SORAKAKE.Ver1
{
    class Wing
    {
        public float Wingx,Wingy, Wingz;
        public Wing(float x,float y,float z) {
            
        }
        public void wingset(float x,float y ,float z){
            Wingx = x;
            Wingy = y;
            Wingz = z;
        }
        public Vector3 WingEffect(float N) {
            if (N < 30)
                N = 30;
            else if (N > 100)
                N = 100;
           // N = N / 10;
            Vector3 WingVecter = new Vector3(Wingx, Wingy , Wingz);
            return WingVecter*(200/N);
        }
    }
}
