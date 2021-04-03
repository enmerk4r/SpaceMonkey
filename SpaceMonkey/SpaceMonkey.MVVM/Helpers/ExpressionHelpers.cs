using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.MVVM.Helpers
{
    public static class ExpressionHelpers
    {
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            // converts a lambda () => some.Property to some.Property
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            // Get property info so that we could set it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // Set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
