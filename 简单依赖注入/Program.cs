using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace 简单依赖注入
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建容器
            UnityContainer container = new UnityContainer();
            //2. 注册类和 接口
            container.RegisterType<IMyWork,MyWork>();

            //3.从容器中拿类的实例
            var myWork1 = container.Resolve<IMyWork>();
            myWork1.SayHi();
            Console.ReadLine();
        }
    }

    public interface IMyWork
    {
        void SayHi();
    }

    public class MyWork : IMyWork
    {
        public void SayHi()
        {
            Console.WriteLine("你好啊，世界");
        }
    }
}
