using System;
using System.Diagnostics;


namespace PROG2___Exercicios
{
    class Exercises
    {

        private static readonly string newLine = Environment.NewLine;

        public static void Ex1()
        {
            Console.WriteLine("Hello World");
        }


        public static void Ex2()
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

        /// <summary>
        /// Write a program that reads a certain amount of real numbers N, determined by the user,
        ///and prints the power of each number to the exponential Exp, also provided by the user.
        /// </summary>
        public static void Ex3()
        {
            int n = 0;

            do
            {
                Console.Write("Insert the amount of real numbers you want to power up, at least 1> ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 1);

            double b = 0, exp = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write("Insert the base real number> ");
                b = Convert.ToInt32(Console.ReadLine());
                Console.Write("Insert the exponential real number> ");
                exp = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Result> {0}", Power(b, exp));
            }


        }

        //CAN BE INPROVED WITH A DO WHILE!
        public static void Ex4()
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
            Console.WriteLine("Media> {0}" + newLine, soma / k);
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
        public static void Ex5(int op)
        {
            if (op == 1) //use DateTime
            {
                DateTime init = DateTime.Now;
                int x = 0;
                while (x++ != 10000000) ;
                TimeSpan end = DateTime.Now.Subtract(init);

                Console.WriteLine("Tempo decorrido> {0}" + newLine, end);
            }

            if (op == 2) //use StopWatch
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
        public static void Ex6()
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
        public static void Ex7(int op)
        {
            if (op == 1)
            {
                int days = 0;

                do
                {
                    Console.Write("Insert the number of days (number have to be bigger than 1)> ");
                    days = Console.Read();
                } while (days < 1);



                bool first = false;
                double tempInput = 0, tempSum = 0, tempLast = 0, tempMax = 0;
                int dayMax1 = 0, dayMax2 = 0;

                for (int i = 1; i <= days; i++)
                {
                    Console.Write(newLine + "Insert a temperature> ");
                    tempInput = Convert.ToDouble(Console.ReadLine());
                    if (!first)
                        first = true;
                    else
                    {
                        double absTemp = abs(tempInput - tempLast);
                        if (absTemp > tempMax)
                        {
                            tempMax = absTemp;
                            dayMax1 = i - 1;
                            dayMax2 = i;
                        }
                        Console.WriteLine(newLine + "The temperature between the days {0} and {1} increased/decreased {2} degrees.", i - 1, i, absTemp);
                    }

                    tempLast = tempInput;

                }//end for

                Console.WriteLine(newLine + "The average of the {0} temperatures inserted is {1} degrees.", days, tempSum / days);
                Console.WriteLine("The greatest temperature variation occurred between the days {0} and {1}, with the variation temperature of {2} degrees.", dayMax1, dayMax2, tempMax);

            }



            if (op == 2)
            {

            }

        }//end Ex7()

        private static double abs(double n)
        {
            return n < 0 ? n * -1 : n;
        }
        /// <summary>
        ///  Write a program that reads several radius of circles and computes the area and perimeter
        ///of the circle with an average of 5 decimal places. The program should stop computing once
        ///the number 0.0 is read.
        /// </summary>
        /// 
        /// //------------------>NEEDS TO BE REVISED, the math is wrong!!!
        public static void Ex8()
        {
            double op = 0;
            bool first = true;
            const double PI = 3.15;
            do
            {

                if (!first)
                {
                    Console.WriteLine(newLine + "Area: {0}", PI * Power(op, 2));
                    Console.WriteLine("Perimeter: {0}", 2 * PI * op);
                }

                Console.Write("Insert circle radius> ");
                op = Convert.ToDouble(Console.ReadLine());
                first = false;
            } while (op != 0);
        }//end Ex8

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
        public static void Ex9()
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
                Console.WriteLine("Product: {0}", prod);
            }
        } //end Ex9()

        /// <summary>
        ///Write a program that reads an integer N and prints all the odd numbers bellow the given
        ///number.
        /// </summary>
        public static void Ex10()
        {
            Console.Write("Insert an integer> ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(newLine + "Odd numbers bellow {0}:", n);

            for (int i = n; i > 0; i--)
            {
                if (i % 2 != 0) Console.WriteLine("{0}", i);
            }

            Console.WriteLine(newLine);
        }//end Ex10()

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
        public static void Ex11()
        {
            showMenu();
            string input = Console.ReadLine();

            // byte op = Convert.ToByte(input);
            byte op = (byte)input[0];

            Console.WriteLine(newLine + op);
        }//end Ex11()

        /// <summary>
        /// Show menu of Ex11()
        /// </summary>
        private static void showMenu()
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("\t1 - Start Game");
            Console.WriteLine("\t2 - Highest Scores");
            Console.WriteLine("\t3 - Multiplayer Mode");
            Console.WriteLine("\t4 - Options");
            Console.WriteLine("\t5 - Exit");
        }

        /// <summary>
        ///  Write a program that generates a random number between 1 and 100 without revealing
        ///it to the user. Then, the program accepts numbers form the user in an attempt to guess
        ///the previous randomly generated number. In case the user fails to guess the number, the
        ///program should tell him if the randomly generated number is above or below the number
        ///he entered. Once the user correctly guesses the number, the program should provide him
        ///with a congratulations message, show the number of attempts he tried and ask if he wants
        ///to play the game again.
        /// </summary>
        public static void Ex12()
        {
            Random rand = new Random();

            int value = rand.Next(1, 100);
            byte guess = 0;

            int tries = 0;

            do
            {
                Console.Write("Insert an integer to guess the random number between 1 and 100> ");

                //Input checking
                try
                {
                    guess = Convert.ToByte(Console.ReadLine());
                    if (guess < 1 || guess > 100) throw new OverflowException();

                }
                catch (OverflowException)
                {
                    Console.WriteLine(newLine + "\tERROR: The number has to be between 1 and 100!" + newLine + newLine);
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine(newLine + "\tERROR: I asked you to insert a integer not that!" + newLine + newLine);
                    continue;
                }


                if (guess > value)
                    Console.WriteLine(newLine + "\tThe random number is smaller than the previously inserted one! " +
                                      newLine + newLine);
                if (guess < value)
                    Console.WriteLine(newLine + "\tThe random number is bigger than the previously inserted one! " +
                                      newLine + newLine);
                tries++;

            } while (guess != value);

            Console.WriteLine(newLine + "Congratulations! You won after {0} tries, wasnt this the best well spent time of your life? I know i know . . . ", tries);
            Console.WriteLine("Acertou ao fim de");

        }//end Ex12()

        /// <summary>
        ///  Write a program that reads the birthday and birth time of a person, and computes the age
        ///of the person in years, days, and minutes.
        /// </summary>
        public static void Ex13()
        {
            Console.WriteLine("Insert ");
        }
    }
}
