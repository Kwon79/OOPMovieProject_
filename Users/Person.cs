namespace Users
{
    public abstract class Person
    {
        private string name;
        private string email;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Person(string name, string email)
        {
            this.name = name;
            this.email = email;
        }

        public abstract string GetInfo();

        public virtual void Introduce()
        {
            Console.WriteLine($"안녕하세요, {Name}입니다.");
        }
    }
}