using System;

namespace Project
{
    class Program
    {
        static void Main()
        {
            int x, y;
            char operation;

            Console.WriteLine("Please type in your first integer: ");
            x = Convert.ToInt32(Console.ReadLine());            
            
            Console.WriteLine("Now type in your second integer: ");
            y = Convert.ToInt32(Console.ReadLine());            
            
            Console.WriteLine("Type in the operator: ");
            operation = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Conversions of first integer:");
            Console.WriteLine("Decimal to Binary " + DecToBinary(x));
            Console.WriteLine("Binary to Decimal " + BinaryToDec(DecToBinary(x)));
            Console.WriteLine("Decimal to Hex " + DecToHex(x));
            Console.WriteLine("Hex to Decimal " + HexToDex(DecToHex(x)));
            Console.WriteLine("Decimal to Sign Exponent Mantissa " + BinaryToSEM(DecToBinary(x)));
            Console.WriteLine("Sign Exponent Mantissa to Decimal " + SEMToBinary(BinaryToSEM(DecToBinary(x))));
            Console.WriteLine("");

            Console.WriteLine("Conversions of second integer:");
            Console.WriteLine("Decimal to Binary " + DecToBinary(y));
            Console.WriteLine("Binary to Decimal " + BinaryToDec(DecToBinary(y)));
            Console.WriteLine("Decimal to Hex " + DecToHex(y));
            Console.WriteLine("Hex to Decimal " + HexToDex(DecToHex(y)));
            Console.WriteLine("Decimal to Sign Exponent Mantissa " + BinaryToSEM(DecToBinary(y)));
            Console.WriteLine("Sign Exponent Mantissa to Decimal " + SEMToBinary(BinaryToSEM(DecToBinary(y))));
            Console.WriteLine("");

            NumberChecker(MathOperation(x, y, operation));
            Console.WriteLine("Operation result: " + MathOperation(x, y, operation));
            
        }
        //Check to see if the number is Binary, Hexadecimal, Sign Exponent Mantissa, Normalized Floating Point, Denormalized Floating Point, NaN, Zero
        static string NumberChecker(float input)
        {
            return "";
        }
        //Convert to Decimal to Binary
        static string DecToBinary(int z)
        {
            string binary = Convert.ToString(z, 2);
            return binary;
        }
        //Convert Binary to Decimal
        static int BinaryToDec(string z)
        {
            int dec = Convert.ToInt32(z, 2);;
            return dec;
        }
        //Convert to Decimal to Hexadecimal
        static string DecToHex(int z)
        {
            string hexadecimal = z.ToString("X");
            return hexadecimal;
        }
        //Convert Hexadecimal to Decimal
        static int HexToDex(string z)
        {
            int dec = Convert.ToInt32(z, 16);
            return dec;
        }
        //Convert to Binary to Sign Exponent Mantissa
        static float BinaryToSEM(string z)
        {
            int sem = Convert.ToInt32(z, 2);
            return BitConverter.ToSingle(BitConverter.GetBytes(sem), 0);
        }
        //Convert to Sign Exponent Mantissa to Binary
        static string SEMToBinary(float z)
        {
            const int bitCount = sizeof(float) * 8;
            int bin = System.BitConverter.ToInt32(BitConverter.GetBytes(z), 0);
            return Convert.ToString(bin, 2).PadLeft(bitCount, '0');
        }
        //Do the required math operation
        static float MathOperation(int x, int y, char op)
        {
            if (op == '+')
                return (x + y);
            else if (op == '-')
                return (x - y);
            else if (op == '*')
                return (x * y);
            else
                return 0;
        }        
    }
}
