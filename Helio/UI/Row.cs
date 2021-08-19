using Helio.Core;
using Helio.Graphics;
using Helio.Inputs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Helio.UI
{
    public class Row : UIElement
    {
        private List<UIElement> _childs;
        private List<Vector2> _sizes;
        
        private Vector2 _totalSize;
        private float _highestChildSize;
        private Vector2 _currentSize;
        private Vector2 _currentPosition;

        private MainAxisAlignement _mainAxisAlignement;
        private CrossAxisAlignement _crossAxisAlignement;

        public Row(List<UIElement> childs, MainAxisAlignement mainAxisAlignement = MainAxisAlignement.Start, CrossAxisAlignement crossAxisAlignement = CrossAxisAlignement.Center)
        {
            _childs = childs;
            _sizes = new List<Vector2>();

            _mainAxisAlignement = mainAxisAlignement;
            _crossAxisAlignement = crossAxisAlignement;

            _currentSize = Vector2.Zero;
            _currentPosition = Vector2.Zero;
            _totalSize = Vector2.Zero;
            _highestChildSize = 0f;
        }

        public Vector2 SetConstraints(Constraints constraints)
        {
            foreach (UIElement child in _childs)
            {
                Vector2 size = child.SetConstraints(new Constraints(0f, constraints.maxWidth, 0f, constraints.maxHeight));

                if (size.Y > _highestChildSize)
                {
                    _highestChildSize = size.Y;
                }

                _sizes.Add(size);
                _totalSize += size;
            }

            _currentSize.X = constraints.maxWidth;
            _highestChildSize = Utils.Clamp(_highestChildSize, constraints.minHeight, constraints.maxHeight);
            _currentSize.Y = _highestChildSize;


            return _currentSize;
        }

        public void SetPosition(Vector2 position)
        {
            _currentPosition = position;

            float sizeX = 0f;
            for (int i = 0; i < _childs.Count; i++)
            {
                Vector2 childPosition = Vector2.Zero;

                switch (_crossAxisAlignement)
                {
                    case CrossAxisAlignement.Start:
                        childPosition.Y = position.Y; 
                        break;

                    case CrossAxisAlignement.Center:
                        childPosition.Y = ((_highestChildSize - _sizes[i].Y) / 2) + position.Y;
                        break;

                    case CrossAxisAlignement.End:
                        childPosition.Y = (_highestChildSize - _sizes[i].Y) + position.Y;
                        break;

                    default:
                        throw new Exception("All enums must be defined");
                }

                switch (_mainAxisAlignement)
                {
                    case MainAxisAlignement.Start:
                        childPosition.X = sizeX;
                        break;

                    case MainAxisAlignement.Center:
                        childPosition.X = sizeX + ((_currentSize.X - _totalSize.X) / 2);
                        break;

                    case MainAxisAlignement.End:
                        childPosition.X = sizeX + ((_currentSize.X - _totalSize.X));
                        break;

                    default:
                        throw new Exception("All enums must be defined");
                }

                _childs[i].SetPosition(childPosition);
                sizeX += _sizes[i].X;
            }
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            foreach (UIElement child in _childs)
            {
                child.Draw(gameTime, renderer);
            }
            renderer.DrawRect(new Rectangle(_currentPosition.ToPoint(), _currentSize.ToPoint()), Color.Pink);
        }

        public bool OnInput(InputEvent input)
        {
            bool keepTraverse = true;
            foreach (UIElement child in _childs)
            {
                if (child.OnInput(input) == false)
                {
                    keepTraverse = false;
                }
            }

            return keepTraverse;
        }
    }
}
