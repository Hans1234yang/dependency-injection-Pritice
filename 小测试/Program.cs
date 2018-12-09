using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
namespace 小测试
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建容器
            UnityContainer container = new UnityContainer();

            //2.向容器中注册类和接口
            container.RegisterType<IPerson,CityMan>();

            container.RegisterType<IFood,Apple>();
            //3.获取实例
            var cityMan = container.Resolve<IPerson>();

            cityMan.Eat();
            Console.ReadLine();
        }
    }

    public interface IFood
    {
        string GetFood();
    }

    public class Apple : IFood
    {
        public string GetFood()
        {
            return "两个苹果";
        }
    }

    public interface IPerson
    {
        void Eat();
    }

    public class CityMan : IPerson         ///人不依赖 食物的类，而是依赖食物的接口
    {
        public IFood _food;
        public CityMan(IFood food)
        {
            _food = food;
        }
        public void Eat()
        {
           string result=  _food.GetFood();
            Console.WriteLine($"我想吃{result}");
        }
    }
}
