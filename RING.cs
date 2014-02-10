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
    class RING
    {
        public float startTime, middletime, startTime2, middletime2;
        int flag,flag2,N=0,N2=0;
        public RING() {
            flag = 0;
            flag2 = 0;
        }
        //時間を取得
        public float GetTimer(GameTime gameTime)
        {
            float X;
            X = gameTime.TotalGameTime.Seconds;
            if ((int)X == 0 && N2 == 0)
            {
                N++;
                N2 = 1;
            }
            else if((int)X==1){
                N2 = 0;
            }
            return X+N*60;
        }
        public void RingGame(GameTime gameTime) {
            if (flag == 0) {
                startTime = GetTimer(gameTime);
                flag = 1;
            }
            middletime = GetTimer(gameTime) - startTime;

        }
        public void RingGame2(GameTime gameTime)
        {
            if (flag2 == 0)
            {
                startTime2 = GetTimer(gameTime);
                flag2 = 1;
            }
            middletime2 = GetTimer(gameTime) - startTime2;

        }

    }
}
