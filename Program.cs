using System;

namespace _3
{
    class Program
    {
        static string Circle(string s)
        {
            for (int a = 0; a < 2; a++)
                s = s.Remove(0, s.IndexOf(" ") + 1);
            return (s);
        }
        static string Rectangle(string s)
        {
            int x1 = -20000;
            int y1 = -20000;
            int x2 = 20000;
            int y2 = 20000;
            s = s.Remove(0, s.IndexOf(" ") + 1);
            for (int a=0;a<4;a++)
            {
                if (int.Parse(s.Substring(0, s.IndexOf(" "))) >= x1)
                {
                    x1 = int.Parse(s.Substring(0, s.IndexOf(" ")));
                    if(a==0)
                        x2 = int.Parse(s.Substring(0, s.IndexOf(" ")));
                    s = s.Remove(0, s.IndexOf(" ") + 1);
                }
                else
                {
                    x2 = int.Parse(s.Substring(0, s.IndexOf(" ")));
                    s = s.Remove(0, s.IndexOf(" ") + 1);
                }
                if (int.Parse(s.Substring(0, s.IndexOf(" "))) >= y1)
                {
                    y1 = int.Parse(s.Substring(0, s.IndexOf(" ")));
                    if (a == 0)
                        y2 = int.Parse(s.Substring(0, s.IndexOf(" ")));
                    s = s.Remove(0, s.IndexOf(" ") + 1);
                }
                else
                {
                    y2 = int.Parse(s.Substring(0, s.IndexOf(" ")));
                    s = s.Remove(0, s.IndexOf(" ") + 1);
                }
            }
            int x = x1 - x2;
            int y = y1 - y2;
            return ((x1-((double)x/2)).ToString()+" "+ (y1 - ((double)y / 2)).ToString());
        }
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            string[] a = new string[x];
            double Xright = -20000;
            double Yright = 0;
            double Xleft = 20000;
            double Yleft = 0;
            for (int ac = 0; ac != x; ac++) 
            {
                string s = Console.ReadLine();
                if (s[0].ToString() == "0")
                {
                    a[ac] = Circle(s);
                    if(int.Parse(a[ac].Substring(0,a[ac].IndexOf(" ")))>Xright)
                    {
                        Xright = int.Parse(a[ac].Substring(0, a[ac].IndexOf(" ")));
                        Yright = int.Parse(a[ac].Remove(0, a[ac].IndexOf(" ")));
                    }
                    if (int.Parse(a[ac].Substring(0, a[ac].IndexOf(" "))) < Xleft)
                    {
                        Xleft = int.Parse(a[ac].Substring(0, a[ac].IndexOf(" ")));
                        Yleft = int.Parse(a[ac].Remove(0, a[ac].IndexOf(" ")));
                    }
                }
                else
                {
                    a[ac] = Rectangle(s + " ");
                    if (double.Parse(a[ac].Substring(0, a[ac].IndexOf(" "))) > Xright)
                    {
                        Xright = double.Parse(a[ac].Substring(0, a[ac].IndexOf(" ")));
                        Yright = double.Parse(a[ac].Remove(0, a[ac].IndexOf(" ")));
                    }
                    if (double.Parse(a[ac].Substring(0, a[ac].IndexOf(" "))) < Xleft)
                    {
                        Xleft = double.Parse(a[ac].Substring(0, a[ac].IndexOf(" ")));
                        Yleft = double.Parse(a[ac].Remove(0, a[ac].IndexOf(" ")));
                    }
                }
            }
            int check = 0;
            for (int ac = 0; ac != x; ac++)
            if ((double)((double)Yleft - (double)Yright) * double.Parse(a[ac].Substring(0, a[ac].IndexOf(" "))) + (double)((double)Xright - (double)Xleft) * double.Parse(a[ac].Remove(0, a[ac].IndexOf(" "))) + (double)((double)Xleft * (double)Yright - (double)Xright * (double)Yleft) == 0)
                    check++;
                else
                    break;
            if (check == x)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
