namespace Academits.Dorosh.LambdaTask
{
    public class Person
    {
        private string _name;

        private int _age;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == null)
                {
                    _name = "";
                }
                else
                {
                    _name = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0)
                {
                    _age = 0;
                }
                else
                {
                    _age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} ({Age})";
        }
    }
}