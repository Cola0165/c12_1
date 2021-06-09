using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 创建/删除指定目录：xxxxx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                string path = @"C:\CrtDire123";
                try
                {
                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path, true);
                        textBox1.Text = "删除文件夹成功";
                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                        textBox1.Text = "创建文件夹成功";

                    }
                }
                catch (Exception ex)
                {
                    textBox1.Text = ex.Message;
                    //throw;
                }
                finally
                {
                    textBox1.Text += Environment.NewLine + "操作已完成！";
                }
            }
            catch (Exception)
            {

                //throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"c:\0608\FileTest.txt";
                //string path2 = @"c:\temp\NewFileTest.txt";
                if (!File.Exists(path))
                {
                    //Directory.CreateDirectory(@"c:\a");
                    // 创建一个文件用于写入UTF-8编码的文本
                    StreamWriter sw = File.CreateText(path);
                    sw.WriteLine("You");
                    sw.WriteLine("are");
                    sw.WriteLine("Beautiful");
                    //sw.Dispose();
                    sw.Close();
                }
                // 打开文件，从里面读出数据
                StreamReader sr = File.OpenText(path);
                string s = "";
                //输出文件里的内容，直到文件结束
                while ((s = sr.ReadLine()) != null)
                {
                    textBox1.Text += s+Environment.NewLine;
                }
                //sr.Dispose();
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream myFileStream = new FileStream("c:\\BinFile.dat", FileMode.OpenOrCreate);
                FileStream fileStream = new FileStream("c:\\BinFile1.dat", FileMode.OpenOrCreate);
                // 为文件流创建二进制写入器
                BinaryWriter myBinaryWriter = new BinaryWriter(myFileStream);
                // 写入数据
                for (int i = 65; i < 71; i++)
                {
                    myBinaryWriter.Write((char)i);
                }
                myBinaryWriter.Close();
                myFileStream.Close();

                // 创建reader
                myFileStream = new FileStream("c:\\BinFile.dat", FileMode.Open, FileAccess.Read);
                BinaryReader myBinaryReader = new BinaryReader(myFileStream);
                // 从BinFile读数据
                while (myBinaryReader.PeekChar() != -1)
                {
                    textBox1.Text += myBinaryReader.ReadChar().ToString();
                }
                myBinaryReader.Close();
                myFileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
