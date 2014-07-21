namespace ErikLieben.Tests.ProjectExpression.To
{
    using Data.Projection;

    public class PromotedManager : Manager
    {
        [MappingPath(Path = "Region.PromotionName")]
        public string PromotedToRegion
        {
            get;
            set;
        }
    }
}