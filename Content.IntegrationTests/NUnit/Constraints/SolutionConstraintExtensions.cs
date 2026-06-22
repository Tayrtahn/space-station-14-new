using Content.Shared.Chemistry.Reagent;
using NUnit.Framework.Constraints;

namespace Content.IntegrationTests.NUnit.Constraints;

public static class SolutionConstraintExtensions
{
    extension(Contains)
    {
        public static ReagentConstraint Reagent(ReagentId reagent)
        {
            return new ConstraintExpression().Reagent(reagent);
        }
    }

    extension(ConstraintExpression expr)
    {
        public ReagentConstraint Reagent(ReagentId reagent)
        {
            return expr.Append(new ReagentConstraint(reagent));
        }
    }
}
