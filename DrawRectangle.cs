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
    class DrawRectangle
    {
        // テレビカメラが撮影した画面を表示する四角形の枠を描画
        // ここにレンダリングテクスチャを貼ってテレビカメラが撮影した絵を表示する
        // テレビ画面の画像はレンダリングテクスチャを貼る

        // 四角形
        static VertexDeclaration vertexDeclarationRectangle = null;
        static VertexBuffer vertexBufferRectangle = null;

        // この描画で使用するエフェクト
        static BasicEffect basicEffect = null;

        // テクスチャ
        // デバック用
        static Texture2D texture_banana = null;
        static Texture2D texture_earth = null;

        

        // 四角形
        public void Load(GraphicsDeviceManager graphics, ContentManager Content)
        {
            // エフェクトを作成
            basicEffect = new BasicEffect(graphics.GraphicsDevice, null);

            // テクスチャーの読み込み
           // texture_banana = Content.Load<Texture2D>("earth");
            //texture_earth = Content.Load<Texture2D>("earth");

            // テクスチャを貼った四角形のデータの作成
            // TODO: use this.Content to load your game content here
           //  頂点定義データを作成・・頂点位置とテクスチャ座標を持っている
            vertexDeclarationRectangle = new VertexDeclaration(graphics.GraphicsDevice, VertexPositionColorTexture.VertexElements);
            // 頂点バッファ作成
            vertexBufferRectangle = new VertexBuffer(graphics.GraphicsDevice, VertexPositionColorTexture.SizeInBytes * 4, BufferUsage.None);
            // 頂点データを作成する
            VertexPositionColorTexture[] vertices = new VertexPositionColorTexture[4];

            float size = 150.0f;
            float h_size = graphics.GraphicsDevice.Viewport.Width / size;
            float V_size = graphics.GraphicsDevice.Viewport.Height / size;
            vertices[0] = new VertexPositionColorTexture(new Vector3(-h_size, V_size, 0.0f), Color.Black, new Vector2(0.0f, 0.0f));
            vertices[1] = new VertexPositionColorTexture(new Vector3(-h_size, -V_size, 0.0f), Color.Black, new Vector2(0.0f, 1.0f));
            vertices[2] = new VertexPositionColorTexture(new Vector3(h_size, V_size, 0.0f), Color.Black, new Vector2(1.0f, 0.0f));
            vertices[3] = new VertexPositionColorTexture(new Vector3(h_size, -V_size, 0.0f), Color.Black, new Vector2(1.0f, 1.0f));
            // 頂点バッファにデータを書き込む
            vertexBufferRectangle.SetData<VertexPositionColorTexture>(vertices);
        }

        // ウインドウサイズの変更に対応
        public void UpDate(GraphicsDeviceManager graphics, ContentManager Content)
        {
            // エフェクトを作成
            basicEffect = null;

            // テクスチャーの読み込み
            texture_banana = null;
            texture_earth = null;
            this.Load(graphics, Content);
        }

        public void DrawFrame(ref GraphicsDeviceManager graphics, Matrix view, Matrix projection, Texture2D texture,Vector3 cameraPos,Vector3 cameraFront)
        {
            // カルモードの設定
            graphics.GraphicsDevice.RenderState.CullMode = CullMode.None;

            // 色を指定した四角形のデータの描画
            basicEffect.VertexColorEnabled = true;
            // テクスチャーの使用を許可する
            basicEffect.TextureEnabled = false;

            // 表示位置の変更
            Vector3 shift = new Vector3(cameraFront.X,cameraFront.Y,cameraFront.Z/*cameraPos.X+260 , cameraPos.Y , cameraPos.Z-80*/);
            basicEffect.World = Matrix.Identity * Matrix.CreateScale(1.03f) * Matrix.CreateTranslation(shift);
            basicEffect.View = view;
            basicEffect.Projection = projection;

            // 頂点データの定義
            graphics.GraphicsDevice.VertexDeclaration = vertexDeclarationRectangle;
            // 頂点バッファセット
            graphics.GraphicsDevice.Vertices[0].SetSource(vertexBufferRectangle, 0, VertexPositionColorTexture.SizeInBytes);

            // エフェクト開始
            basicEffect.Begin();
            // パス
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                // パスの開始
                pass.Begin();
                // 描画
                graphics.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
                // パスの終了
                pass.End();
            }
            // エフェクト終了
            basicEffect.End();

            // カルモードの設定
            graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullCounterClockwiseFace;
        }

        public void Draw(ref GraphicsDeviceManager graphics, Matrix view, Matrix projection, RenderTarget2D texRender, Vector3 cameraPos)
        {
            // カルモードの設定
            graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullClockwiseFace;

            // 色を指定した四角形のデータの描画
             basicEffect.VertexColorEnabled = false;
            // テクスチャーの使用
             basicEffect.Texture = texRender.GetTexture();
             basicEffect.TextureEnabled = true;

            // 表示位置の変更
             Vector3 shift = new Vector3(cameraPos.X+260 , cameraPos.Y, cameraPos.Z -80);
            basicEffect.World = Matrix.Identity * Matrix.CreateTranslation(shift);
            basicEffect.View = view;
            basicEffect.Projection = projection;

            // 頂点データの定義
            graphics.GraphicsDevice.VertexDeclaration = vertexDeclarationRectangle;
            // 頂点バッファセット
            graphics.GraphicsDevice.Vertices[0].SetSource(vertexBufferRectangle, 0, VertexPositionColorTexture.SizeInBytes);

            // エフェクト開始
            basicEffect.Begin();
            // パス
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                // パスの開始
                pass.Begin();
                // 描画
                graphics.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
                // パスの終了
                pass.End();
            }
            // エフェクト終了
            basicEffect.End();

            // カルモードの設定
            graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullCounterClockwiseFace;
        }

        
    }
}
