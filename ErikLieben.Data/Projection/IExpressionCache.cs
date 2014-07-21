namespace ErikLieben.Data.Projection
{
    using System.Linq.Expressions;

    public interface IExpressionCache
    {
        bool TryAdd(string key, Expression value);

        bool TryGetValue(string key, out Expression value);

        bool ContainsKey(string key);

        int Count
        {
            get;
        }

    }
}