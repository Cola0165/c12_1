using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace c12_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //指定目录的路径
            string path = @"C:\CrtDire123";
            try
            {
                //判断目录是否存在
                if (!Directory.Exists(path))
                {
                    //如果不存在则创建目录
                    Directory.CreateDirectory(path);
                    Console.WriteLine("创建目录成功");
                }
                else
                {
                    //如果目录存在，则删除该目录
                    Directory.Delete(path,true );
                    //Directory.Delete(path);
                    Console.WriteLine("删除目录成功");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("处理过程失败：{0}", e.ToString());
            }
            finally { }
            Console.Read();
        }
    }
}
