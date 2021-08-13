using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.UI
{
    public struct Constraints
    {
        public float minWidth;
        public float maxWidth;

        public float minHeight;
        public float maxHeight;

        public Constraints(float minWidth, float maxWidth, float minHeight, float maxHeight)
        {
            this.minWidth = minWidth;
            this.maxWidth = maxWidth;

            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
        }
    }
}
