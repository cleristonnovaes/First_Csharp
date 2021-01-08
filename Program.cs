using System;

namespace First_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var IndiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        
                        Console.WriteLine("Informe a nota do aluno: ");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor nota deve ser decimal");
                        }

                        alunos[IndiceAluno] = aluno;
                        IndiceAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos){
                        if(!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"Aluno {a.Nome} - Nota {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for(int i=0; i < alunos.Length; i++)
                        if(!string.IsNullOrEmpty(alunos[i].Nome))
                        {
                            notaTotal = notaTotal + alunos[i].Nota;
                            nrAlunos++;
                        }

                        var mediaGeral = notaTotal/nrAlunos;
                        ConceitoEnum conceito;

                        if(mediaGeral < 2)
                        {
                            conceito = ConceitoEnum.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceito = ConceitoEnum.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceito = ConceitoEnum.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceito = ConceitoEnum.B;
                        }
                        else
                        {
                            conceito = ConceitoEnum.A;
                        }
                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito: {conceito}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
            opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar aluno");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
