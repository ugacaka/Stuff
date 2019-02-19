using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _3D
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        
        Vector3 cameraPosition = new Vector3(0, 50, 0);
        Matrix projectionMatrix;
        Matrix viewMatrix;
        BasicEffect basicEffect;
        MouseState originalMouseState;
        VertexPositionColor[] triangleVertices,crvenaX,zelenaY,plavaZ;
        VertexBuffer vertexBuffer;
        VertexBuffer[] xyzBuffer;
        int _x = 100,_y=100;
        int polje;
        const float rotationSpeed = 0.3f;
        float updownRot = -MathHelper.Pi / 10.0f;
        float leftrightRot = MathHelper.PiOver2;
        const float moveSpeed = 150.0f;
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
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f),GraphicsDevice.DisplayMode.AspectRatio,1f, 100000f);
            
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
            for (int i = 0; i < 3; i++)  xyzBuffer[i] = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 2, BufferUsage.WriteOnly);
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
            int x = 0;
            for (int i = 0; i < _x; i++)
                for (int j = 0; j < _y; j++)
                {
                    triangleVertices[x++] = new VertexPositionColor(new Vector3(20 + i * 20 - 1000, -1000, 0 + j * (20) - 1000), Color.Red);
                    triangleVertices[x++] = new VertexPositionColor(new Vector3(0 + i * 20 - 1000, -1000, 0 + j * (20) - 1000), Color.Blue);
                    triangleVertices[x++] = new VertexPositionColor(new Vector3(0 + i * 20 - 1000, -1000, 20 + j * (20) - 1000), Color.Green);
                    triangleVertices[x++] = new VertexPositionColor(new Vector3(20 + i * 20 - 1000, -1000, 0 + j * (20) - 1000), Color.Green);
                    triangleVertices[x++] = new VertexPositionColor(new Vector3(20 + i * 20 - 1000, -1000, 20 + j * (20) - 1000), Color.Yellow);
                    triangleVertices[x++] = new VertexPositionColor(new Vector3(0 + i * 20 - 1000, -1000, 20 + j * (20) - 1000), Color.Green);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float amount = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState != originalMouseState)
            {
                float xDifference = currentMouseState.X - originalMouseState.X;
                float yDifference = currentMouseState.Y - originalMouseState.Y;
                leftrightRot -= rotationSpeed * xDifference * amount;
                updownRot -= rotationSpeed * yDifference * amount;
                Mouse.SetPosition((int)GraphicsDevice.Viewport.Width / 2, (int)GraphicsDevice.Viewport.Height / 2);
                UpdateViewMatrix();
            }

            Vector3 moveVector = new Vector3(0, 0, 0);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                moveVector += new Vector3(0, 0, -1);
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                moveVector += new Vector3(0, 0, 1);
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                moveVector += new Vector3(1, 0, 0);
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                moveVector += new Vector3(-1, 0, 0);
            if (keyState.IsKeyDown(Keys.Space))
                moveVector += new Vector3(0, 1, 0);
            if (keyState.IsKeyDown(Keys.C))
                moveVector += new Vector3(0, -1, 0);

            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);
            Vector3 rotatedVector = Vector3.Transform(moveVector * amount, cameraRotation);
            cameraPosition += moveSpeed * rotatedVector;
            UpdateViewMatrix();

            base.Update(gameTime);
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