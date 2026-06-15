#nullable enable
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.Reagent;
using NUnit.Framework.Constraints;

namespace Content.IntegrationTests.NUnit.Constraints;

public sealed class ReagentConstraint(ReagentId reagent) : Constraint
{
    public override string Description => $"contains reagent {reagent}";

    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        if (actual is not Solution solution)
        {
            throw new ArgumentException($"Expected {nameof(Solution)} but got {typeof(TActual)}");
        }

        return new ConstraintResult(this, actual, solution.ContainsReagent(reagent));
    }
}
