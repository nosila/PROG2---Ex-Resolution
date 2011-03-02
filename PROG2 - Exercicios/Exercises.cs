using System;
using System.Diagnostics;


namespace PROG2___Exercicios
{
    class Exercises
    {

        private static readonly string newLine = Environment.NewLine;

        public static void ex1()
        {
            Console.WriteLine("Hello World");
        }

        public static void ex2()
        {
            string nome = "";
            int idade = 0;

            Console.Write("Insira o nome> ");
            nome = Console.ReadLine();

            Console.Write("Insira a idade> ");
            idade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nome> {0} {1}Idade> {2}", nome, newLine, idade);
        }

        private static int Power(int b, int exp)
        {
            int res = 1;
            for (int i = 0; i < exp; i++)
            {
                res *= b;
            }

            return res;
        }

        public static void ex3()
        {
            string aux;
            int b = 0, exp = 0, res = 0;

            Console.Write("Insira a base> ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insira o expoente> ");
            exp = Convert.ToInt32(Console.ReadLine());

            res = Power(b, exp);
            Console.WriteLine("Resultado> {0}", res);

        }

        //CAN BE INPROVED WITH A DO WHILE!
        public static void ex4()
        {
            int menor = -1, maior = -1, aux = 0, soma = 0, k = 0;
            while (aux != -1)
            {
                Console.Write("Insira um valor> ");
                aux = Convert.ToInt32(Console.ReadLine());
                if (aux != -1)
                {
                    if (menor == -1 || menor > aux) menor = aux;
                    if (maior < aux) maior = aux;
                    soma += aux;
                    k++;
                }

            }

            Console.WriteLine(newLine + "Menor> {1}", menor);
            Console.WriteLine("Maior> {0}", maior);
            Console.WriteLine("Soma> {0}", soma);
            Console.WriteLine("Media> {0}"+ newLine, soma / k);
        }

        /// <summary>
        ///Write a program to determine the system date and time, then executes a cycle that incre-
        ///ments 10 millions times a certain variable, and then determines the system date and time
        ///again and prints the difference between the times read, i.e., the time elapsed during the
        ///cycle execution.
        /// 
        /// This method can be executed using DateTime or StopWatch. The difference between the two 
        /// resides in the fact that StopWatch is more precise than DateTime.
        /// 
        /// Usage:
        ///     1- System.DateTime
        ///     2- System.Diagnostics.StopWatch
        /// 
        /// source: http://www.csharphelp.com/2011/01/using-the-stopwatch-class-in-c/
        /// </summary>
       /// <param name="op">Option of execution.</param>
        public static void ex5(int op)
        {
            if(op == 1) //use DateTime
            {
                DateTime init = DateTime.Now;
                int x = 0;
                while (x++ != 10000000) ;
                TimeSpan end = DateTime.Now.Subtract(init);

                Console.WriteLine("Tempo decorrido> {0}" + newLine, end);
            }

            if(op == 2) //use StopWatch
            {
                Stopwatch watch = Stopwatch.StartNew();
                int x = 0;
                while (x++ != 10000000) ;
                watch.Stop();
                Console.WriteLine("Tempo decorrido> {0}" + newLine, watch.Elapsed);
            }
        }

        /// <summary>
        ///Create a program that uses an auxiliary method which accepts two dates and determines
        ///the difference in days, minutes and seconds between the dates. The method should return
        ///a value of type string.
        /// </summary>
        public static void ex6()
        {
            Console.WriteLine(dateDiff(DateTime.Now, DateTime.Now));
        }

        /// <summary>
        /// Returns a string with the time difference between two dates.
        /// </summary>
        /// <param name="init">Initial time.</param>
        /// <param name="end">Final time.</param>
        /// <returns>The time elapsed between the two dates</returns>
        private static string dateDiff(DateTime init, DateTime end)
        {
            return end.Subtract(init).ToString();
        }

        /// <summary>
        ///Write a program that reads N real numbers representing day temperatures, and determines
        ///the average temperature, the greatest temperature variation (in absolute value) and the
        ///days between which it occurred. The output should be provided in the following form:
        ///
        ///"The average of the N temperatures inserted is __ degrees.
        ///The greatest temperature variation occurred between the days __ and __,
        ///with the variation temperature of __ degrees.
        ///The temperature between the days __ and __ increased/decreased __ degrees."
        /// 
        /// This method has 2 options of execution:
        ///     1- The user first defines the amount of temperatures he will put.
        ///     2- The system will only stop receiving input after user writes 'quit'
        /// </summary>
        /// <param name="op">Option of execution.</param>
        public static void ex7(int op)
        {
            if(op == 1)
            {
                int days = 0;

                do
                {
                    Console.Write("Insert the number of days> ");
                    days = Console.Read();
                } while (days < 1);

                int  maxDay = -1, minDay = -1;
                double sum = 0, aux = -1, max = -1, min = -1 ; //4bytes vs double 8 bytes
                bool first = false;

                for(int i = 1; i<=days; i++)
                {
                    Console.Write(newLine + "Insert a temperature> ");
                    aux = Convert.ToDouble(Console.ReadLine());

                    sum += aux;
                    if(!first)
                    {
                        max = aux;
                        maxDay = i;
                        min = aux;
                        minDay = i;
                        first = true;
                        
                    }
                    else
                    {
                        if(aux > max)
                        {
                            max = aux;
                            maxDay = i;
                        }
                        else if (aux < min)
                        {
                            min = aux;
                            minDay = i;
                        }
                    }

                }//end for

                Console.WriteLine(newLine + "The average of the {0} temperatures inserted is {1} degrees.", days, sum/days);
                Console.WriteLine("The greatest temperature variation occurred between the days {0} and {1}, with the variation temperature of {2} degrees.");
                Console.WriteLine("The temperature between the days {0} and {1} increased/decreased {2} degrees.");
            }



            if(op == 2)
            {
                
            }

        }//end ex7()

        /// <summary>
        ///  Write a program that reads several radius of circles and computes the area and perimeter
        ///of the circle with an average of 5 decimal places. The program should stop computing once
        ///the number 0.0 is read.
        /// </summary>
        /// 
        /// //------------------>NEEDS TO BE REVISED, the math is wrong!!!
        public static void ex8()
        {
            double op = 0;
            bool first = true;
            const double PI = 3.15;
            do
            {

                if(!first)
                {
                    Console.WriteLine(newLine + "Area: {0}", PI * Power(op,2));
                    Console.WriteLine("Perimeter: {0}", 2 * PI * op);
                }

                Console.Write("Insert circle radius> ");
                op = Convert.ToDouble(Console.ReadLine());
                first = false;
            } while (op != 0);
        }//end ex8

        private static double Power(double b, double exp)
        {
            double res = 1;
            for (int i = 0; i < exp; i++)
            {
                res *= b;
            }

            return res;
        }

        /// <summary>
        /// Write a program that reads a none empty sequence of real numbers, terminated by 0.0,
        ///and calculates the sum and the product of all numbers with a precision of 4 decimal places.
        /// </summary>
        public static void ex9()
        {
            double input = 0, sum = 0, prod = 1;

            do
            {
                if (input != 0)
                {
                    sum += input;
                    prod *= input;
                }

                Console.Write("Insert a real number>");
                input = Convert.ToDouble(Console.ReadLine());

            } while (input != 0);

            if (sum > 0)
            {
                Console.WriteLine(newLine + "Sum: {0}", sum);
                Console.WriteLine("Product: {0}",prod);
            }
        } //end ex9()

        /// <summary>
        ///Write a program that reads an integer N and prints all the odd numbers bellow the given
        ///number.
        /// </summary>
        public static void ex10()
        {
            Console.Write("Insert an integer> ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(newLine + "Odd numbers bellow {0}:",n);

            for (int i = n; i > 0; i--)
            {
                if (i % 2 != 0) Console.WriteLine("{0}",i);
            }

            Console.WriteLine(newLine);
        }//end ex10()

        /// <summary>
        ///Write a program that presents the following options to the user.
        ///     1 - Star Game
        ///     2 - Highest Scores
        ///     3 - Multiplayer Mode
        ///     4 - Options
        ///     5 - Exit
        ///Afterwards, the program should read an integer, which is only considered valid if between
        ///1 and 5, and output the text of the selected option. In case the user introduced an in-
        ///valid option, the program should print the message Invalid Option. The program only
        ///terminates if the option 5 is entered, otherwise the menu is showed again.
        /// </summary>
        public static void ex11()
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("\t1 - Start Game");
            Console.WriteLine("\t2 - Highest Scores");
            Console.WriteLine("\t3 - Multiplayer Mode");
            Console.WriteLine("\t4 - Options");
            Console.WriteLine("\t5 - Exit");

            string input = Console.ReadLine();

           // byte op = Convert.ToByte(input);
            byte op = (byte) input;
            
            Console.WriteLine(newLine + op);
        }
    }
}
