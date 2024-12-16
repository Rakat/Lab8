using System;

namespace DelegatesExample
{
    // Делегати
    public delegate double FunctionDelegate(double x); // Для завдання 1
    public delegate void DayDelegate();               // Для завдання 2
    public delegate T Operation<T>(T a, T b);         // Для завдання 3

    class Program
    {
        static void Main()
        {
            // --- Завдання 1: Просте використання делегатів ---
            Console.WriteLine("Task 1: Function Calculation");
            Console.Write("Enter a value for x: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double x))
            {
                FunctionDelegate func;

                if (x < 0)
                    func = FunctionNegative;
                else if (x > 0)
                    func = FunctionPositive;
                else
                    func = FunctionZero;

                double result = func(x);
                Console.WriteLine($"F(x) = {result}");
            }
            else
            {
                Console.WriteLine("Потрібно було ввести число.");
                return;
            }

            // --- Завдання 2: Групове перетворення методів ---
            Console.WriteLine("\nTask 2: Weekly Planner");
            Console.Write("Enter the day number (1-7): ");
            string dayInput = Console.ReadLine();

            if (int.TryParse(dayInput, out int dayNumber) && dayNumber >= 1 && dayNumber <= 7)
            {
                DayDelegate[] dayMethods = { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
                dayMethods[dayNumber - 1].Invoke();
            }
            else
            {
                Console.WriteLine("Некоректний номер дня тижня.");
            }

            // --- Завдання 3: Універсальні делегати ---
            Console.WriteLine("\nTask 3: Arithmetic Calculator");
            Console.Write("Enter first number: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.WriteLine("Потрібно ввести число.");
                return;
            }

            Console.Write("Enter an operator (+, -, *, /): ");
            string operation = Console.ReadLine();

            Console.Write("Enter second number: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
            {
                Console.WriteLine("Потрібно ввести число.");
                return;
            }

            Operation<double> operationDelegate = null;

            switch (operation)
            {
                case "+":
                    operationDelegate = Add;
                    break;
                case "-":
                    operationDelegate = Subtract;
                    break;
                case "*":
                    operationDelegate = Multiply;
                    break;
                case "/":
                    operationDelegate = Divide;
                    break;
                default:
                    Console.WriteLine("Невідома операція.");
                    return;
            }

            double calcResult = operationDelegate(num1, num2);
            Console.WriteLine($"Result: {calcResult}");
        }

        // --- Методи для Завдання 1 ---
        static double FunctionNegative(double x) => 4 * x - 1;
        static double FunctionPositive(double x) => 25 * x + 10;
        static double FunctionZero(double x) => 0;

        // --- Методи для Завдання 2 ---
        static void Monday() => PrintDayAndTasks("Monday", "1. Meeting at 10 AM\n2. Gym in the evening.");
        static void Tuesday() => PrintDayAndTasks("Tuesday", "1. Project work\n2. Family dinner.");
        static void Wednesday() => PrintDayAndTasks("Wednesday", "1. Mid-week review\n2. Go to the market.");
        static void Thursday() => PrintDayAndTasks("Thursday", "1. Team call\n2. Read a book.");
        static void Friday() => PrintDayAndTasks("Friday", "1. Finish work tasks\n2. Movie night.");
        static void Saturday() => PrintDayAndTasks("Saturday", "1. Cleaning the house\n2. Relax with family.");
        static void Sunday() => PrintDayAndTasks("Sunday", "1. Plan for next week\n2. Go for a walk.");

        static void PrintDayAndTasks(string day, string tasks)
        {
            Console.WriteLine($"Day: {day}");
            Console.WriteLine($"Tasks:\n{tasks}");
        }

        // --- Методи для Завдання 3 ---
        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Division by zero is not allowed.");
                return 0;
            }
            return a / b;
        }
    }
}
