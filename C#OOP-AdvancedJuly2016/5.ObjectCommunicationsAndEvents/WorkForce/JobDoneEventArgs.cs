namespace WorkForce
{
    using System;

    public class JobDoneEventArgs : EventArgs
    {
        private Job job;

        public JobDoneEventArgs(Job job)
        {
            this.Job = job;
        }

        public Job Job
        {
            get
            {
                return this.job;
            }
            private set
            {
                this.job = value;
            }
        }
    }
}
