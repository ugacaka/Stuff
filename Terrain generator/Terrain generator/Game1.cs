using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;

namespace Terrain_Generator
{
    public class Terrain
    {
        Vector3 baseXYZ;
        public VertexPositionColor[] vertices;
        int[] indices;
        Color[] gradient;
        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;
        BasicEffect basicEffect;
        public float size;
        public int indsize;
        int brtacaka;
        int brtacakax;
        int brtacakaz;
        string path, path2;
        public Terrain(GraphicsDevice g, GraphicsDeviceManager graphics, Vector3 baseXYZ, Color color1, int brtacakax, int brtacakaz)
        {
            gradient = MakeG(10, 20, 105, 101, 67, 33, 101, 67, 33, 128, 128, 128, 255, 255, 255);
            this.brtacakax = brtacakax;
            this.brtacakaz = brtacakaz;
            brtacaka = brtacakax * brtacakaz;
            indsize = 6 * (brtacakax - 1) * (brtacakaz - 1);
            vertices = new VertexPositionColor[brtacaka];
            indices = new int[indsize];
            vertexBuffer = new VertexBuffer(g, typeof(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly);
            indexBuffer = new IndexBuffer(graphics.GraphicsDevice, typeof(int), indices.Length, BufferUsage.WriteOnly);
            basicEffect = new BasicEffect(g);
            basicEffect.VertexColorEnabled = true;
            this.baseXYZ = baseXYZ;
            size = 0.1f;//2
            int t = 0;
            for (int i = 0; i < brtacakaz; i++)
            {
                for (int j = 0; j < brtacakax; j++)
                {
                    vertices[t] = new VertexPositionColor(this.baseXYZ + new Vector3(j * size, 0, i * size), color1);
                    t++;
                }
            }
            t = 0;
            for (int i = 0; i < brtacakaz - 1; i++)
            {
                for (int j = 0; j < brtacakax - 1; j++)
                {
                    indices[t] = j + i * brtacakax;
                    indices[t + 1] = j + 1 + i * brtacakax;
                    indices[t + 2] = j + 1 + brtacakax + i * brtacakax;
                    indices[t + 3] = j + brtacakax + i * brtacakax;
                    indices[t + 4] = j + i * brtacakax;
                    indices[t + 5] = j + 1 + brtacakax + i * brtacakax;
                    t += 6;
                }
            }
            vertexBuffer.SetData(vertices);
            indexBuffer.SetData(indices);
        }
        public VertexBuffer GetVertexBuffer()
        {
            return vertexBuffer;
        }
        public IndexBuffer GetIndexBuffer()
        {
            return indexBuffer;
        }
        public void SetPath(string path)
        {
            this.path = path;
        }
        public void SetPath2(string path2)
        {
            this.path2 = path2;
        }
        public BasicEffect GetBasicEffect()
        {
            return basicEffect;
        }
        public void SetBasicEffectPMW(Matrix projectionMatrix, Matrix viewMatrix, Matrix worldMatrix)
        {
            basicEffect.Projection = projectionMatrix;
            basicEffect.View = viewMatrix;
            basicEffect.World = worldMatrix;
        }
        public Vector3 GetBaseXYZ()
        {
            return this.baseXYZ;
        }
        public float GetTriangle(Vector3 pos)
        {
            Vector3 A, B, C;
            float x1, x2, x3, z1, z2, z3;
            float ceilx = (float)(Math.Ceiling(pos.X / size) * size);
            float ceilz = (float)(Math.Ceiling(pos.Z / size) * size);
            float floorx = (float)(Math.Floor(pos.X / size) * size);
            float floorz = (float)(Math.Floor(pos.Z / size) * size);
            x1 = ceilx - pos.X < pos.X - floorx ? ceilx : floorx;
            z1 = ceilz - pos.Z < pos.Z - floorz ? ceilz : floorz;
            x2 = ceilx;
            z2 = ceilz;
            x3 = floorx;
            z3 = floorz;
            if (x1 == x3 && z1 == z3)
            {
                if (x3 % 2 > z3 % 2)
                {
                    x3 = ceilx;
                    z3 = floorz;
                }
                else
                {
                    x3 = floorx;
                    z3 = ceilz;
                }
            }
            if (x1 == x2 && z1 == z2)
            {
                if (x2 % 2 > z2 % 2)
                {
                    x2 = ceilx;
                    z2 = floorz;
                }
                else
                {
                    x2 = floorx;
                    z2 = ceilz;
                }
            }
            A = new Vector3(x1, vertices[(int)(x1 / size + (z1 / size) * brtacakax)].Position.Y, z1);
            B = new Vector3(x2, vertices[(int)(x2 / size + (z2 / size) * brtacakax)].Position.Y, z2);
            C = new Vector3(x3, vertices[(int)(x3 / size + (z3 / size) * brtacakax)].Position.Y, z3);
            return GroundHeight(GetVector4(A, B, C), pos);
        }
        Vector4 GetVector4(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            Vector3 pom = Vector3.Cross((v1 - v2), (v3 - v2));
            float d = pom.X * v2.X + pom.Y * v2.Y + pom.Z * v2.Z;
            return new Vector4(pom.X, pom.Y, pom.Z, -d);
        }
        float GroundHeight(Vector4 triangle, Vector3 vector)
        {
            if (triangle.Y == 0) return 0;
            return (triangle.X * vector.X + triangle.Z * vector.Z + triangle.W) / (-triangle.Y);
        }
        Color[] MakeG(int r1, int g1, int b1, int r2, int g2, int b2, int r3, int g3, int b3, int r4, int g4, int b4, int r5, int g5, int b5)
        {
            Color[] makeg = new Color[256];
            makeg[0] = new Color(r1, g1, b1, 255);
            r1++; g1++; b1++; r2++; g2++; b2++; r3++; g3++; b3++; r4++; g4++; b4++; r5++; g5++; b5++;
            float r, g, b;
            r = r1;
            g = g1;
            b = b1;
            for (int i = 1; i < 256; i++)
            {
                if (i <= 63)
                {
                    r += (r2 - r1) / 64f;
                    g += (g2 - g1) / 64f;
                    b += (b2 - b1) / 64f;
                }
                else if (i <= 127)
                {
                    r += (r3 - r2) / 64f;
                    g += (g3 - g2) / 64f;
                    b += (b3 - b2) / 64f;
                }
                else if (i <= 191)
                {
                    r += (r4 - r3) / 64f;
                    g += (g4 - g3) / 64f;
                    b += (b4 - b3) / 64f;
                }
                else
                {
                    r += (r5 - r4) / 64f;
                    g += (g5 - g4) / 64f;
                    b += (b5 - b4) / 64f;
                }
                makeg[i] = new Color((int)r - 1, (int)g - 1, (int)b - 1, 255);
            }
            return makeg;
        }
        public void UpCube()
        {
            Task t1 = Task.Factory.StartNew(() => {
                Bitmap bmp = new Bitmap(path);
                Bitmap bmp2 = new Bitmap(path2);
                int h = bmp.Height < brtacakaz ? bmp.Height : brtacakaz;
                int w = bmp.Width < brtacakax ? bmp.Width : brtacakax;
                for (int y = 0; y < h / 4; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        System.Drawing.Color v = bmp.GetPixel(x, y);
                        System.Drawing.Color v2 = bmp2.GetPixel(x, y);
                        vertices[x + y * brtacakax].Position.Y = v.B * size;
                        vertices[x + y * brtacakax].Color.R = v2.R;
                        vertices[x + y * brtacakax].Color.G = v2.G;
                        vertices[x + y * brtacakax].Color.B = v2.B;
                    }
                }
                bmp.Dispose();
                bmp2.Dispose();
            });

            Task t2 = Task.Factory.StartNew(() => {
                Bitmap bmp = new Bitmap(path);
                Bitmap bmp2 = new Bitmap(path2);
                int h = bmp.Height < brtacakaz ? bmp.Height : brtacakaz;
                int w = bmp.Width < brtacakax ? bmp.Width : brtacakax;
                for (int y = h / 4; y < h / 2; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        System.Drawing.Color v = bmp.GetPixel(x, y);
                        System.Drawing.Color v2 = bmp2.GetPixel(x, y);
                        vertices[x + y * brtacakax].Position.Y = v.B * size;
                        vertices[x + y * brtacakax].Color.R = v2.R;
                        vertices[x + y * brtacakax].Color.G = v2.G;
                        vertices[x + y * brtacakax].Color.B = v2.B;
                    }
                }
                bmp.Dispose();
                bmp2.Dispose();
            });
            Task t3 = Task.Factory.StartNew(() => {
                Bitmap bmp = new Bitmap(path);
                Bitmap bmp2 = new Bitmap(path2);
                int h = bmp.Height < brtacakaz ? bmp.Height : brtacakaz;
                int w = bmp.Width < brtacakax ? bmp.Width : brtacakax;
                for (int y = h / 2; y < 3 * (h / 4); y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        System.Drawing.Color v = bmp.GetPixel(x, y);
                        System.Drawing.Color v2 = bmp2.GetPixel(x, y);
                        vertices[x + y * brtacakax].Position.Y = v.B * size;
                        vertices[x + y * brtacakax].Color.R = v2.R;
                        vertices[x + y * brtacakax].Color.G = v2.G;
                        vertices[x + y * brtacakax].Color.B = v2.B;
                    }
                }
                bmp.Dispose();
                bmp2.Dispose();
            });
            Task t4 = Task.Factory.StartNew(() => {
                Bitmap bmp = new Bitmap(path);
                Bitmap bmp2 = new Bitmap(path2);
                int h = bmp.Height < brtacakaz ? bmp.Height : brtacakaz;
                int w = bmp.Width < brtacakax ? bmp.Width : brtacakax;
                for (int y = 3 * (h / 4); y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        System.Drawing.Color v = bmp.GetPixel(x, y);
                        System.Drawing.Color v2 = bmp2.GetPixel(x, y);
                        vertices[x + y * brtacakax].Position.Y = v.B * size;
                        vertices[x + y * brtacakax].Color.R = v2.R;
                        vertices[x + y * brtacakax].Color.G = v2.G;
                        vertices[x + y * brtacakax].Color.B = v2.B;
                    }
                }
                bmp.Dispose();
                bmp2.Dispose();
            });
            t1.Wait();
            t2.Wait();
            t3.Wait();
            t4.Wait();
        }
    }
    public class Camera
    {
        Vector3 cameraPosition;
        const float rotationSpeed = 0.3f;
        float updownRot;
        float leftrightRot;
        float moveSpeed;
        Matrix projectionMatrix;
        Matrix viewMatrix;
        Matrix worldMatrix;
        bool hasJumped;
        float jumpVelocity;
        float tall,tall2;
        public Camera(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
            tall = 10f;
            tall2 = 0;
            jumpVelocity = 0;
            hasJumped = false;
            updownRot = -MathHelper.Pi / 10f;
            leftrightRot = MathHelper.PiOver2;
            worldMatrix = Matrix.Identity;
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60f), 1.6f, 1f, 2000f);
            cameraPosition = new Vector3(0f, 10, 0f);
        }
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        MouseState originalMouseState;
        KeyboardState previousState;
        Vector3 cameraPosition = new Vector3(0f, 10, 0f);
        const float rotationSpeed = 0.3f;
        float updownRot = -MathHelper.Pi / 10f;
        float leftrightRot = MathHelper.PiOver2;
        float moveSpeed = 120f;
        Matrix projectionMatrix;
        Matrix viewMatrix;
        Matrix worldMatrix;
        VertexBuffer[] xyzBuffer;
        BasicEffect xyzEffect;
        Terrain ground;
        VertexPositionColor[] crvenaX, zelenaY, plavaZ;
        bool hasJumped = false;
        float jumpVelocity = 0;
        float tall = 10f, tall2 = 0;
        static int x = 500, y = 500;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1680;
            graphics.PreferredBackBufferHeight = 1050;
            graphics.IsFullScreen = true;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            previousState = Keyboard.GetState();
            Mouse.SetPosition((int)GraphicsDevice.Viewport.Width / 2, (int)GraphicsDevice.Viewport.Height / 2);
            originalMouseState = Mouse.GetState();
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60f), 1.6f, 1f, 2000f);
            worldMatrix = Matrix.Identity;
            ground = new Terrain(GraphicsDevice, graphics, new Vector3(0, 0, 0), Color.Black, 500, 500);
            ground.SetPath(@"C:\Users\Ugacaka\source\repos\Terrain generator\slike\mapa5.png");
            ground.SetPath2(@"C:\Users\Ugacaka\source\repos\Terrain generator\slike\mapa5.png");
            Xyz();


            base.Initialize();
        }
        protected void Xyz()
        {
            xyzEffect = new BasicEffect(GraphicsDevice);
            xyzEffect.Alpha = 1f;
            xyzEffect.VertexColorEnabled = true;
            xyzEffect.LightingEnabled = false;
            crvenaX = new VertexPositionColor[2];
            zelenaY = new VertexPositionColor[2];
            plavaZ = new VertexPositionColor[2];
            xyzBuffer = new VertexBuffer[3];
            for (int i = 0; i < 3; i++) xyzBuffer[i] = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 2, BufferUsage.WriteOnly);
            crvenaX[0] = new VertexPositionColor(new Vector3(100000, 0, 0), Color.Red);
            crvenaX[1] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Red);
            zelenaY[0] = new VertexPositionColor(new Vector3(0, 100000, 0), Color.Green);
            zelenaY[1] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Green);
            plavaZ[0] = new VertexPositionColor(new Vector3(0, 0, 100000), Color.Blue);
            plavaZ[1] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Blue);
            xyzBuffer[0].SetData(crvenaX);
            xyzBuffer[1].SetData(zelenaY);
            xyzBuffer[2].SetData(plavaZ);
        }
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                KeyboardState keyState = Keyboard.GetState();
                MouseState currentMouseState = Mouse.GetState();
                //camera.sendkeystate and mouse state
                if (keyState.IsKeyDown(Keys.Escape))
                    Exit();
                float amount = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
                
                if (currentMouseState != originalMouseState)
                {
                    float xDifference = currentMouseState.X - originalMouseState.X;
                    float yDifference = currentMouseState.Y - originalMouseState.Y;
                    leftrightRot -= rotationSpeed * xDifference * amount / 1.4f;
                    updownRot -= rotationSpeed * yDifference * amount / 1.4f;
                    Mouse.SetPosition((int)GraphicsDevice.Viewport.Width / 2, (int)GraphicsDevice.Viewport.Height / 2);
                }
                Vector3 moveVector = new Vector3(0, 0, 0);
                if (keyState.IsKeyDown(Keys.W)) moveVector.Z -= 1f;
                if (keyState.IsKeyDown(Keys.S)) moveVector.Z += 1f;
                if (keyState.IsKeyDown(Keys.D)) moveVector.X += 1f;
                if (keyState.IsKeyDown(Keys.A)) moveVector.X -= 1f;

                if (keyState.IsKeyDown(Keys.G) && !previousState.IsKeyDown(Keys.G))
                {
                    ground.UpCube();
                    ground.GetVertexBuffer().SetData(ground.vertices);
                }
                if (keyState.IsKeyDown(Keys.LeftControl) && !keyState.IsKeyDown(Keys.LeftShift)) moveSpeed = 10f;
                else if (keyState.IsKeyDown(Keys.LeftShift) && !keyState.IsKeyDown(Keys.LeftControl)) moveSpeed = 240f;
                else if (!keyState.IsKeyDown(Keys.LeftControl) && !keyState.IsKeyDown(Keys.LeftShift)) moveSpeed = 120f;
                cameraPosition.Y -= jumpVelocity;
                if (keyState.IsKeyDown(Keys.Space) && !hasJumped)
                {
                    cameraPosition.Y += 5f;
                    jumpVelocity = -3f;
                    hasJumped = true;
                }
                if (hasJumped)
                {
                    float i = 1;
                    jumpVelocity += 0.15f * i;
                }
                try
                {
                    tall2 = ground.GetTriangle(cameraPosition);
                }
                catch { tall2 = 0; }
                if (!hasJumped)
                {
                    jumpVelocity = 0f;
                    cameraPosition.Y = tall + tall2;
                }
                if (cameraPosition.Y <= tall + tall2 + 0.0001f)
                    hasJumped = false;
                else hasJumped = true;
                if (updownRot > MathHelper.PiOver2) updownRot = MathHelper.PiOver2;
                else if (updownRot < -MathHelper.PiOver2) updownRot = -MathHelper.PiOver2;

                Vector3 norm = new Vector3(0, 0, 0);
                if (moveVector != norm) norm = Vector3.Normalize(moveVector);
                Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);//X
                Vector3 rotatedVector = Vector3.Transform(norm * amount, cameraRotation);
                cameraPosition += moveSpeed * new Vector3(rotatedVector.X, 0, rotatedVector.Z);

                cameraRotation = Matrix.CreateRotationZ(updownRot) * Matrix.CreateRotationY(leftrightRot);//Z
                rotatedVector = Vector3.Transform(norm * amount, cameraRotation);
                cameraPosition += moveSpeed * new Vector3(rotatedVector.X, 0, rotatedVector.Z);

                cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);

                Vector3 cameraOriginalTarget = new Vector3(0, 0, -1f);
                Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
                Vector3 cameraFinalTarget = cameraPosition + cameraRotatedTarget;

                Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
                Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

                viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraFinalTarget, cameraRotatedUpVector);

                base.Update(gameTime);
                previousState = keyState;
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            xyzEffect.Projection = projectionMatrix;
            xyzEffect.View = viewMatrix;
            xyzEffect.World = worldMatrix;
            ground.SetBasicEffectPMW(projectionMatrix, viewMatrix, worldMatrix);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.CullCounterClockwiseFace;
            //rasterizerState.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rasterizerState;
            // TODO: Add your drawing code here

            GraphicsDevice.SetVertexBuffer(ground.GetVertexBuffer());
            GraphicsDevice.Indices = ground.GetIndexBuffer();
            foreach (EffectPass pass in ground.GetBasicEffect().CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, ground.indsize);
            }

        }
    }
}
