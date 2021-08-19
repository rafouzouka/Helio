using System.Collections.Generic;

namespace Helio.Inputs
{
    public interface IControllerInput
    {
        void PollEvents(List<InputEvent> inputEvents);
    }
}
