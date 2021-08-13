using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace Helio.Graphics
{
    public class ShapeBatch
    {
        private GraphicsDevice _graphicsDevice;
        private BasicEffect _basicEffect;
        private VertexBuffer _vertexBuffer;
        private IndexBuffer _indexBuffer;

        public ShapeBatch(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _vertexBuffer = new VertexBuffer(_graphicsDevice, typeof(VertexPositionColor), 100, BufferUsage.WriteOnly);
            _indexBuffer = new IndexBuffer(_graphicsDevice, typeof(short), 100, BufferUsage.WriteOnly);
        }

        public void Begin()
        {
            if (_basicEffect == null)
            {
                _basicEffect = new BasicEffect(_graphicsDevice)
                {
                    World = Matrix.Identity,
                    View = Matrix.Identity,
                    Projection = Matrix.CreateOrthographicOffCenter(0, 1280, 720, 0, 0f, 1f),
                    VertexColorEnabled = true,
                };
            }
        }

        public void DrawRect(Rectangle rect, Color color)
        {
            int top = rect.Y;
            int bottom = rect.Y + rect.Height;
            int left = rect.X;
            int right = rect.X + rect.Width;

            VertexPositionColor[] vertices = new VertexPositionColor[4];
            vertices[0] = new VertexPositionColor(new Vector3(left, top, 0.0f), color);
            vertices[1] = new VertexPositionColor(new Vector3(right, top, 0.0f), color);
            vertices[2] = new VertexPositionColor(new Vector3(right, bottom, 0.0f), color);
            vertices[3] = new VertexPositionColor(new Vector3(left, bottom, 0.0f), color);

            short[] indices = new short[6];
            indices[0] = 0; 
            indices[1] = 1; 
            indices[2] = 2; 
            indices[3] = 0; 
            indices[4] = 2; 
            indices[5] = 3;

            _vertexBuffer.SetData<VertexPositionColor>(vertices);
            _indexBuffer.SetData(indices);
        }

        public void End()
        {
            _graphicsDevice.SetVertexBuffer(_vertexBuffer);
            _graphicsDevice.Indices = _indexBuffer;
            _graphicsDevice.RasterizerState = RasterizerState.CullNone;

            foreach (EffectPass pass in _basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                _graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 6);
            }

            //_vertexBuffer.
        }
    }
}
