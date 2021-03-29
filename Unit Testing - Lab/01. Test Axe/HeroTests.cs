using FakeAxeAndDummy;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private FakeWeapon fakeWeapon;
    private FakeDummy fakeDummy;
    private Hero hero;
    [SetUp]
    public void SetUp()
    {
        fakeWeapon = new FakeWeapon();
        fakeDummy = new FakeDummy();
    }
    [Test]
    public void When_TargetIsDeadHero_ShouldReceiveXP()
    {
        Mock<ITarget> target = new Mock<ITarget>();
        target.Setup(w => w.Health).Returns(0);
        target.Setup(t => t.IsDead()).Returns(true);
        target.Setup(t => t.GiveExperience()).Returns(15);
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        weapon.Setup(w => w.AttackPoints).Returns(10);
        weapon.Setup(w => w.DurabilityPoints).Returns(20);

        hero = new Hero("trix", weapon.Object);
        hero.Attack(target.Object);
        Assert.AreEqual(15, hero.Experience);

    }
}