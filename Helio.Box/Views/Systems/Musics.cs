using Helio.Audio;
using Helio.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Helio.Box.Systems
{
    class Musics : MixerSystem
    {
        private Song _chant;

        public override void Init()
        {
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _chant = contentManager.Load<Song>("musics/chant");
        }

        public void RequestPlayerJump(Event ev)
        {
            PlayMusic(_chant);
        }
    }
}
