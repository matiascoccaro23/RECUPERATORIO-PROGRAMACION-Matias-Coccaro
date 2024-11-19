namespace romb.cs
{
    using System;

    namespace RombosApp
    {
        public enum Contorno
        {
            Solido,
            Punteado,
            Rayado,
            Doble
        }

        public class Rombo
        {
            public double DiagonalMayor { get; set; }
            public double DiagonalMenor { get; set; }
            public Contorno TipoContorno { get; set; }

            public double Lado => Math.Sqrt(Math.Pow(DiagonalMayor / 2, 2) + Math.Pow(DiagonalMenor / 2, 2));
            public double CalcularArea() => (DiagonalMayor * DiagonalMenor) / 2;
            public double CalcularPerimetro() => 4 * Lado;

            public override bool Equals(object obj)
            {
                if (obj is Rombo otro)
                    return DiagonalMayor == otro.DiagonalMayor &&
                           DiagonalMenor == otro.DiagonalMenor &&
                           TipoContorno == otro.TipoContorno;
                return false;
            }

            public override int GetHashCode()
            {
                return (DiagonalMayor, DiagonalMenor, TipoContorno).GetHashCode();
            }

            public override string ToString()
            {
                return $"Rombo: DiagonalMayor={DiagonalMayor}, DiagonalMenor={DiagonalMenor}, Contorno={TipoContorno}";
            }
        }
    }

}