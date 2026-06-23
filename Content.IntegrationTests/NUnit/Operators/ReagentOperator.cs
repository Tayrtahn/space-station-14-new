using Content.IntegrationTests.NUnit.Constraints.Solutions;
using Content.Shared.Chemistry.Reagent;
using NUnit.Framework.Constraints;

namespace Content.IntegrationTests.NUnit.Operators;

public sealed class ReagentOperator(ReagentId reagent) : SelfResolvingOperator
{
    private readonly ReagentId _reagent = reagent;

    public override void Reduce(ConstraintBuilder.ConstraintStack stack)
    {
        if (RightContext is null or BinaryOperator)
            stack.Push(new ReagentExistsConstraint(_reagent));
        else
            stack.Push(new ReagentConstraint(_reagent, stack.Pop()));
    }
}
