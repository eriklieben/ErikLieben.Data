namespace ErikLieben.Tests.ProjectExpression.To
{
    public class Person 
    {
        public int Id
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public int RegionId
        {
            get;
            set;
        }

        public virtual Region Region
        {
            get;
            set;
        }
    }
}
