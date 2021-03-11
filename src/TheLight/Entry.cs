// create models for pulling data from database

namespace XamarinFirebase.Model
{
    public class Person 
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
    }
    public class Program
    {
        public int ProgramID;// { get; set; }
        public string Title;// { get; set; }
        public string Times;// { get; set; }
        public string Days;// { get; set; }
    }
}