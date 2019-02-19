using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zamarkakonzola
{
    class Program
    {
        static int[,] matrica;
        static int n, da;
        static void Main(string[] args)
        {
            do
            {
                //n = Convert.ToInt32(Console.ReadLine());
                //UzastopniBrojevi();
                //Piramida();
                //Matrica();
                //IspraviMatricu();
                //Zadatak();
                //SavrsenBroj();
                //Matrica2();
                //IspraviMatricu2();
                //PolovinaMatrice();
                //NajveciUnetiBroj();
                //NajmanjiBrojnapravljenodunetogbroja();
                //Oduzmijedanodcetvorocifrenog();
                //RastuceOpadajuceiliAlternirajuceCifre();
                //Simsznak();
                Blabla();
            }
            while (true);
        }
        static void UzastopniBrojevi()
        {
            string brojevi = null;
            for (int i = 100; i <= 999; i++)
            {
                int a = i / 100;
                int b = (i / 10) % 10;
                int c = i % 10;
                if ((b == a + 1 && c == b + 1) || (c == a + 1 && b == c + 1) || (a == b + 1 && c == a + 1) || (c == b + 1 && a == c + 1) || (a == c + 1 && b == a + 1) || (b == c + 1 && a == b + 1)) brojevi += i + ", ";
            }

            Console.WriteLine(brojevi);
        }
        static void Piramida()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                    Console.Write(" ");
                Console.Write("*");
                for (int j = 1; j <= n-i; j++)
                    Console.Write("-*");
                Console.WriteLine();
            }
        }
        static void Matrica()
        {
            int pocetak = 1;
            matrica = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int broj = Convert.ToInt32(Console.ReadLine());
                    if (pocetak == 0)
                    {
                        for (int q = 0; q < i; q++)
                        {
                            if (matrica[q, j] == broj)
                            {
                                matrica[i, j] = 0; break;
                            }
                            else matrica[i, j] = broj;
                        }
                    }
                    else matrica[i, j] = broj;
                }
                pocetak = 0;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrica[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        static void IspraviMatricu()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrica[i, j] == 0)
                    {
                        int najvecineparni = 0;
                        for (int p = 0; p < n; p++)
                            if (matrica[p, j] % 2 == 1)
                            {
                                int pom = matrica[p, j];
                                if (najvecineparni < pom) najvecineparni = pom;
                            }
                        matrica[i, j] = najvecineparni;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrica[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        static void Zadatak()
        {
            int p = 0;
            int[] niz = new int[10];
            int[][] mat = {
                new int[] { 1, 2, 5, 3, 5 },
                new int[] { 0, 8, 0, 0, 6 },
                new int[] { 2, 4, 0, 0, 8 },
                new int[] { 3, 0, 7, 8, 2 },
                new int[] { 4, 8, 0, 9, 3 }
            };

            for (int i = 1; i < 5; i++)
            {
                for (int j = 5 - i; j < 5; j++)
                {
                    niz[p] = mat[i][j];
                    p++;
                }
            }
            for (int z = 0; z < 10; z++)
            {
                Console.Write(niz[z] + ", ");
            }
            int[] nizb = new int[10];
            int nizbduzina = 1;
            nizb[0] = niz[0];
            int ponavlja = 0, pomeraj = 0;
            for (int i = 1; i < 10; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (niz[i] == niz[j])
                    {
                        ponavlja++;
                        pomeraj++;
                        break;
                    }
                }
                if (ponavlja == 0)
                {
                    nizb[i - pomeraj] = niz[i];
                    nizbduzina++;
                }
                ponavlja = 0;
            }
            Console.WriteLine();
            for (int z = 0; z < nizbduzina; z++)
            {
                Console.Write(nizb[z] + ", ");
            }
        }
        static void SavrsenBroj()
        {

            for (int i = 1; i <= n; i++)
            {
                int pom = 0;
                for (int j = 1; j <= i / 2; j++)
                {
                    if (i % j == 0) pom += j;
                }
                if (pom == i) Console.Write(i + ", ");
            }

        }
        static void Matrica2()
        {
            int pocetak = 1;
            matrica = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int broj = Convert.ToInt32(Console.ReadLine());
                    if (j != 0) pocetak = 0;
                    else pocetak = 1;
                    if (pocetak == 0)
                    {
                        for (int q = 0; q < j; q++)
                        {
                            if (matrica[i, q] == broj)
                            {
                                matrica[i, j] = -1; break;
                            }
                            else matrica[i, j] = broj;
                        }
                    }
                    else matrica[i, j] = broj;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrica[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        static void IspraviMatricu2()
        {
            int ovajbroj = matrica[n / 2, n / 2];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrica[i, j] == -1)
                        if (ovajbroj == -1) matrica[i, j] = 0;
                        else matrica[i, j] = ovajbroj;
                }
            }
            matrica[n / 2, n / 2] = ovajbroj;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrica[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        static void PolovinaMatrice()
        {
            int p = 0;
            int[] niz = new int[10];
            int[][] mat = {
                new int[] { 1, 2, 5, 0, 7 },
                new int[] { 4, 8, 0, 0, 6 },
                new int[] { 2, 4, -1, 1, 0 },
                new int[] { 3, 4, 7, 8, 2 },
                new int[] { 1, 8, 0, 9, 3 }
            };
            for (int i = 3; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    niz[p] = mat[i][j];
                    p++;
                }
            }
            for (int z = 0; z < p; z++)
            {
                Console.Write(niz[z] + ", ");
            }
        }
        static void UnetiBroj()
        {
            int p = 0;
            int neopadajuci = 1;
            int provera = n;
            do
            {
                p++;
                provera /= 10;
            }
            while (provera > 0);
            int[] niz = new int[p];
            provera = n;
            for (int z = p - 1; z >= 0; z--)
            {
                if (provera > 0)
                {
                    niz[z] = provera % 10;
                    provera /= 10;
                }
            }
            for (int i = 0; i < p - 1; i++)
            {
                if (neopadajuci == 0) break;
                for (int j = i + 1; j < p; j++)
                {
                    if (niz[i] >= niz[j]) neopadajuci = 1;
                    else
                    {
                        neopadajuci = 0;
                        break;
                    }
                }
            }
            if (neopadajuci == 1) da = 1;
            else da = 0;

        }
        static void NajveciUnetiBroj()
        {
            int pom = 0;
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                UnetiBroj();
                if (da == 1 && pom < n) pom = n;
            }
            while (n != 0);
            Console.WriteLine("Najveci je: " + pom);
        }
        static void NajmanjiBrojnapravljenodunetogbroja()
        {
            int a, b, c, max, mid = 0, min;
            n = Convert.ToInt32(Console.ReadLine());
            if (n < 100 || n > 999) Console.WriteLine("-1");
            else
            {
                a = n / 100;
                b = n % 10;
                c = (n / 10) % 10;

                max = a;
                min = a;
                if (b > max)
                    max = b;
                if (c > max)
                    max = c;
                if (b < min)
                    min = b;
                if (c < min)
                    min = c;
                if (max == a && min == b)
                    mid = c;
                if (max == b && min == c)
                    mid = a;
                if (max == a && min == c)
                    mid = b;

                min = a;
                if (b < min)
                {
                    mid = min;
                    min = b;
                }
                else
                    mid = b;

                if (c < min)
                {
                    max = mid;
                    mid = min;
                    min = c;
                }
                else if (c < mid)
                {
                    max = mid;
                    mid = c;
                }
                else
                    max = c;

                int p = min * 100 + mid * 10 + max;
                Console.WriteLine(p);
            }
        }
        static void Oduzmijedanodcetvorocifrenog()
        {
            int a, b, c, d, s;
            n = Convert.ToInt32(Console.ReadLine());
            if (n < 1000 || n > 9999) Console.WriteLine("-1");
            else
            {
                a = n / 1000;
                b = (n / 100) % 10;
                c = (n / 10) % 10;
                d = n % 10;
                if (a % 2 == 1) a--;
                if (b % 2 == 1) b--;
                if (c % 2 == 1) c--;
                if (d % 2 == 1) d--;
                s = 1000 * a + 100 * b + 10 * c + d;
                Console.WriteLine(s);
            }
        }
        static void RastuceOpadajuceiliAlternirajuceCifre()
        {
            int a, b, c, d, e, s;
            n = Convert.ToInt32(Console.ReadLine());
            if (n < 10000 || n > 99999) Console.WriteLine("-1");
            else
            {
                a = n / 10000;
                b = (n / 1000) % 10;
                c = (n / 100) % 10;
                d = (n / 10) % 10;
                e = n % 10;
                if ((a < b && b < c && c < d && d < e) || (e < d && d < c && c < b && b < a))
                {
                    s = a + b + c + d + e;
                }
                else if ((a < b && b > c && c < d && d > e) || (e > d && d < c && c > b && b < a))
                {
                    s = a * b * c * d * e;
                }
                else s = n;
                Console.WriteLine(s);
            }
        }
        static void Simsznak()
        {
            n = Convert.ToInt32(Console.ReadLine());
            if (n < 1) Console.WriteLine("-1");
            else
            {
                int brojredovaunizu = n;
                int brojchar = 1;
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j < brojredovaunizu; j++) Console.Write(" ");
                    for (int q = 1; q <= brojchar; q++)
                    {
                        if (q == 1 || q == brojchar || q == (brojchar + 1) / 2) Console.Write("*");
                        else Console.Write(" ");
                    }
                    brojchar += 2;
                    brojredovaunizu--;
                    Console.WriteLine();
                }
                brojredovaunizu = 2
;
                brojchar = n * 2 - 3;
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j < brojredovaunizu; j++) Console.Write(" ");
                    for (int q = 1; q <= brojchar; q++)
                    {
                        if (q == 1 || q == brojchar || q == (brojchar + 1) / 2) Console.Write("*");
                        else Console.Write(" ");
                    }
                    brojchar -= 2;
                    brojredovaunizu++;
                    Console.WriteLine();
                }
            }
        }
        static void Blabla()
        {
            int k, i;
            double x, fx;
            x = Convert.ToDouble(Console.ReadLine());
            k = Convert.ToInt32(Console.ReadLine());
            fx = x;
            for (i = 1; i <= k; i++) fx = 2 * Math.Cos(fx) - Math.Pow(fx, 3);
            Console.WriteLine(fx);
        }
    }
}
