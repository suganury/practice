using System.Threading.Tasks;
using NUnit.Framework;

namespace AttributesTest
{
    [TestFixture]
    public class Tests {
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }

    
    [TestFixture(typeof(string))]
    public class Tests<T>
    {
        [Test]
        public void TypeTest()
        {
            object obj = DummyTarget.getAnonymousObject();
            Assert.IsInstanceOf<T>(obj);
        }
    }

    
    [TestFixture("MBr", "マリオ", "ピーチ", "クッパ")]
    [TestFixture("LoZ", "リンク", "ゼルダ", "ガノン")]
    [TestFixture("Pok", "サトシ", "カスミ", "シゲル")]
    public class ParamTestFixture
    {
        NintendoGameCharacter NCharacter;
        string ExpectHero;
        string ExpectHeroine;
        string ExpectRival;

        public ParamTestFixture(string title, string hero, string heroine, string rival) {
            this.NCharacter = DummyTarget.getNintendoGameCharacter(title);
            this.ExpectHero = hero;
            this.ExpectHeroine = heroine;
            this.ExpectRival = rival;
        }
        
        [Test]
        public void NintendoHeroTest()
        {
            Assert.AreEqual(this.ExpectHero, NCharacter.Hero);
        }
        
        [Test]
        public void NintendoHeroineTest()
        {
            Assert.AreEqual(this.ExpectHeroine, NCharacter.Heroine);
        }
        
        [Test]
        public void NintendoRivalTest()
        {
            Assert.AreEqual(this.ExpectRival, NCharacter.Rival);
        }
    }

    [TestFixtureSource("ParamSource")]
    public class ParamTestFixtureSource
    {
        static object[] ParamSource =
        {
            new string[] {"MBr", "マリオ", "ピーチ", "クッパ"},
            new string[] {"LoZ", "リンク", "ゼルダ", "ガノン"},
            new string[] {"Pok", "サトシ", "カスミ", "シゲル"},
        };

        NintendoGameCharacter NCharacter;
        string ExpectHero;
        string ExpectHeroine;
        string ExpectRival;

        public ParamTestFixtureSource(string title, string hero, string heroine, string rival) {
            this.NCharacter = DummyTarget.getNintendoGameCharacter(title);
            this.ExpectHero = hero;
            this.ExpectHeroine = heroine;
            this.ExpectRival = rival;
        }
        
        [Test]
        public void NintendoHeroTest()
        {
            Assert.AreEqual(this.ExpectHero, NCharacter.Hero);
        }
        
        [Test]
        public void NintendoHeroineTest()
        {
            Assert.AreEqual(this.ExpectHeroine, NCharacter.Heroine);
        }
        
        [Test]
        public void NintendoRivalTest()
        {
            Assert.AreEqual(this.ExpectRival, NCharacter.Rival);
        }
    }


    class ParamWarehouse {
        static object[] ParamSource =
        {
            new string[] {"MBr", "マリオ", "ピーチ", "クッパ"},
            new string[] {"LoZ", "リンク", "ゼルダ", "ガノン"},
            new string[] {"Pok", "サトシ", "カスミ", "シゲル"},
        };
    }

    [TestFixtureSource(typeof(ParamWarehouse), "ParamSource")]
    public class ParamTestFixtureSource2
    {
        NintendoGameCharacter NCharacter;
        string ExpectHero;
        string ExpectHeroine;
        string ExpectRival;

        public ParamTestFixtureSource2(string title, string hero, string heroine, string rival) {
            this.NCharacter = DummyTarget.getNintendoGameCharacter(title);
            this.ExpectHero = hero;
            this.ExpectHeroine = heroine;
            this.ExpectRival = rival;
        }
        
        [Test]
        public void NintendoHeroTest()
        {
            Assert.AreEqual(this.ExpectHero, NCharacter.Hero);
        }
        
        [Test]
        public void NintendoHeroineTest()
        {
            Assert.AreEqual(this.ExpectHeroine, NCharacter.Heroine);
        }
        
        [Test]
        public void NintendoRivalTest()
        {
            Assert.AreEqual(this.ExpectRival, NCharacter.Rival);
        }
    }

    public class TestTest {

        [Test]
        public void MarioBrosHeroTest()
        {
            string TargetGame = "MBr";
            string ExpectHero = "マリオ";

            Assert.AreEqual(ExpectHero, DummyTarget.getNintendoGameCharacter(TargetGame).Hero);
        }
        
        [Test(Description = "ポケモン主人公の妥当性をテストします")]
        public void PokemonHeroTest()
        {
            string TargetGame = "Pok";
            string ExpectHero = "サトシ";

            Assert.AreEqual(ExpectHero, DummyTarget.getNintendoGameCharacter(TargetGame).Hero);
        }
        
        [Test(ExpectedResult = "リンク")]
        public string ZeldaHeroTest()
        {
            string TargetGame = "LoZ";

            return DummyTarget.getNintendoGameCharacter(TargetGame).Hero;
        }

        
        [Test(ExpectedResult = "リンク")]
        public async Task<string> ZeldaHeroTestAsync()
        {
            string TargetGame = "LoZ";
            string hero = await DummyTarget.getNintendoGameCharacterAsync(TargetGame);
            
            return hero;
        }
    }

    public class TestCaseTest {

        [TestCase]
        public void MarioBrosHeroTest()
        {
            string TargetGame = "MBr";
            string ExpectHero = "マリオ";

            Assert.AreEqual(ExpectHero, DummyTarget.getNintendoGameCharacter(TargetGame).Hero);
        }
        
        [TestCase("MBr", 1983, "マリオ")]
        [TestCase("LoZ", 1986, "リンク")]
        [TestCase("Pok", 1996, "サトシ")]
        public void NintendoHeroTest(string targetGame, int expectFirst, string expectHero)
        {
            NintendoGameCharacter NCharacter = DummyTarget.getNintendoGameCharacter(targetGame);

            Assert.AreEqual(expectFirst, NCharacter.FirstAppearance);
            Assert.AreEqual(expectHero, NCharacter.Hero);
        }
        
        [TestCase("MBr", ExpectedResult="ピーチ")]
        [TestCase("LoZ", ExpectedResult="ゼルダ")]
        [TestCase("Pok", ExpectedResult="カスミ")]
        public string NintendoHeroineTest(string targetGame, int expectFirst, string expectHeroine)
        {
            return DummyTarget.getNintendoGameCharacter(targetGame).Heroine;
        }
        
        
    }
}