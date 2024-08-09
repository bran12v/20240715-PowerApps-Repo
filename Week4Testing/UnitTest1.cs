using Week4Programming.Encounters;
using Week4Programming.Entities;

namespace Week4Testing
{
    [TestFixture]
    public class Tests
    {
        public Player p; 

        [SetUp] // init
        public void Setup() // first
        {
            p = new Player("test", 10, 1, 0.5, 10, "Striker", new Weapon(99.0, "Sword", 1, "Common", 10), 
                false, 10, new List<string>(){ "loot" }); //every single test this will run
        }

        [TearDown] // garbage collection
        public void TearDown() // last
        {
            // end of every test
        }

        [Test]
        public void TestPlayerWeaponRepair()
        {
            Townsperson tPerson = new Townsperson(new List<string>() { "dagger" },
                1, 100, p, "townTest", 10, 1, 1, 1);
            Assert.IsTrue(tPerson.repair(p, p.Weapon, 10)
                .Equals("Your weapon has been repaired!"));
            Assert.That(p.Gold == 0);
            Assert.That(p.Weapon.Durability == 100.0);
        }

        [Test]
        public void TestDetermineRewardsInDungeonEncounter()
        {
            DungeonEncounter DE = new DungeonEncounter(1, true, "sdasdad",
                p, new Character[] { p }, Difficulty.Easy, 1, 1);
            // (((1 + 1) * 1.5) * 0.5) * 50 = 75
            Assert.That(DE.determineRewards() == 75);
        }
    }
}