using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AttributesTest
{
    public static class DummyTarget
    {
        public static IDictionary<string, NintendoGameCharacter> nintendoChara = new Dictionary<string, NintendoGameCharacter>(){
            {"MBr", new NintendoGameCharacter(1983, "マリオ", "ピーチ", "クッパ")},
            {"LoZ", new NintendoGameCharacter(1986, "リンク", "ゼルダ", "ガノン")},
            {"Pok", new NintendoGameCharacter(1996, "サトシ", "カスミ", "シゲル")},
        };

        public static object getAnonymousObject() {
            return "hoge";
        }

        public static NintendoGameCharacter getNintendoGameCharacter(string title) {
            return nintendoChara[title];
        }
        
        public static async Task<string> getNintendoGameCharacterAsync(string title) {
            return await Task.Run(() => {
                Thread.Sleep(100);
                return nintendoChara[title].Hero;
            });
        }

    }

    public class NintendoGameCharacter{

        public int FirstAppearance {get; set;}
        public string Hero {get; set;}
        public string Heroine {get; set;}
        public string Rival {get; set;}

        public NintendoGameCharacter(int first, string hero, string heroine, string rival) {
            this.FirstAppearance = first;
            this.Hero = hero;
            this.Heroine = heroine;
            this.Rival = rival;
        }
    }
}