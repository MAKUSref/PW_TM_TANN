namespace zadanie0
{
    public class Calculator 
    {
        public float add(float x, float y) { return x + y; }

        public float sub(float x, float y) { return x - y; }

        public float mul(float x, float y) { return x * y; }

        public float div(float x, float y) 
        { 
            if (x == 0) 
            {
                Console.WriteLine("You cannot divide by zero!");
                return 0;
            }
            return x / y;
        }
    }
}