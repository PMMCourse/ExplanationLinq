using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExplanation
{
    public enum TipoArma
    {
        Contudente = 10,
        Perforante = 20,
        Cortante = 30
    }
    public class Arma
    {
        public TipoArma TipoArma { get; set; }

        public void CambiarArma(TipoArma tipoArma)
        {
            TipoArma = TipoArma.Contudente;
        }
    }
    public class Campesino
    {
        public int HP { get; set; }
        public int MP { get; set; }

        public int Exp { get; set; }

        public int Level { get; set; }

        public void LevelUP(int exp)
        {
            if(Exp >= 100)
            {
                Exp = Exp - 100;
                Level++;
            }
        }


        public List<Arma> ArmaEquipada { get; set; }

        public Milicia Promote()
        {
            return new Milicia()
            {
                Level = 1
            };
        }
    }

    public class Milicia : Campesino
    {        
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Campesino> campesinos = new List<Campesino>();

            campesinos.Add(new Campesino() { Level = 5, HP = 15 });
            campesinos.Add(new Campesino() { Level = 3 , HP = 20});
            campesinos.Add(new Campesino() { Level = 5 , HP = 30});
            
            var level5 = campesinos
                .Where(p => p.Level >= 5 && p.HP >= 20);
            var hpAbove20 = level5.Where(p => p.HP >= 20);

            var milicianos = campesinos
                .Where(x => x.Level > 10)
                .Select(p => new Milicia() { Exp = p.Exp });

            campesinos.FirstOrDefault(p => p.Level >= 5);

            var dictionary = campesinos.GroupBy(x => x.Level);

            campesinos.Where(campesino => campesino.Level >= 5
                            && campesino.ArmaEquipada
                                .Any(arma => arma.TipoArma == TipoArma.Cortante));

            campesinos.Skip(10 * 3).Take(10);

            campesinos.Sum(x => x.HP);
            campesinos.Max(x => x.HP);

            campesinos.OrderBy(x => x.HP);
            campesinos.OrderByDescending(x => x.HP);

            

                              
            campesinos.Add(new Campesino() { Level = 10 });

            foreach(var camp in level5)
            {
                Console.WriteLine(camp.Level);
            }

            Console.ReadKey();

            /*
            campesinos.Where(PromotePeasants);
            var level5 = campesinos                
                .Where(peasant => peasant.Level >= 5);

            level5.Select(peasant => peasant.Promote());
            
            Func<Campesino, bool> predicate = PromotePeasants;
                //peasant => peasant.Level >= 5;

            predicate.Invoke(new Campesino());            

            */
        }

        private static Milicia ConvertToMilicia(Campesino arg)
        {
            return arg.Promote();
        }

        private static bool PromotePeasants(Campesino arg)
        {            
            if(arg.Level >= 5 && arg.HP >= 20)
            {
                return true;                                
            }
            return false;
        }


        private static void HelloWorld() => Console.WriteLine("");

    }
}
