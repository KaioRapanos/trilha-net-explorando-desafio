namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }


        internal void CriarSuite()
        {
            Console.Write("Por favor digite o tipo de suite: ");
            TipoSuite = Console.ReadLine();

            bool naoCapacidadeValida = true;
            bool naoValorValido = true;
            while (naoCapacidadeValida)
            {
                Console.Write("Por favor digite a capacidade desta suite: ");
                try
                {
                    Capacidade = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Capacidade invalida digite novamente: ");
                };
                while (naoValorValido)
                {
                    Console.Write("Por favor digite o valor da diaria desta suite: ");
                    try
                    {
                        ValorDiaria = decimal.Parse(Console.ReadLine());
                        
                        naoValorValido = false;
                        naoCapacidadeValida = false;
                    }
                    catch (Exception)
                    {
                        Console.Write("Valor invalido digite novamente: ");
                    }
                };
            };
        }
    }
}