using System;

namespace SingleResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            var input = GetUserInput();

            while (input != "quit")
            {
                var result = calculator.Calculate(input);
                Console.WriteLine($"Result: {result}");

                input = GetUserInput();
            }
        }

        private static string GetUserInput()
        {
            Console.Write("Enter an expression to calculate (or 'quit' to exit): ");
            return Console.ReadLine();
        }
    }

    class Calculator
    {
        public double Calculate(string equation)
        {
            var parser = new EquationParser(equation);
            var operands = parser.GetOperands();
            var operation = parser.GetOperation();

            switch (operation)
            {
                case "+":
                    return operands[0] + operands[1];
                case "-":
                    return operands[0] - operands[1];
                case "*":
                    return operands[0] * operands[1];
                case "/":
                    return operands[0] / operands[1];
                default:
                    throw new InvalidOperationException($"Unknown operation: {operation}");
            }
        }
    }

    class EquationParser
    {
        private readonly string _equation;

        public EquationParser(string equation)
        {
            _equation = equation;
        }

        public double[] GetOperands()
        {
            var parts = _equation.Split(new[] { "+", "-", "*", "/" }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new ArgumentException("Equation must contain exactly two operands");
            }

            double[] operands = new double[2];

            if (!double.TryParse(parts[0], out operands[0]))
            {
                throw new ArgumentException($"Invalid operand: {parts[0]}");
            }

            if (!double.TryParse(parts[1], out operands[1]))
            {
                throw new ArgumentException($"Invalid operand: {parts[1]}");
            }

            return operands;
        }

        public string GetOperation()
        {
            if (_equation.Contains("+"))
            {
                return "+";
            }
            else if (_equation.Contains("-"))
            {
                return "-";
            }
            else if (_equation.Contains("*"))
            {
                return "*";
            }
            else if (_equation.Contains("/"))
            {
                return "/";
            }
            else
            {
                throw new ArgumentException("Equation must contain an operation");
            }
        }
    }
}
