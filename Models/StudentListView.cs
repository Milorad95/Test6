namespace Test6.Models
{
    public class StudentListView
    {
        public string searchFilter { get; set; }
        public IEnumerable<Student> Studenti { get; set; } 
    }
}
