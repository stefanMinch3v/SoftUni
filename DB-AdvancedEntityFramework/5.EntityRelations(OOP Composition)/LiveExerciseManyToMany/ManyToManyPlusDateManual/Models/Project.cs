namespace ManyToManyPlusDateManual.Models
{
    using System.Collections.Generic;

    public class Project
    {
        public Project()
        {
            this.ProjectEmployees = new HashSet<ProjectEmployees>();
        }

        public int ProjectId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProjectEmployees> ProjectEmployees { get; set; }
    }
}
