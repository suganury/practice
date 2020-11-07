using System;
using System.Collections.Generic;
using System.Linq;
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
        readonly NintendoGameCharacter NCharacter;
        readonly string ExpectHero;
        readonly string ExpectHeroine;
        readonly string ExpectRival;

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

        readonly NintendoGameCharacter NCharacter;
        readonly string ExpectHero;
        readonly string ExpectHeroine;
        readonly string ExpectRival;

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
        readonly NintendoGameCharacter NCharacter;
        readonly string ExpectHero;
        readonly string ExpectHeroine;
        readonly string ExpectRival;

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

    [Category("hoge")]
    [TestFixtureSource(nameof(ParamWarehouseMethod))]
    public class ParamTestFixtureSource3
    {
        readonly NintendoGameCharacter NCharacter;
        readonly string ExpectHero;
        readonly string ExpectHeroine;
        readonly string ExpectRival;

        public ParamTestFixtureSource3(string title, string hero, string heroine, string rival) {
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
        
        static object[] ParamWarehouseMethod() {
            return new object[]
            {
                new string[] {"MBr", "マリオ", "ピーチ", "クッパ"},
                new string[] {"LoZ", "リンク", "ゼルダ", "ガノン"},
                new string[] {"Pok", "サトシ", "カスミ", "シゲル"},
            };
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
        public string NintendoHeroineTest(string targetGame)
        {
            return DummyTarget.getNintendoGameCharacter(targetGame).Heroine;
        }
        
        [TestCase(
        //▼テストケースの作者
        Author="suganury"
        //▼カテゴリ. dotnet test --filter TestCategory={CategoryName}のオプションで特定のカテゴリのみテスト実行可能
        , Category="hogeCategory"
        //▼テストケースの説明
        , Description="説明だYO"
        //▼テストを実行しないプラットフォームをカンマ区切りで指定。OSや.NETバージョンなどを指定可能
        , ExcludePlatform="Net-1.0,Windows8"
        //▼想定結果。Assertクラス等によるアサーションではなく、戻り値に実行結果を返すようにする。
        , ExpectedResult="hoge"
        //▼テスト無効フラグ。trueにするとテストが実行されなくなる
        , Explicit=false
        //▼テスト無効理由。Explicitとセットで使う
        , Reason="hogeしか返ってこんし"
        //▼テスト無視フラグと理由。このAttributeが付いているとテストが実行されなくなる
        , Ignore="hogeしか返ってこんし"
        //▼Ignoreと全く同じ。どちらか1つでいい
        , IgnoreReason="hogeしか返ってこんし"
        //▼テスト名。デフォルトではメソッド名になる
        , TestName="Hogeテスト"
        //▼対象のテストクラス
        , TestOf=typeof(String)
        )]
        public string test(){
            return "hoge";
        }
    }

    public class TestCaseSourceTest {

        static object[] NintendoCharaCases =
        {
            new object[] { "MBr", 1983, "マリオ" },
            new object[] { "LoZ", 1986, "リンク" },
            new object[] { "Pok", 1996, "サトシ" }
        };

        static IList<object> NintendoCharaCaseList = new List<object>
        {
            new object[] { "MBr", 1983, "マリオ" },
            new object[] { "LoZ", 1986, "リンク" },
            new object[] { "Pok", 1996, "サトシ" }
        };
        
        [TestCaseSource("NintendoCharaCases")]
        [TestCaseSource("NintendoCharaCaseList")]
        public void NintendoCharaTest(string targetGame, int expectFirst, string expectHero)
        {
            NintendoGameCharacter NCharacter = DummyTarget.getNintendoGameCharacter(targetGame);

            Assert.AreEqual(expectFirst, NCharacter.FirstAppearance);
            Assert.AreEqual(expectHero, NCharacter.Hero);
        }

        
        [TestCaseSource(nameof(GenerateTestCharacter), new object[] { "Hero" })]
        public void NintendoHeroTest(string expectHero)
        {
            List<string> nintendoHeros = DummyTarget.nintendoChara
                                                    .Values
                                                    .Select(n => n.Hero)
                                                    .ToList();
            
            CollectionAssert.Contains(nintendoHeros, expectHero);
        }

        static IList<string> GenerateTestCharacter(string charaType)
        {
            IList<string> list = new List<string>();
            if(charaType.Equals("Hero")) {
                list.Add("マリオ");
                list.Add("リンク");
                list.Add("サトシ");
                list.Add("ロックマン");
                list.Add("クラウド");
            } else if(charaType.Equals("Heroine")) {
                list.Add("ピーチ");
                list.Add("ゼルダ");
                list.Add("カスミ");
                list.Add("ロール");
                list.Add("ティファ");
            } else if(charaType.Equals("Rival")) {
                list.Add("クッパ");
                list.Add("ガノン");
                list.Add("シゲル");
                list.Add("フォルテ");
                list.Add("セフィロス");
            }
            return list;
        }
    }

    public class TestCaseSourceOtherClass {

        [TestCaseSource(typeof(TestCaseSourceTest), "NintendoCharaCases")]
        public void NintendoCharaTestOtherClass(string targetGame, int expectFirst, string expectHero)
        {
            NintendoGameCharacter NCharacter = DummyTarget.getNintendoGameCharacter(targetGame);

            Assert.AreEqual(expectFirst, NCharacter.FirstAppearance);
            Assert.AreEqual(expectHero, NCharacter.Hero);
        }
    }
}