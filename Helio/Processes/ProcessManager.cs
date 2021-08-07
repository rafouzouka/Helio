using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Processes
{
    public class ProcessManager
    {
        private List<Process> _processes;

        public ProcessManager()
        {
            _processes = new List<Process>();
        }

        public void UpdateProcesses(GameTime gameTime)
        {
            uint successCount = 0;
            uint failCount = 0;
            List<Process> processesToDelete = new List<Process>();
            List<Process> processesToAdd = new List<Process>();

            foreach (Process currentProcess in _processes)
            {
                if (currentProcess.GetState() == ProcessState.UNINITIALIZED)
                {
                    currentProcess.OnInit();
                }

                if (currentProcess.GetState() == ProcessState.RUNNING)
                {
                    currentProcess.OnUpdate(gameTime);
                }

                if (currentProcess.IsDead())
                {
                    switch (currentProcess.GetState())
                    {
                        case ProcessState.SUCCEEDED:
                            currentProcess.OnSuccess();

                            Process child = currentProcess.RemoveChild();
                            if (child != null)
                            {
                                processesToAdd.Add(child);
                            }
                            else
                            {
                                successCount++;
                            }
                            break;

                        case ProcessState.FAILED:
                            currentProcess.OnFail();
                            failCount++;
                            break;

                        case ProcessState.ABORTED:
                            currentProcess.OnAbort();
                            failCount++;
                            break;
                    }
                    processesToDelete.Add(currentProcess);
                }
            }
            
            foreach (Process process in processesToDelete)
            {
                _processes.Remove(process);
            }

            foreach (Process process in processesToAdd)
            {
                AttachProcess(process);
            }

            return;
        }

        public void AttachProcess(Process process)
        {
            _processes.Add(process);
        }

        public void AbortAllProcesses(bool immediate)
        {
            foreach (Process process in _processes)
            {
                if (process.IsAlive())
                {
                    process.SetState(ProcessState.ABORTED);
                    if (immediate)
                    {
                        process.OnAbort();
                        _processes.Remove(process);
                    }
                }
            }
        }

        public int GetProceesCount()
        {
            return _processes.Count;
        }

        private void ClearAllProcesses()
        {
            _processes.Clear();
        }
    }
}
