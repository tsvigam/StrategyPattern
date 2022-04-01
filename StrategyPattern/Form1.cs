using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrategyPattern
{
    public partial class Form1 : Form
    {
        Context context;
        public Form1()
        {
            InitializeComponent();
            context = new Context(new NumberStrategy());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                context.SetStrategy(new NumberStrategy());
            }
            if (radioButton2.Checked)
                context.SetStrategy(new LowerStrategy());
            if (radioButton3.Checked)
                context.SetStrategy(new HighStrategy());
            context.ExecuteAlgorithm(textBox1.Text);
        }
    }

    public class Context
    {
        IStrategy strategy;

        public Context(IStrategy s)
        {
            strategy = s;
        }

        public void SetStrategy(IStrategy s)
        {
            strategy = s;
        }

        public void ExecuteAlgorithm(string s)
        {
            strategy.Algorithm(s);

        }
    }

    public interface IStrategy
    {
        void Algorithm(string s);
    }

    public class NumberStrategy : IStrategy
    {
        public void Algorithm(string s)
        {
            if (s == null)
                MessageBox.Show("Input somesing");
            else
            {
                foreach (char c in s)
                {
                    if (!(c >= '0' && c <= '9'))
                    {
                        MessageBox.Show("Not number!");
                        return;
                    }
                }
                MessageBox.Show("True!");
            }
        }
    }

    public class LowerStrategy : IStrategy
    {
        public void Algorithm(string s)
        {
            if (s == null)
                MessageBox.Show("Input somesing");
            else
            {
                foreach (char c in s)
                {
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        MessageBox.Show("Not lower string!");
                        return;
                    }
                }
                MessageBox.Show("True!");
            }
        }
    }

    public class HighStrategy : IStrategy
    {
        public void Algorithm(string s)
        {
            if (s == null)
                MessageBox.Show("Input somesing");
            else
            {
                foreach (char c in s)
                {
                    if (!(c >= 'A' && c <= 'Z'))
                    {
                        MessageBox.Show("Not high string!");
                        return;
                    }
                }
                MessageBox.Show("True!");
            }
        }
    }
}
