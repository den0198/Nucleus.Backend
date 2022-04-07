using System.Linq.Expressions;

namespace TestsHelpers.Builders;

public abstract class CoreBuilder<TEntity>
{
    protected TEntity Entity { get; set; }

    public TEntity Build() => Entity;

    public CoreBuilder<TEntity> With<T>(Expression<Func<TEntity, T>> field, object value)
    {
        var propertyName = this.propertyName(field);
        var property = Entity.GetType().GetProperty(propertyName);
        property.SetValue(Entity, value);
        return this;
    }

    private string propertyName<TObject, TResult>(Expression<Func<TObject, TResult>> property)
    {
        var lambda = (LambdaExpression)property;
        var memberExpression = (MemberExpression)(lambda.Body is not UnaryExpression body ? lambda.Body : body.Operand);

        return propertyFullName(memberExpression);
    }

    private string propertyFullName(MemberExpression expression)
    {
        if (expression.NodeType != ExpressionType.MemberAccess)
            return string.Empty;

        if (expression.Expression is not MemberExpression subExpression)
            return expression.Member.Name;

        return $"{propertyFullName(subExpression)}.{expression.Member.Name}";
    }
}