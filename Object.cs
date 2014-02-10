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
    class SORA
    {
        protected string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        // モデル情報
        static Model model;
        protected string modelAsset;

        // テクスチャ情報
        static Texture2D texture;
        protected string textureAsset;

        // 座標
        protected Vector3 position;
        public Vector3 Position
        {
            get
            {
                return position;
            }
        }


        public SORA()
        {
            // 初期化
            name = "Space";
            modelAsset = "space";
            textureAsset = "SKY2";
            position = new Vector3(0, 150, 0);

        }
        // オブジェクトの呼び出し
        public void Load(ContentManager content)
        {
            model = content.Load<Model>(modelAsset);
            texture = content.Load<Texture2D>(textureAsset);
        }
        // 空の表示
        public void Draw(Matrix view, Matrix projection, float radian, float radians)
        {

            // ワールド座標変換行列

            Matrix world = Matrix.CreateTranslation(position) * Matrix.CreateScale(radians*3);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    // ライティングを有効
                    effect.EnableDefaultLighting();


                    // テクスチャを有効
                    effect.TextureEnabled = true;
                    effect.Texture = texture;
                    // 変換
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
        }

    }


    class SKY
    {
        protected string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        // モデル情報
        static Model model;
        protected string modelAsset;

        // テクスチャ情報
        static Texture2D texture;
        protected string textureAsset;

        // 座標
        protected Vector3 position;
        public Vector3 Position
        {
            get
            {
                return position;
            }
        }


        public SKY()
        {
            // 初期化
            name = "sea";
            modelAsset = "sea";
            textureAsset = "earth";
            //position = new Vector3(0, 0, 0);

        }
        // オブジェクトの呼び出し
        public void Load(ContentManager content)
        {
            model = content.Load<Model>(modelAsset);
            // texture = content.Load<Texture2D>(textureAsset);
        }
        // サンプルの表示
        public void Draw(Matrix view, Matrix projection, float x, float y, float z)
        {

            // ワールド座標変換行列
            // Matrix world = Matrix.CreateScale(0.03f) * Matrix.CreateTranslation(300, 0, 0);
            Matrix world = Matrix.CreateScale(1000f) * Matrix.CreateTranslation(x, y - 2350, z);
            //view = Matrix.CreateLookAt(new Vector3(camera.X, camera.Y, camera.Z), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    // ライティングを有効
                    effect.EnableDefaultLighting();


                    // テクスチャを有効
                    //  effect.TextureEnabled = true;
                    // effect.Texture = texture;
                    // 変換
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
        }

    }

    class OBJECT
    {
        // オブジェクトタイプ
        public int object_type = 0;

        // 円周率
        const float PI = 3.141592f;

        // 当たり判定の最大数
        const int MAX_B = 1024;

        // 当たり判定用の boundingSphere
        public BoundingSphere[] BSphere = new BoundingSphere[MAX_B];

        public bool enable = false; // モデルの状態(有効/無効)
        public int BS_MAX = 0; // 登録されているBundingSphereの数(最大MAX_B個)

        // モデル情報
        Model model; // モデル
        Model model_BSphere; //　BoundingSphere描画用の単位球モデル
        protected string modelAsset; // 本体モデル

        // 座標および半径
        public float size = 0; // モデルの拡大率
        public float rotate = 0; // モデルの角度
        public Vector3 position = Vector3.Zero; // モデルの座標

        /// <summary>
        /// コンストラクタ(オブジェクトの初期設定)
        /// </summary>
        /// <param name="AssetValue">モデルの参照ネーム</param>
        /// <param name="radiusValue">モデルの拡大率</param>
        /// <param name="vectorValue">オブジェクトの設定座標</param>
        /// <param name="rotateValue">オブジェクトの回転角度(Y座標基準:360°)</param>
        /// <param name="state">オブジェクトの状態(有効/無効)</param>
        public OBJECT()
        {
            enable = false;
            for (int i = 0; i < BS_MAX; i++)
            {
                // 当たり判定の座標
                BSphere[i].Center = Vector3.Zero;
                // 当たり判定の半径
                BSphere[i].Radius = 0;
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Set_object()
        {
            // 初期化
            // 本体情報
            enable = false;
            modelAsset = "none";
            position = Vector3.Zero;
            size = 0f;
            rotate = 0f;

            // 当たり判定
            BSphere[0].Center = Vector3.Zero;
            BSphere[0].Radius = 0f;
        }

        /// <summary>
        /// 最小の情報だけでモデルをセットする(ContentLoadが別に必要)
        /// </summary>
        /// <param name="objectType">モデルタイプ</param>
        /// <param name="vector">座標</param>
        /// <param name="rotateValue">角度(360°)</param>
        public void Set_object(int objectType, Vector3 vector, float rotateValue,int objecttype)
        {
            enable = true;
            position = vector;
            rotate = rotateValue / 180 * PI;
            object_type = objecttype;

            switch (objectType)
            {

                // テスト
                case 0:
                    // 本体情報
                    modelAsset = "sphere1uR";
                    size = 1f;

                    // 当たり判定
                    BS_MAX = 1;
                    Set_BSphere(0, new Vector3(0, 0, 0), 10f);

                    break;
                // 島1
                case 1:
                    // 本体情報
                    modelAsset = "shima_4";
                    size = 10f;

                    // 当たり判定
                    BS_MAX = 4;
                    Set_BSphere(0, new Vector3(-300, -8700, 300), 9000f);
                    Set_BSphere(1, new Vector3(-300, -8700, -300), 9000f);
                    Set_BSphere(2, new Vector3(300, -8700, 300), 9000f);
                    Set_BSphere(3, new Vector3(300, -8700, -300), 9000f);
                    break;
                // 島2
                case 2:
                    // 本体情報
                    modelAsset = "shima_5";
                    size = 1000f;

                    // 当たり判定
                    BS_MAX = 4;
                    Set_BSphere(0, new Vector3(-300, -8700, 500), 9000f);
                    Set_BSphere(1, new Vector3(-500, -8720, -500), 9000f);
                    Set_BSphere(2, new Vector3(800, -8700, 400), 9000f);
                    Set_BSphere(3, new Vector3(300, -8700, -300), 9000f);
                    break;
                // 島3
                case 3:
                    // 本体情報
                    modelAsset = "shima_6";
                    size = 1000f;

                    // 当たり判定
                    BS_MAX = 7;
                    Set_BSphere(0, new Vector3(-500, -8780, 500), 9000f);
                    Set_BSphere(1, new Vector3(-500, -8780, -500), 9000f);
                    Set_BSphere(2, new Vector3(500, -8780, 500), 9000f);
                    Set_BSphere(3, new Vector3(500, -8780, -500), 9000f);
                    Set_BSphere(4, new Vector3(700, -8750, 2000), 9000f);
                    Set_BSphere(5, new Vector3(1200, -8790, 3000), 9000f);
                    Set_BSphere(6, new Vector3(-500, -8780, 1500), 9000f);
                    break;
                // 島4
                case 4:
                    // 本体情報
                    modelAsset = "shima_7";
                    size = 1000f;

                    // 当たり判定
                    BS_MAX = 4;
                    Set_BSphere(0, new Vector3(-300, -8750, 300), 9000f);
                    Set_BSphere(1, new Vector3(-800, -8750, -800), 9000f);
                    Set_BSphere(2, new Vector3(800, -8750, 800), 9000f);
                    Set_BSphere(3, new Vector3(400, -8750, -400), 9000f);
                    break;
                // 島5
                case 5:
                    // 本体情報
                    modelAsset = "shima_8";
                    size = 1000f;

                    // 当たり判定
                    BS_MAX = 5;
                    Set_BSphere(0, new Vector3(-700, -8750, 700), 9000f);
                    Set_BSphere(1, new Vector3(-700, -8750, -700), 9000f);
                    Set_BSphere(2, new Vector3(700, -8750, 700), 9000f);
                    Set_BSphere(3, new Vector3(700, -8750, -700), 9000f);
                    Set_BSphere(4, new Vector3(0, -8750, 0), 9000f);
                    break;
                // 島6
                case 6:
                    // 本体情報
                    modelAsset = "shima_9";
                    size = 1000f;

                    // 当たり判定
                    BS_MAX = 6;
                    Set_BSphere(0, new Vector3(-600, -8750, 700), 9000f);
                    Set_BSphere(1, new Vector3(-1000, -8750, -200), 9000f);
                    Set_BSphere(2, new Vector3(-1700, -8800, -500), 9000f);
                    Set_BSphere(3, new Vector3(700, -8750, 700), 9000f);
                    Set_BSphere(4, new Vector3(700, -8730, -800), 9000f);
                    Set_BSphere(5, new Vector3(0, -8750, 100), 9000f);
                    break;
                // 木
                case 7:
                    // 本体情報
                    modelAsset = "tree_1";
                    size = 70f;
                    Set_BSphere(0, new Vector3(0, 0, 0), 1f);
                    // 当たり判定
                    BS_MAX = 1;
                    break;
                // 雲
                case 8:
                    // 本体情報
                    modelAsset = "kumo";
                    size = 70f;
                    Set_BSphere(0, new Vector3(0, 0, 0), 1f);
                    // 当たり判定
                    BS_MAX = 1;
                    break;
                //家
                case 9:
                    // 本体情報
                    modelAsset = "ie";
                    size = 70f;
                    Set_BSphere(0, new Vector3(0, 0, 0), 1f);
                    // 当たり判定
                    BS_MAX = 1;
                    break;
                case 10:                //船
                    // 本体情報
                    modelAsset = "ship";
                    size = 0.7f;
                    Set_BSphere(0, new Vector3(0, 0, 0), 1f);
                    // 当たり判定
                    BS_MAX = 1;
                    break;
                case 11:                //島
                    // 本体情報
                    modelAsset = "shima_3";
                    size = 3f;
                    Set_BSphere(0, new Vector3(0, 0, 0), 1f);
                    // 当たり判定
                    BS_MAX = 0;
                    break;
                case 12:                //リング
                    // 本体情報
                    modelAsset = "Ring";
                    size = 420f;

                    // 当たり判定
                    BS_MAX = 1;
                    Set_BSphere(0, new Vector3(0, 0, 0), 600f);
                    break;
                case 13:                //帆船
                    // 本体情報
                    modelAsset = "ship_1";
                    size = 0.7f;
                    Set_BSphere(0, new Vector3(0, -200, 0), 300f);
                    // 当たり判定
                    BS_MAX = 1;
                    break;
                case 14:                //城
                    // 本体情報
                    modelAsset = "siro_0";
                    size = 0.7f;
                    Set_BSphere(0, new Vector3(0, 0, 0), 0f);
                    // 当たり判定
                    BS_MAX = 1;
                    break;

                case 15:                //ラピュタ
                    // 本体情報
                    modelAsset = "shima_3_";
                    size = 10f;
                    Set_BSphere(0, new Vector3(0, 0, 0), 30f);
                    int Num=0;
                    for (int i = 1; i < 24; i++)
                    {
                        for (int j = 0; j < 24; j++)
                        {
                          
                            Set_BSphere(Num, new Vector3(i * 100 - 1200, -120, j * 100 - 1200), 200f);
                            Num++;
                        }
                    }
                    // 当たり判定
                    BS_MAX = 144*4;
                    break;
                case 16:                //モアイ
                    // 本体情報
                    modelAsset = "moai";
                    size = 0.7f;
                    Set_BSphere(0, new Vector3(0, 0, 0), 0f);
                    // 当たり判定
                    BS_MAX = 1;
                    break;
                case 17:                //くじら
                    // 本体情報
                    modelAsset = "kujira";
                    size = 0.7f;
                    Set_BSphere(0, new Vector3(0, 0, 0), 0f);
                    // 当たり判定
                    BS_MAX = 1;
                    break;
                case 18:                //看板
                    // 本体情報
                    modelAsset = "board_sorakake";
                    size = 0.7f;
                    Set_BSphere(0, new Vector3(0, 00, 0), 0f);
                    // 当たり判定
                    BS_MAX = 1;
                    break;
            }
           
        }

        /// <summary>
        /// BoundingSphereの設定
        /// </summary>
        /// <param name="SphereNo">設定する判定の識別番号</param>
        /// <param name="vector">設定する判定の座標(モデルの中心との相対座標)</param>
        /// <param name="radius">判定の大きさ</param>
        public void Set_BSphere(int SphereNo, Vector3 vector, float radius)
        {
            float range = vector.Length();

            //BSphere[SphereNo].Center = Vector3.Add((range * Vector3.Transform(vector, Matrix.CreateRotationY(rotate))), position);

            BSphere[SphereNo].Center = Vector3.Add(vector, position);

            BSphere[SphereNo].Radius = radius;
        }

        /// <summary>
        /// モデルのロード(ロードする前にあらかじめアセット名を入力しておく)
        /// </summary>
        /// <param name="content">モデルのアセット名</param>
        public void Load(ContentManager content)
        {
            model = content.Load<Model>(modelAsset);
            model_BSphere = content.Load<Model>("sphere1uR");
        }

        public void Update()
        {
            if (object_type == 2)
                rotate += 0.1f;
        }

        /// <summary>
        /// モデルの描画
        /// </summary>
        public void Draw(Matrix view, Matrix projection)
        {
            // ワールド座標変換行列
            Matrix world = Matrix.CreateScale(size) * Matrix.CreateRotationY(rotate) * Matrix.CreateTranslation(position.X, position.Y, position.Z);
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    // ライティングを有効
                    effect.EnableDefaultLighting();
                    // 変換
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
        }

        /// <summary>
        /// 当たり判定の描画(FireFlame推奨)
        /// </summary>
        public void DrawBounding(Matrix view, Matrix projection)
        {
            for (int i = 0; i < BS_MAX; i++)
            {
                // ワールド座標変換行列
                Matrix world = Matrix.CreateScale(BSphere[i].Radius * 100) * Matrix.CreateRotationY(0) * Matrix.CreateTranslation(BSphere[i].Center.X, BSphere[i].Center.Y, BSphere[i].Center.Z);
                foreach (ModelMesh mesh in model_BSphere.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        // ライティングを有効
                        effect.EnableDefaultLighting();
                        // 変換
                        effect.World = world;
                        effect.View = view;
                        effect.Projection = projection;
                    }
                    mesh.Draw();
                }
            }
        }

        /// <summary>
        /// 当たり判定の取得
        /// </summary>
        /// <param name="target">自機のBoundingSphere</param>
        /// <param name="targetNo">対象の当たり判定(識別番号)</param>
        /// <returns>bool</returns>
        public bool Hit(BoundingSphere target, int targetNo)
        {
            return BSphere[targetNo].Intersects(target);
        }
    }
}