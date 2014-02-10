using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace SORAKAKE.Ver1
{
    class White
    {
        Texture2D sun;
        Texture2D white;
        Texture2D circle;

        public White()
        {
        }

        public void Load(ContentManager content)
        {
            sun = content.Load<Texture2D>("particle/Sun");
            white = content.Load<Texture2D>("particle/white");
            circle = content.Load<Texture2D>("particle/sunCircle");
        }

        // 明るさの調節
        public void Update()
        { 
        }

        public void Draw(ref GraphicsDeviceManager graphics, ref SpriteBatch spriteBatch,Vector2 v2)
        {
            spriteBatch.Draw(sun, v2,null, Color.White,0,new Vector2(128,128),0.5f,0,1);
        }

        public void Draw(ref GraphicsDeviceManager graphics, ref SpriteBatch spriteBatch, float alpha)
        {
            spriteBatch.Draw(white, new Vector2(0, 0), new Color(255, 255, 255, alpha));
        }

        public void Draw(ref GraphicsDeviceManager graphics, ref SpriteBatch spriteBatch, float alpha,Vector2 v2,float scale)
        {
            spriteBatch.Draw(circle, v2,null, new Color(255, 255, 255, alpha),0,new Vector2(128,128),scale,0,0);
        }
    }
}
