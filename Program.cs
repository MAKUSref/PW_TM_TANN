
static float add(int x, int y)
{
    return x+y;
}

static float sub(int x, int y) 
{
    return x-y;
}

static float mul(float x, float y)
{
    if (x == 0 || y == 0)
    {
        return 0;
    }
    else
    {
        return x * y;
    }
}
static float div(float x, float y) 
{
    if(y == 0)
    {
        Console.WriteLine("Nie mozna dzielic przez zero!!");
        return 0;
    }
    else 
    {
        return (x / y);
    }
}
string choice;
Console.WriteLine("Wybierz dzialanie:\n1-Dodawanie\n2-odejmowanie\n3-mnozenie\n4-dzielenie");
Console.WriteLine("Twoj wybor:");
choice = Console.ReadLine();

return 0;