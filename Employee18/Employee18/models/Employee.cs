namespace Employee18.models
{
    public class Employee
    {
        public  Guid Id { get; set; }
        public string Name { get; set; } =string.Empty;

        public int Age { get; set; }

        public string Email_id { get; set; } = string.Empty;

        public string address { get; set; } = string.Empty;

        public long phone { get; set; } 


    }
}
