namespace EventExample
{
    using System;

    public class Student
    {
        public string Name { get; set; }

        public void AttendClass(Teacher teacher)
        {
            teacher.StartTalking += this.TeacherStartTalking;
        }

        private void TeacherStartTalking(object sender, EventArgs e)
        {
            var teacherName = (sender as Teacher).Name;

            var args = (TeacherEventArgs)e;

            Console.WriteLine(this.Name + " is listening to " + teacherName + " in class " + args.ClassName);
        }
    }
}
