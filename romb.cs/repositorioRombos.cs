using romb.cs.RombosApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RombosApp
{
    public class RepositorioRombos
    {
        private List<Rombo> rombos = new List<Rombo>();

        public void Agregar(Rombo rombo)
        {
            if (!rombos.Contains(rombo))
                rombos.Add(rombo);
            else
                throw new InvalidOperationException("El rombo ya existe.");
        }

        public void Eliminar(Rombo rombo)
        {
            rombos.Remove(rombo);
        }

        public List<Rombo> ObtenerTodos()
        {
            return rombos;
        }

        public int Contar()
        {
            return rombos.Count;
        }

        public void GuardarEnArchivo(string rutaArchivo)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                foreach (var rombo in rombos)
                {
                    writer.WriteLine($"{rombo.DiagonalMayor}|{rombo.DiagonalMenor}|{rombo.TipoContorno}");
                }
            }
        }

        public void CargarDesdeArchivo(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo)) return;

            using (StreamReader reader = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    var partes = linea.Split('|');
                    var rombo = new Rombo
                    {
                        DiagonalMayor = double.Parse(partes[0]),
                        DiagonalMenor = double.Parse(partes[1]),
                        TipoContorno = Enum.Parse<Contorno>(partes[2])
                    };
                    Agregar(rombo);
                }
            }
        }
    }
}
