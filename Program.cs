using System;

class Program
{
    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== Calculadora Multiplataforma ===");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Calcular("suma");
                    break;
                case "2":
                    Calcular("resta");
                    break;
                case "3":
                    Calcular("multiplicación");
                    break;
                case "4":
                    Calcular("división");
                    break;
                case "5":
                    salir = true;
                    Console.WriteLine("¡Gracias por usar la calculadora!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla para intentar nuevamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void Calcular(string operacion)
    {
        Console.Write("Ingrese el primer número: ");
        if (!double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.WriteLine("Entrada inválida. Inténtelo nuevamente.");
            return;
        }

        Console.Write("Ingrese el segundo número: ");
        if (!double.TryParse(Console.ReadLine(), out double num2))
        {
            Console.WriteLine("Entrada inválida. Inténtelo nuevamente.");
            return;
        }

        double resultado = operacion switch
        {
            "suma" => num1 + num2,
            "resta" => num1 - num2,
            "multiplicación" => num1 * num2,
            "división" when num2 != 0 => num1 / num2,
            "división" => double.NaN, // Manejo de división por cero
            _ => 0
        };

        if (operacion == "división" && double.IsNaN(resultado))
        {
            Console.WriteLine("Error: No se puede dividir entre cero.");
        }
        else
        {
            Console.WriteLine($"El resultado de la {operacion} es: {resultado}");
        }

        Console.WriteLine("Presione cualquier tecla para volver al menú.");
        Console.ReadKey();
    }
}
