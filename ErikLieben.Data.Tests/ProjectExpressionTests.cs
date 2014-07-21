namespace ErikLieben.Toolkit.Tests
{

    using ErikLieben.Data.Projection;
    using ErikLieben.Tests.ProjectExpression.To;
    using Xunit;

    public class ProjectExpressionTests
    {

        public class To
        {
            [Fact]
            public void Must_query_fields_of_projected_target()
            {
                // Arrange
                var context = new EmployeeContext();

                // Act
                var result = context.People.Project().To<Manager>();

                // Assert   
                Assert.Equal(
                    "SELECT 1 AS [C1], [Extent1].[FirstName] AS [FirstName], [Extent1].[LastName] AS [LastName] FROM [dbo].[People] AS [Extent1]",
                    Query.FixMarkupOf(result.ToString()));
            }

            [Fact]
            public void Must_ignore_non_database_fields_of_projected_target()
            {
                // Arrange
                var context = new EmployeeContext();

                // Act
                var result = context.People.Project().To<FiredManager>();

                // Assert   
                Assert.Equal(
                    "SELECT 1 AS [C1], [Extent1].[FirstName] AS [FirstName], [Extent1].[LastName] AS [LastName] FROM [dbo].[People] AS [Extent1]",
                    Query.FixMarkupOf(result.ToString()));
            }

            [Fact]
            public void Must_use_mapping_path_attribute_if_set_to_get_deep_property()
            {
                // Arrange
                var context = new EmployeeContext();

                // Act
                var result = context.People.Project().To<RegionManager>();

                // Assert
                Assert.Equal(
                    "SELECT [Extent1].[RegionId] AS [RegionId], [Extent2].[Name] AS [Name], [Extent1].[FirstName] AS [FirstName], [Extent1].[LastName] AS [LastName] " +
                    "FROM [dbo].[People] AS [Extent1] " +
                    "INNER JOIN [dbo].[Regions] AS [Extent2] ON [Extent1].[RegionId] = [Extent2].[Id]",
                    Query.FixMarkupOf(result.ToString()));
            }

            [Fact]
            public void Must_still_map_to_target_even_if_mapping_path_property_is_not_found()
            {
                // Arrange
                var context = new EmployeeContext();

                // Act
                var result = context.People.Project().To<PromotedManager>();

                // Assert   
                Assert.Equal(
                    "SELECT 1 AS [C1], [Extent1].[FirstName] AS [FirstName], [Extent1].[LastName] AS [LastName] FROM [dbo].[People] AS [Extent1]",
                    Query.FixMarkupOf(result.ToString()));

            }

            [Fact]
            public void Must_use_cached_expressions()
            {
                // Arrange
                var context = new EmployeeContext();
                var cache = new ExpressionCacheDictionary();
                var sut = new ProjectionExpression<Person>(context.People, cache);

                // Act
                sut.To<Manager>();
                sut.To<Manager>();

                // Assert
                Assert.True(cache.Count == 1);
            }
        }
    }
}
