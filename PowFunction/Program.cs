using HelperLibrary;


Random rnd = new Random();
//int basis = rnd.Next(0, 10);
int basis = 2;

int[] degrees = new int[50];
for (int i = 0; i <= 49; i++)
{
    degrees[i] = i + 1;
}

string results = "Степень;Кол-во шагов - Pow;Кол-во шагов - RecPow;Кол-во шагов - QuickPow;Кол-во шагов - ClassicQuickPow\n";

foreach (var exponent in degrees)
{
    var stepsPow = Pow(basis, exponent);
    var stepsRecPow = RecPow(basis, exponent).Item2;
    var stepsQuickPow = QuickPow(basis, exponent);
    var stepsClassicQuickPow = ClassicQuickPow(basis, exponent);
    results += $"{exponent};{stepsPow};{stepsRecPow};{stepsQuickPow};{stepsClassicQuickPow}\n";
}

Helper.SaveResults(results);

static int Pow(int x, int n)
    {
        (int result, int countSteps) results = (0, 0);
        results.result = 1;
        int k = 0;
        
        while (k < n)
        {
            results.countSteps++;
            results.result *= x;
            k++;
        }
        
        return results.countSteps;
    }

    static (int, int) RecPow(int x, int n)
    {
        (int result, int countSteps) results = (0,0);

        if (n == 0)
        {
            results.result = 1;
            results.countSteps++;
        }
        else
        {
            results.countSteps++;
            results = RecPow(x, n / 2);
            
            if (n % 2 == 1)
            {
                results.countSteps++;
                results.result = results.result * results.result * x;
            }
            else
            {
                results.countSteps++;
                results.result *= results.result;
            }
        }
        
        return results;
    }

    static int QuickPow(int x, int n)
    {
        (int result, int countSteps) results = (0, 0);

        int c = x;
        
        int k = n;

        if (k % 2 == 1)
        {
            results.result = c;
            results.countSteps++;
        }
        else
        {
            results.result = 1;
            results.countSteps++;
        }
        do
        {
            k /= 2;
            results.countSteps++;
            c *= c;

            if (k % 2 == 1)
            {
                results.result *= c;
                results.countSteps++;
            }
        } while (k != 0);

        
        return results.countSteps;
    }

    static int ClassicQuickPow(int x, int n)
    {
        (int result, int countSteps) results = (0, 0);
        
        int c = x;

        results.result = 1;

        int k = n;

        while (k != 0)
        {
            if (k % 2 == 0)
            {
                results.countSteps++;
                c *= c;
                k /= 2;
            }
            else
            {
                results.countSteps++;
                results.result *= c;
                k -= 1;
            }
        }
        
        return results.countSteps;
    }