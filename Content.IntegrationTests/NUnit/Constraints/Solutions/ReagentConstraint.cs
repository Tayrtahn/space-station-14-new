#nullable enable
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.FixedPoint;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace Content.IntegrationTests.NUnit.Constraints.Solutions;

public sealed class ReagentConstraint(ReagentId reagent, IConstraint baseConstraint)
    : PrefixConstraint(baseConstraint, $"reagent {reagent}")
{
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        if (actual is not Solution solution)
        {
            throw new ArgumentException($"Expected {nameof(Solution)} but got {typeof(TActual)}");
        }

        if (!solution.TryGetReagentQuantity(reagent, out var quantity))
            return new ConstraintResult(this, actual, ConstraintStatus.Failure);

        var baseResult = Reflect.InvokeApplyTo(constraint: baseConstraint, typeof(FixedPoint2), quantity);
        return new ConstraintResult(this, baseResult.ActualValue, baseResult.Status);
    }
}
