using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace TryDraw
{
   class Pair
    {

        private double x;
        public double X
        {   
            get {
                return x;
            }
            set {
                x = value;
            }
        }

        private double y;
        public double Y
        {
            get
            {
                return y;
            }
            set
            {

                y = value;
            }
        }
         
        public Pair()
        {
            this.x = 0.0;
            this.y = 0.0;
        }
        public Pair(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

    }

    class ReadData
    {
        
        private string Get_data()
        {
            string path = "test.txt";
            string line = "";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                line = sr.ReadLine();
                Console.WriteLine(line);
            }
            return line;
        }

        public List<Pair> WriteList()
        {
            List<Pair> list = new List<Pair>();
            List<string[]> l = new List<string[]>();
            string str = Get_data();
            str = str.Trim(new char[] { '[', ']' });
            string [] ss = str.Split(new string[] { "][" },StringSplitOptions.None);
            foreach(string s in ss){
               l.Add(s.Split(new char[] { ';' }));
            }
            foreach(string []s in l)
            {
                if (Convert.ToDouble(s[2]) > 8.0)
                {
                    list.Add(new Pair(Convert.ToDouble(s[0]), Convert.ToDouble(s[1])));          
                }
            }
            return list;
        }

    }
}
