using Microsoft.Xna.Framework;

namespace Helio.Processes
{
    public enum ProcessState
    {
        UNINITIALIZED = 0,
        REMOVED,
        RUNNING,
        PAUSED,
        SUCCEEDED,
        FAILED,
        ABORTED,
    };

    public abstract class Process
    {
        private ProcessState _state;
        private Process _child;

        public Process()
        {
            _state = ProcessState.UNINITIALIZED;
            _child = null;
        }

        public virtual void OnInit() { _state = ProcessState.RUNNING; }

        public abstract void OnUpdate(GameTime gameTime);

        public virtual void OnSuccess() { }

        public virtual void OnFail() { }

        public virtual void OnAbort() { }

        public void SetState(ProcessState state) { _state = state;  }

        public void Succeed()
        {
            _state = ProcessState.SUCCEEDED;
        }

        public void Fail()
        {
            _state = ProcessState.FAILED;
        }

        public void Pause()
        {
            if (_state == ProcessState.RUNNING)
            {
                _state = ProcessState.PAUSED;
            }
        }

        public void UnPause()
        {
            if (_state == ProcessState.PAUSED)
            {
                _state = ProcessState.RUNNING;
            }
        }

        public ProcessState GetState() { return _state; }

        public bool IsAlive() { return (_state ==  ProcessState.RUNNING || _state == ProcessState.PAUSED); }

        public bool IsDead() { return (_state == ProcessState.SUCCEEDED || _state == ProcessState.FAILED || _state == ProcessState.ABORTED); }

        public bool IsRemoved() { return (_state == ProcessState.REMOVED); }

        public bool IsPaused() { return _state == ProcessState.PAUSED; }

        public void AttachChild(Process child)
        {
            if (_child != null)
            {
                _child.AttachChild(child);
            }
            else
            {
                _child = child;
            }
        }

        public Process RemoveChild()
        {
            if (_child != null)
            {
                return _child;
            }
            return null;
        }

        public Process PeekChild() { return _child; }
    }
}
