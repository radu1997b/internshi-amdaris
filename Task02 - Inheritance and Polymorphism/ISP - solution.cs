using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{
   interface IProfesor
    {
        void PuneNota(int nota);
        void PredaCurs(String curs);
    }

    interface IDirector
    {
        void SemeneazaActe();
    }

    class Profesor : IProfesor
    {
        public void PuneNota(int nota)
        {
            WriteLine("Am pus nota: ", nota);
        }
        public void PredaCurs(String curs)
        {
            WriteLine("Am predat cursul: ", curs);
        }
    }

    class Director : IProfesor,IDirector
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
