namespace ErikLieben.Tests.ProjectExpression.To
{
    using Data.Projection;

    public class JuniorManager : Manager
    {
        [MappingPath(Path = "Region.FirstName")]
        public string ExpelledFrom { get; set; }
    }
}