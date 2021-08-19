using Helio.Core;
using Helio.Graphics;
using Helio.Inputs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Helio.UI
{
    public class Column : UIElement
    {
        private List<UIElement> _childs;

        private List<Vector2> _sizes;
        private Vector2 _totalSize;

        private Vector2 _currentSize;
        private Vector2 _currentPosition;
        private float _widestChildSize;

        private MainAxisAlignement _mainAxisAlignement;
        private CrossAxisAlignement _crossAxisAlignement;

        public Column(List<UIElement> childs, MainAxisAlignement mainAxisAlignement = MainAxisAlignement.Start, CrossAxisAlignement crossAxisAlignement = CrossAxisAlignement.Center)
        {
            _childs = childs;

            _totalSize = Vector2.Zero;
            _sizes = new List<Vector2>();

            _currentSize = Vector2.Zero;
            _currentPosition = Vector2.Zero;

            _mainAxisAlignement = mainAxisAlignement;
            _crossAxisAlignement = crossAxisAlignement;
            _widestChildSize = 0f;
        }

        public Vector2 SetConstraints(Constraints constraints)
        {
            foreach (UIElement child in _childs)
            {
                Vector2 size = child.SetConstraints(new Constraints(0f, constraints.maxWidth, 0f, constraints.maxHeight));

                Debug.WriteLine($"size: {size.X} {size.Y}");

                if (size.X > _widestChildSize)
                {
                    _widestChildSize = size.X;
                }

                _sizes.Add(size);
                _totalSize += size;
            }

            _currentSize.Y = constraints.maxHeight;
            _widestChildSize = Utils.Clamp(_widestChildSize, constraints.minWidth, constraints.maxWidth);
            _currentSize.X = _widestChildSize; 

            return _currentSize;
        }

        public void SetPosition(Vector2 position)
        {
            _currentPosition = position;

            float sizeY = 0f;
            for (int i = 0; i < _childs.Count; i++)
            {
                Vector2 childPosition = Vector2.Zero;

                switch (_crossAxisAlignement)
                {
                    case CrossAxisAlignement.Start:
                        childPosition.X = position.X;
                        break;

                    case CrossAxisAlignement.Center:
                        childPosition.X = ((_widestChildSize - _sizes[i].X) / 2) + position.X;
                        break;

                    case CrossAxisAlignement.End:
                        childPosition.X = (_widestChildSize - _sizes[i].X) + position.X;
                        break;

                    default:
                        throw new Exception("All enums must be defined");
                }

                switch (_mainAxisAlignement)
                {
                    case MainAxisAlignement.Start:
                        childPosition.Y = sizeY;
                        break;

                    case MainAxisAlignement.Center:
                        childPosition.Y = sizeY + ((_currentSize.Y - _totalSize.Y) / 2);
                        break;

                    case MainAxisAlignement.End:
                        childPosition.Y = sizeY + ((_currentSize.Y - _totalSize.Y));
                        break;

                    default:
                        throw new Exception("All enums must be defined");
                }

                _childs[i].SetPosition(childPosition);
                sizeY += _sizes[i].Y;
            }
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            foreach (UIElement child in _childs)
            {
                child.Draw(gameTime, renderer);
            }
            renderer.DrawRect(new Rectangle(_currentPosition.ToPoint(), _currentSize.ToPoint()), Color.Orange);
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
