using System;

public class Program
{
    enum AsteroidType
    {
        Pequeno = 1,
        Mediano = 2,
        Grande = 3,
        Cataclismico = 4
    }

    static void Main()
    {
        int hierroGeneral = 0, oroGeneral = 0, platinoGeneral = 0, miscelaneoGeneral = 0, cargaTotalGeneral = 0;

        while (true)
        {
            var sistema = SimularSistema();
            int sistemaId = sistema.Item1;
            var asteroides = sistema.Item2;

            var resultado = ProcesarAsteroides(asteroides);
            int hierro = resultado.Item1;
            int oro = resultado.Item2;
            int platino = resultado.Item3;
            int miscelaneo = resultado.Item4;
            int cargaTotal = resultado.Item5;

            ImprimirReporte(sistemaId, asteroides.Length, hierro, oro, platino, miscelaneo, cargaTotal);

            hierroGeneral += hierro;
            oroGeneral += oro;
            platinoGeneral += platino;
            miscelaneoGeneral += miscelaneo;
            cargaTotalGeneral += cargaTotal;

            Console.WriteLine("¿Desea ir a otro planeta? (S/N)");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() != "s")
            {
                break;
            }
        }

        ImprimirReporteGeneral(hierroGeneral, oroGeneral, platinoGeneral, miscelaneoGeneral, cargaTotalGeneral);
    }

    static Tuple<int, AsteroidType[]> SimularSistema()
    {
        Random random = new Random();
        int sistemaId = random.Next(10000, 99999);
        int numAsteroides = random.Next(1, 11);
        AsteroidType[] asteroides = new AsteroidType[numAsteroides];

        for (int i = 0; i < numAsteroides; i++)
        {
            asteroides[i] = (AsteroidType)random.Next(1, 5);
        }

        return Tuple.Create(sistemaId, asteroides);
    }

    static Tuple<int, int, int, int, int> ProcesarAsteroides(AsteroidType[] asteroides)
    {
        Random random = new Random();
        int hierroTotal = 0, oroTotal = 0, platinoTotal = 0, miscelaneoTotal = 0, cargaTotal = 0;

        foreach (AsteroidType asteroide in asteroides)
        {
            int carga = 0;
            switch (asteroide)
            {
                case AsteroidType.Pequeno:
                    carga = 1000;
                    break;
                case AsteroidType.Mediano:
                    carga = 2000;
                    break;
                case AsteroidType.Grande:
                    carga = 5000;
                    break;
                case AsteroidType.Cataclismico:
                    carga = 10000;
                    break;
            }

            int[] metales = new int[4];
            for (int i = 0; i < 4; i++)
            {
                metales[i] = random.Next(1, carga + 1);
                carga -= metales[i];
            }

            hierroTotal += metales[0];
            oroTotal += metales[1];
            platinoTotal += metales[2];
            miscelaneoTotal += metales[3];
        }

        cargaTotal = hierroTotal + oroTotal + platinoTotal + miscelaneoTotal;

        return Tuple.Create(hierroTotal, oroTotal, platinoTotal, miscelaneoTotal, cargaTotal);
    }

    static void ImprimirReporte(int sistemaId, int numAsteroides, int hierro, int oro, int platino, int miscelaneo, int cargaTotal)
    {
        Console.WriteLine($"EN EL SISTEMA [{sistemaId}] SE MINARON [{numAsteroides}] ASTEROIDES");
        Console.WriteLine($"{hierro} KG de hierro");
        Console.WriteLine($"{oro} KG de oro");
        Console.WriteLine($"{platino} KG de platino");
        Console.WriteLine($"{miscelaneo} KG de metales misceláneos");
        Console.WriteLine($"Por un total de {cargaTotal} KG de carga.");
    }

    static void ImprimirReporteGeneral(int hierro, int oro, int platino, int miscelaneo, int cargaTotal)
    {
        Console.WriteLine("Reporte general de todos los planetas:");
        Console.WriteLine($"{hierro} KG de hierro");
        Console.WriteLine($"{oro} KG de oro");
        Console.WriteLine($"{platino} KG de platino");
        Console.WriteLine($"{miscelaneo} KG de metales misceláneos");
        Console.WriteLine($"Por un total de {cargaTotal} KG de carga.");
    }
}
