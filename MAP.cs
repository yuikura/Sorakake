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
    class MAP
    {
        Texture2D Map;
        Texture2D PLAYER,PLAYER2,Arrow;
        public void Load(ContentManager content)
        {
            Map = content.Load<Texture2D>("MAP");
            PLAYER = content.Load<Texture2D>("Circle");
            PLAYER2 = content.Load<Texture2D>("Arrow");
            Arrow = content.Load<Texture2D>("Arrow2");

        }
        public void MapDraw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont font, GameTime gameTime,Vector3 cameraPos,int Ringgame,int[] ring,Vector3 cameraFront)
        {
            int N = 5,N2=3;
            int[] x={19000,24000,23000,20000,26000,32000,28000};
            int[] y={-8000,5000,-5000,0,0,0,8000};
            if (cameraFront.Z < 0)
            {
                
                spriteBatch.Draw(Arrow, new Vector2(100, 100), null, new Color(new Vector4(255, 255, 255, 0.25f)), MathHelper.ToRadians(cameraFront.X * 90 - 90), new Vector2(Arrow.Width / 2, Arrow.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
            }
            else
            {
                
                spriteBatch.Draw(Arrow, new Vector2(100, 100), null, new Color(new Vector4(255, 255, 255, 0.25f)), MathHelper.ToRadians(-cameraFront.X * 90 + 90), new Vector2(Arrow.Width / 2, Arrow.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
            }
            spriteBatch.Draw(PLAYER, new Rectangle(0 / 600 + 105, 0 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-7000 / 600 + 105, 300 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-13000 / 600 + 105, 8000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-4000 / 600 + 105, 20000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-20000 / 600 + 105, 20000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-10000 / 600 + 105, -10000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-22000 / 600 + 105, -1000 / 600 + 105, N, N), Color.LightYellow);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(20000 / 600 + 105, -30000 / 600 + 105, N, N), Color.LightGreen);  //島

            spriteBatch.Draw(PLAYER, new Rectangle(12000 / 600 + 105, -2300 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(12000 / 600 + 105, -5300 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(33000 / 600 + 105, -18000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(4000 / 600 + 105, 4500 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(7000 / 600 + 105, 10000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-12700 / 600 + 105, -35000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(12500 / 600 + 105, 23000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(40000 / 600 + 105, 35000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(0 / 600 + 105, 40000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(25000 / 600 + 105, 10000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(20000 / 600 + 105, 30000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-50000 / 600 + 105, 1000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-47000 / 600 + 105, 38000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(48000 / 600 + 105, -1000 / 600 + 105, N, N), Color.LightGreen);  //島
          //  spriteBatch.Draw(PLAYER, new Rectangle(-55000 / 600 + 105, 54000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-25000 / 600 + 105, 49000 / 600 + 105, N, N), Color.LightGreen);  //島
            spriteBatch.Draw(PLAYER, new Rectangle(-30000 / 600 + 105, 35000 / 600 + 105, N, N), Color.LightGreen);  //島
            if (cameraFront.Z < 0)
            {
                spriteBatch.Draw(PLAYER2, new Vector2(cameraPos.X / 600 + 107, cameraPos.Z / 600 + 107), null, Color.Red, MathHelper.ToRadians(cameraFront.X * 90 - 90), new Vector2(PLAYER2.Width / 2, PLAYER2.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                
            }
            else
            {
                spriteBatch.Draw(PLAYER2, new Vector2(cameraPos.X / 600 + 107, cameraPos.Z / 600 + 107), null, Color.Red, MathHelper.ToRadians(-cameraFront.X * 90 + 90), new Vector2(PLAYER2.Width / 2, PLAYER2.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                
            }
                //spriteBatch.Draw(PLAYER2, new Vector2(cameraPos.X/600+107, cameraPos.Z/600+107), Color.Red);
            if (Ringgame == 1) {
                for (int i = 0; i < 7; i++) { 
                    if(ring[i]==0)
                        spriteBatch.Draw(PLAYER, new Rectangle(x[i] / 600 + 105, -y[i] / 600 + 105, N2, N2), Color.Gold);  //リング
                }
            }
            spriteBatch.Draw(Map, new Vector2(0, 0), Color.White);
        }
    }
}
