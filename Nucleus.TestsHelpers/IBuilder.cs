namespace Nucleus.TestsHelpers;

public interface IBuilder<out TEntity>
{
    TEntity Build();

    IEnumerable<TEntity> BuildMany(int min = 2, int max = 5)
    {
        var result = new List<TEntity>();
        for (var i = 0; i < AnyValue.Random(min, max); i++)
        {
            result.Add(Build());
        }
        return result;
    }
}