namespace ErikLieben.Tests.ProjectExpression.To
{
    using Data.Projection;

    public class RegionManager : Manager
    {
        [MappingPath(Path="Region.Name")]
        public string RegionName
        {
            get;
            set;
        }
    }
}
