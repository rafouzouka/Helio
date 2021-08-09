using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Layers
{
    public class LayerStack
    {
        private List<Layer> _layers;

        public LayerStack()
        {
            _layers = new List<Layer>();
        }

        public void PushLayer(Layer layer)
        {
            _layers.Add(layer);
        }

        public void PopLayer(Layer layer)
        {
            _layers.Remove(layer);
        }
    }
}
