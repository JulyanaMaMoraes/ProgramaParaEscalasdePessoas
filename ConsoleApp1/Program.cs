using System;
using System.Collections.Generic;

namespace SorteioMeninas
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<string> meninas = new List<string>
            {
                "Nathalia", "Larissa", "Manoella", "Julyana", "Carol", "Vitoria"
            };


            int mes = 9; // Outubro
            int ano = DateTime.Today.Year;
            int totalDiasNoMes = DateTime.DaysInMonth(ano, mes);
            int minEscalasPorMenina = 3;
            int maxEscalasPorMenina = 4;

            Dictionary<string, int> meninasEscalas = new Dictionary<string, int>();
            foreach (string menina in meninas)
            {
                meninasEscalas.Add(menina, 0);
            }

            for (int dia = 1; dia <= totalDiasNoMes; dia++)
            {
                DateTime data = new DateTime(ano, mes, dia);
                if (data.DayOfWeek == DayOfWeek.Sunday)
                {
                    List<string> meninasDisponiveisManha = meninas.FindAll(m => meninasEscalas[m] < maxEscalasPorMenina);
                    List<string> meninasDisponiveisNoite = meninas.FindAll(m => meninasEscalas[m] < maxEscalasPorMenina);

                    string manha1 = SortearMenina(meninasDisponiveisManha, random, meninasEscalas);
                    string manha2 = SortearMenina(meninasDisponiveisManha, random, meninasEscalas);

                    meninasDisponiveisNoite.Remove(manha1);
                    meninasDisponiveisNoite.Remove(manha2);

                    string noite1 = SortearMenina(meninasDisponiveisNoite, random, meninasEscalas);
                    string noite2 = SortearMenina(meninasDisponiveisNoite, random, meninasEscalas);

                    Console.WriteLine($"Domingo {dia}/{mes}/{ano}: Manhã - {manha1} e {manha2}, Noite - {noite1} e {noite2}");
                }
            }
        }

        static string SortearMenina(List<string> meninasDisponiveis, Random random, Dictionary<string, int> meninasEscalas)
        {
            int index = random.Next(meninasDisponiveis.Count);
            string meninaSelecionada = meninasDisponiveis[index];
            meninasDisponiveis.RemoveAt(index);
            meninasEscalas[meninaSelecionada]++;
            return meninaSelecionada;
        }
    }
}







