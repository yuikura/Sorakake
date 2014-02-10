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
    class Boader
    {
      
        public int flag = 0;
        public float GetTimer(GameTime gameTime)
        {
            return gameTime.TotalGameTime.Seconds;
            
        }

        public void ReturnSky(ref Vector3 cameraPos, ref Vector3 cameraFront, ref Vector3 cameraUp, ref Vector3 cameraRight) {
            cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(180)));
            cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(cameraRight, MathHelper.ToRadians(180)));
            cameraPos.Y -= 500;
        }

        public void Return(ref Vector3 cameraPos, ref Vector3 cameraFront, ref Vector3 cameraUp, ref Vector3 cameraRight)
        {
           // cameraFront.X *= -1;
           // cameraFront.Y *= -1;
            //cameraFront.Z *= -1;
            cameraFront = Vector3.Transform(cameraFront, Matrix.CreateFromAxisAngle(cameraUp, MathHelper.ToRadians(180)));
            cameraRight = Vector3.Transform(cameraRight, Matrix.CreateFromAxisAngle(cameraUp, MathHelper.ToRadians(180)));
            if (cameraPos.X > 0)
            {
                cameraPos.X -= 500;
            }
            else {
                cameraPos.X += 500;
            }
            if (cameraPos.Z > 0)
            {
                cameraPos.Z -= 500;
            }
            else
            {
                cameraPos.Z += 500;
            }
        }
    }
}
