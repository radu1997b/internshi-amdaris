using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{
   interface IAngajat
    {
        void PuneNota(int nota);
        void PredaCurs(String curs);
        void SemeneazaActe();
    }

    class Profesor : IAngajat
    {
        public void PuneNota(int nota)
        {
            WriteLine("Am pus nota: ", nota);
        }
        public void PredaCurs(String curs)
        {
            WriteLine("Am predat cursul: ", curs);
        }
        public void SemeneazaActe()
        {
            throw new NotImplementedException();
        }
    }

    class Director : IAngajat
    {

        public void PuneNota(int nota)
        {
            WriteLine("Am pus nota: ", nota);
        }
        public void PredaCurs(String curs)
        {
            WriteLine("Am predat cursul: ", curs);
        }
        public void SemeneazaActe()
        {
            WriteLine("Am semnat actele!");
        }
    }
}
