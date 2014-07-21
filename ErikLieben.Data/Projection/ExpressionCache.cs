namespace ErikLieben.Data.Projection
{
    using System.Collections.Concurrent;
    using System.Linq.Expressions;

    public class ExpressionCacheDictionary
        : ConcurrentDictionary<string, Expression>, IExpressionCache
    {
    }
}
