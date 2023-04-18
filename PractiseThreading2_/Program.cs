using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PractiseThreading2_
{
    class Bank
    {
        private int money;
        private string name;
        private int percent;
        public Bank(int money, string name, int percent)
        {
            this.money = money;
            this.name = name;
            this.percent = percent;
        }
        public void SetMoney(int money)
        {
            this.money = money;
            Thread th = new Thread(new ThreadStart(FileWrite));
            th.IsBackground = true;
            th.Start();
        }
        public void SetName(string name)
        {
            this.name = name;
            Thread th = new Thread(new ThreadStart(FileWrite));
            th.IsBackground = true;
            th.Start();
        }
        public void SetPercent(int percent)
        {
            this.percent = percent;
            Thread th = new Thread(new ThreadStart(FileWrite));
            th.IsBackground = true;
            th.Start();
        }
        private void FileWrite()
        {
            StreamWriter writer = new StreamWriter("subj.txt", false);
            writer.WriteLine("Money - " + money + "\nName - " + name + "\nPercent - "+ percent);
            writer.Close();
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Bank bank = new Bank(500, "Privat", 15);
                bank.SetMoney(800);
                bank.SetPercent(12);
                bank.SetName("Monobank");

            }
        }
    }
}
