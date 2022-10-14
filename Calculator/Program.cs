using System;

namespace Project
{
    class Program
    {
        static void Main()
        {
            float x, y;
            char operation, again;

            do
            {
                Console.WriteLine("Please type in your first integer: ");
                x = float.Parse(Console.ReadLine());

                Console.WriteLine("Now type in your second integer: ");
                y = float.Parse(Console.ReadLine());

                Console.WriteLine("Type in the operator: +, -, *");
                operation = Convert.ToChar(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("==============================================================================");
                Console.WriteLine("Conversions of first integer: " + x);
                Console.WriteLine("Decimal to Binary: " + DecToBinary(x));
                Console.WriteLine("Binary to Decimal: " + BinaryToDec(DecToBinary(x)));
                Console.WriteLine("Decimal to Hex: " + DecToHex(x));
                Console.WriteLine("Hex to Decimal: " + HexToDex(DecToHex(x)));
                Console.WriteLine("Decimal to Sign Exponent Mantissa: " + FloatToSEM(x));
                Console.WriteLine("Sign Exponent Mantissa to Decimal: " + SEMToFloat(FloatToSEM(x)));
                Console.WriteLine("==============================================================================");
                Console.WriteLine("");

                Console.WriteLine("==============================================================================");
                Console.WriteLine("Conversions of second integer: " + y);
                Console.WriteLine("Decimal to Binary: " + DecToBinary(y));
                Console.WriteLine("Binary to Decimal: " + BinaryToDec(DecToBinary(y)));
                Console.WriteLine("Decimal to Hex: " + DecToHex(y));
                Console.WriteLine("Hex to Decimal: " + HexToDex(DecToHex(y)));
                Console.WriteLine("Decimal to Sign Exponent Mantissa: " + FloatToSEM(y));
                Console.WriteLine("Sign Exponent Mantissa to Decimal: " + SEMToFloat(FloatToSEM(y)));
                Console.WriteLine("==============================================================================");
                Console.WriteLine("");

                Console.WriteLine("==============================================================================");
                Console.WriteLine("Operation result: " + MathOperation(x, y, operation));
                Console.WriteLine("");
                Console.WriteLine("Conversions of result: " + MathOperation(x, y, operation));
                Console.WriteLine("Decimal to Binary: " + DecToBinary(MathOperation(x, y, operation)));
                Console.WriteLine("Binary to Decimal: " + BinaryToDec(DecToBinary(MathOperation(x, y, operation))));
                Console.WriteLine("Decimal to Hex: " + DecToHex(MathOperation(x, y, operation)));
                Console.WriteLine("Hex to Decimal: " + HexToDex(DecToHex(MathOperation(x, y, operation))));
                Console.WriteLine("Decimal to Sign Exponent Mantissa: " + FloatToSEM(MathOperation(x, y, operation)));
                Console.WriteLine("Sign Exponent Mantissa to Decimal: " + SEMToFloat(FloatToSEM(MathOperation(x, y, operation))));
                Console.WriteLine("==============================================================================");
                Console.WriteLine("");

                Console.WriteLine("Would you like to run again? Y/N");
                again = Convert.ToChar(Console.ReadLine());
            }
            while (again == 'y');
        }        
        //Convert to Decimal to Binary
        static string DecToBinary(float z)
        {
            string s = z.ToString("R");
            int myInt;
            bool isNumerical = int.TryParse(s, out myInt);
            if (isNumerical)
            {
                return Convert.ToString(myInt, 2);
            }
            else
            {
                return "Cannot convert " + s ;
            }
        }
        //Convert Binary to Decimal
        static string BinaryToDec(string z)
        {
            if (z.Contains(".")){
                return z;
            }
            else
            {
                int myInt = Convert.ToInt32(z, 2);
                return myInt.ToString();
            }
        }
        //Convert to Decimal to Hexadecimal
        static string DecToHex(float z)
        {
            var bytes = BitConverter.GetBytes(z);
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
        //Convert Hexadecimal to Decimal
        static float HexToDex(string z)
        {
            byte[] data = new byte[z.Length / 2];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Convert.ToByte(z.Substring(i * 2, 2), 16);
            }
            return BitConverter.ToSingle(data, 0);
        }
        //Convert to Binary to Sign Exponent Mantissa
        static string FloatToSEM(float z)
        {         
            const int bitCount = sizeof(float) * 8;
            int bin = System.BitConverter.ToInt32(BitConverter.GetBytes(z), 0);
            return Convert.ToString(bin, 2).PadLeft(bitCount, '0');
        }
        //Convert to Sign Exponent Mantissa to Binary
        static float SEMToFloat(string z)
        {
            int sem = Convert.ToInt32(z, 2);
            return BitConverter.ToSingle(BitConverter.GetBytes(sem), 0);
        }
        //Do the required math operation
        static float MathOperation(float x, float y, char op)
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
