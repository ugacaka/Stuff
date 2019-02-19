using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace platform_3d
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        Vector3 cameraPosition = new Vector3(0, 500, 0);
        Matrix projectionMatrix;
        Matrix viewMatrix;
        BasicEffect basicEffect;
        MouseState originalMouseState;
        VertexPositionColor[] triangleVertices, crvenaX, zelenaY, plavaZ;
        VertexBuffer vertexBuffer;
        VertexBuffer[] xyzBuffer;
        int _x = 100, _y = 100;
        int polje;
        const float rotationSpeed = 0.3f;
        float updownRot = -MathHelper.Pi / 10f;
        float leftrightRot = MathHelper.PiOver2;
        float moveSpeed = 120f;
        bool hasJumped = false;
        float jumpVelocity = 0;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1680;
            graphics.PreferredBackBufferHeight = 1050;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            Mouse.SetPosition((int)GraphicsDevice.Viewport.Width / 2, (int)GraphicsDevice.Viewport.Height / 2);
            originalMouseState = Mouse.GetState();
            polje = 6 * _x * _y;
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), GraphicsDevice.DisplayMode.AspectRatio, 1f, 100000f);

            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Alpha = 1f;
            basicEffect.VertexColorEnabled = true;
            basicEffect.LightingEnabled = false;

            triangleVertices = new VertexPositionColor[polje];
            crvenaX = new VertexPositionColor[2];
            zelenaY = new VertexPositionColor[2];
            plavaZ = new VertexPositionColor[2];
            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), polje, BufferUsage.WriteOnly);
            xyzBuffer = new VertexBuffer[3];
            for (int i = 0; i < 3; i++) xyzBuffer[i] = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 2, BufferUsage.WriteOnly);
            crvenaX[0] = new VertexPositionColor(new Vector3(100000, 0, 0), Color.Red);
            crvenaX[1] = new VertexPositionColor(new Vector3(-100000, 0, 0), Color.Red);
            zelenaY[0] = new VertexPositionColor(new Vector3(0, 100000, 0), Color.Green);
            zelenaY[1] = new VertexPositionColor(new Vector3(0, -100000, 0), Color.Green);
            plavaZ[0] = new VertexPositionColor(new Vector3(0, 0, 100000), Color.Blue);
            plavaZ[1] = new VertexPositionColor(new Vector3(0, 0, -100000), Color.Blue);
            xyzBuffer[0].SetData<VertexPositionColor>(crvenaX);
            xyzBuffer[1].SetData<VertexPositionColor>(zelenaY);
            xyzBuffer[2].SetData<VertexPositionColor>(plavaZ);
            Terrain();
        }
        protected void Terrain()
        {
            bool flip = true;
            int x = 0;
            for (int i = 0; i < _x; i++)
            {
                for (int j = 0; j < _y; j++)
                {
                    if (flip)
                    {
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(20 + i * 20 - 1000, 0, 0 + j * (20) - 1000), Color.Black);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(0 + i * 20 - 1000, 0, 0 + j * (20) - 1000), Color.Black);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(0 + i * 20 - 1000, 0, 20 + j * (20) - 1000), Color.Black);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(20 + i * 20 - 1000, 0, 0 + j * (20) - 1000), Color.Black);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(20 + i * 20 - 1000, 0, 20 + j * (20) - 1000), Color.Black);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(0 + i * 20 - 1000, 0, 20 + j * (20) - 1000), Color.Black);
                    }
                    else
                    {
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(20 + i * 20 - 1000, 0, 0 + j * (20) - 1000), Color.White);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(0 + i * 20 - 1000, 0, 0 + j * (20) - 1000), Color.White);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(0 + i * 20 - 1000, 0, 20 + j * (20) - 1000), Color.White);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(20 + i * 20 - 1000, 0, 0 + j * (20) - 1000), Color.White);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(20 + i * 20 - 1000, 0, 20 + j * (20) - 1000), Color.White);
                        triangleVertices[x++] = new VertexPositionColor(new Vector3(0 + i * 20 - 1000, 0, 20 + j * (20) - 1000), Color.White);

                    }
                    flip = !flip;
                }
                flip = !flip;
            }

            vertexBuffer.SetData<VertexPositionColor>(triangleVertices);
        }
        protected override void LoadContent()
        {
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                float amount = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
                MouseState currentMouseState = Mouse.GetState();
                if (currentMouseState != originalMouseState)
                {
                    float xDifference = currentMouseState.X - originalMouseState.X;
                    float yDifference = currentMouseState.Y - originalMouseState.Y;
                    leftrightRot -= rotationSpeed * xDifference * amount / 1.4f;
                    updownRot -= rotationSpeed * yDifference * amount / 1.4f;
                    Mouse.SetPosition((int)GraphicsDevice.Viewport.Width / 2, (int)GraphicsDevice.Viewport.Height / 2);
                }

                Vector3 moveVector = new Vector3(0, 0, 0);
                KeyboardState keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W)) moveVector.Z -= 1f;
                if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S)) moveVector.Z += 1f;
                if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D)) moveVector.X += 1f;
                if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A)) moveVector.X -= 1f;
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
                if (cameraPosition.Y <= 50) hasJumped = false;
                else hasJumped = true;
                if (!hasJumped)
                {
                    jumpVelocity = 0f;
                    cameraPosition.Y = 50;
                }
                if (keyState.IsKeyDown(Keys.Enter))
                {
                    cameraPosition.X = 0;
                    cameraPosition.Y = 500;
                    cameraPosition.Z = 0;
                }
                if (keyState.IsKeyDown(Keys.LeftControl) && !keyState.IsKeyDown(Keys.LeftShift)) moveSpeed = 10f;
                else if (keyState.IsKeyDown(Keys.LeftShift) && !keyState.IsKeyDown(Keys.LeftControl)) moveSpeed = 240f;
                else if(!keyState.IsKeyDown(Keys.LeftControl) && !keyState.IsKeyDown(Keys.LeftShift)) moveSpeed = 120f;

                if (updownRot > MathHelper.PiOver2) updownRot = MathHelper.PiOver2;
                else if (updownRot < -MathHelper.PiOver2) updownRot = -MathHelper.PiOver2;
                Vector3 norm=new Vector3(0,0,0);
                if (moveVector != norm) norm = Vector3.Normalize(moveVector);
                Matrix cameraRotation = Matrix.CreateRotationX(updownRot)*Matrix.CreateRotationY(leftrightRot);//X
                Vector3 rotatedVector = Vector3.Transform(norm * amount, cameraRotation);
                cameraPosition += moveSpeed * new Vector3(rotatedVector.X, 0, rotatedVector.Z);

                cameraRotation = Matrix.CreateRotationZ(updownRot)*Matrix.CreateRotationY(leftrightRot);//Z
                rotatedVector = Vector3.Transform(norm * amount, cameraRotation);
                cameraPosition += moveSpeed * new Vector3(rotatedVector.X, 0, rotatedVector.Z);
                //Debug.WriteLine("org:({0},{1},{2}) norm:({3},{4},{5})", moveVector.X, moveVector.Y, moveVector.Z, norm.X, norm.Y, norm.Z);
                Debug.WriteLine("X:{0} Y:{1} Z:{2}  degrees{3}", cameraPosition.X, cameraPosition.Y, cameraPosition.Z,MathHelper.ToDegrees(updownRot));
                UpdateViewMatrix();

                base.Update(gameTime);
            }
        }
        private void UpdateViewMatrix()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);

            Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = cameraPosition + cameraRotatedTarget;

            Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraFinalTarget, cameraRotatedUpVector);
        }
        protected override void Draw(GameTime gameTime)
        {
            basicEffect.Projection = projectionMatrix;
            basicEffect.View = viewMatrix;

            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.SetVertexBuffer(vertexBuffer);

            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rasterizerState;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, polje);
            }

            for (int i = 0; i < 3; i++)
            {
                GraphicsDevice.SetVertexBuffer(xyzBuffer[i]);
                foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    GraphicsDevice.DrawPrimitives(PrimitiveType.LineList, 0, polje);
                }
            }
            base.Draw(gameTime);
        }
    }
}