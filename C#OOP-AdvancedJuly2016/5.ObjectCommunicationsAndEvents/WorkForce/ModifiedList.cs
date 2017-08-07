namespace WorkForce
{
    using System.Collections.Generic;

    public class ModifiedList : List<Job>
    {
        public void JobHandlerCompletion(object sender, JobDoneEventArgs e)
        {
            this.Remove(e.Job);
        }
    }
}
