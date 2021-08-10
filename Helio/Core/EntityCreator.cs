using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Core
{
    public static class EntityCreator
    {
        private static ulong _lastEntityId = 0;

        public static Entity Create()
        {
            Entity e = new Entity(_lastEntityId);
            _lastEntityId++;
            return e;
        }
    }
}
