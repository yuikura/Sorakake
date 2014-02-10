using System;
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
    
    class Render
    {
       
        //レンダリング・ターゲット
        // 空間の宣言
        SKY sky = new SKY();

        SORA sora = new SORA();
        float size = 150;
        float h_size, V_size;
        public Render() { 
        
        }
        //画面のロード
        public void Load(GraphicsDeviceManager graphics, ContentManager Content)
        {
            
        }
        public void Initialize(ref GraphicsDeviceManager graphics,ref RenderTarget2D texRender,ref DepthStencilBuffer depthRender)
        {
            texRender = new RenderTarget2D(graphics.GraphicsDevice, 800, 400, 1, SurfaceFormat.Color);
            depthRender = new DepthStencilBuffer(graphics.GraphicsDevice, 800, 400, DepthFormat.Depth24Stencil8, MultiSampleType.None, 0);
        }

        
    }
}
