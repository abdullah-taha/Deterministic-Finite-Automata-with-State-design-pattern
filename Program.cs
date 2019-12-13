using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomata2
{
    class Program
    {
        interface State
        {
            void zero();
            void one();
        }

        class Otomata
        {
            private State D0;
            private State D1;

            private State simdikiState;


            public State get_D0State() { return this.D0; }
            public State get_D1State() { return this.D1; }
            public State get_simdikiState(){return this.simdikiState; }
            public void set_simdikiState(State s) {this.simdikiState = s; }

            public Otomata(string s)
            {
                D0 = new D0_State(this);
                D1 = new D1_State(this);
                simdikiState = D0;
                Console.WriteLine("simdiki state = D0");
                start(s);

                
            }
            public void one()
            {
                simdikiState.one();
            }

            public void zero()
            {
                simdikiState.zero();
                
            }

            public void start(string s)
            {
                
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '0') zero();
                    else one();
                }
                if (simdikiState == D0) Console.WriteLine("kabul, cift sayida sifir var");
                else Console.WriteLine("red, tek sayida sifir var");
            }
        }

        class D0_State : State
        {
            Otomata otomata;
            public D0_State(Otomata otomata)
            {
                this.otomata = otomata;
            }
            public void zero()
            {
                otomata.set_simdikiState(otomata.get_D1State());
                Console.WriteLine("simdiki state = D1");
            }

            public void one()
            {
                otomata.set_simdikiState(otomata.get_D0State());
                Console.WriteLine("simdiki state = D0");
            }
        }

        class D1_State : State
        {
            Otomata otomata;
            public D1_State(Otomata otomata)
            {
                this.otomata = otomata;
            }
            public void zero()
            {
                otomata.set_simdikiState(otomata.get_D0State());
                Console.WriteLine("simdiki state = D0");

            }

            public void one()
            {
                otomata.set_simdikiState(otomata.get_D1State());
                Console.WriteLine("simdiki state = D1");
            }
        }
        static void Main(string[] args)
        {
            Otomata otomata = new Otomata("000110");
            Console.ReadKey();
        }
    }
}
