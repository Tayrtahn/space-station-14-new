using Content.IntegrationTests.Fixtures;
using Content.IntegrationTests.NUnit.Constraints.Solutions;
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.FixedPoint;
using Robust.Shared.Prototypes;

namespace Content.IntegrationTests.Tests.GameTestTests;

public sealed class SolutionConstraintTests : GameTest
{
    private static readonly ProtoId<ReagentPrototype> TestReagent = "Water";
    private static readonly ProtoId<ReagentPrototype> OtherReagent = "Blood";

    [Test]
    [TestOf(typeof(ReagentExistsConstraint))]
    public void ReagentExists()
    {
        var sol = new Solution(TestReagent, 10);

        Assert.That(sol, Has.Reagent((ReagentId)TestReagent));
    }

    [Test]
    [TestOf(typeof(ReagentExistsConstraint))]
    public void ReagentNotExists()
    {
        var sol = new Solution(TestReagent, 10);

        Assert.That(sol, Has.No.Reagent((ReagentId)OtherReagent));
    }

    [Test]
    [TestOf(typeof(ReagentConstraint))]
    public void ReagentQuantity()
    {
        var sol = new Solution(TestReagent, 10);

        Assert.That(sol, Has.Reagent((ReagentId)TestReagent).GreaterThan(FixedPoint2.New(5)));
    }
}
