using Content.IntegrationTests.NUnit.Operators;
using Content.Shared.Chemistry.Reagent;
using NUnit.Framework.Constraints;

namespace Content.IntegrationTests.NUnit.Constraints.Solutions;

public static class SolutionConstraintExtensions
{
    extension(Has)
    {
        public static ResolvableConstraintExpression Reagent(ReagentId reagent)
        {
            return new ConstraintExpression().Reagent(reagent);
        }
    }

    extension(ConstraintExpression expr)
    {
        public ResolvableConstraintExpression Reagent(ReagentId reagent)
        {
            return expr.Append(new ReagentOperator(reagent));
        }
    }
}
