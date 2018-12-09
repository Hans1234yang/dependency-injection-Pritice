using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace 构造函数注入
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer contanier = new UnityContainer();
            //向IOC容器中注册浙江系菜和四川系菜
            contanier.RegisterType<IMess, SiChuanFood>();
            contanier.RegisterType<IMess, ZhengJiangFood>();

            //IOC容器会智能的选择和调用合适的构造函数,以创建依赖的对象,如果被选择的构造函数具有相应的参数,IOC容器在调用构造函数之前会解析注册的依赖关系并自行获得相应的参数。
            //获取可行的参数后,将参数注入到对应的类中
            IEmployee employee = contanier.Resolve<SiChuanEmployee>();
            IEmployee employees = contanier.Resolve<ZheJiangEmployee>();
            employee.EatFood();
            employees.EatFood();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 员工接口,里面包含员工最基本的权利
    /// </summary>
    internal interface IEmployee
    {
        void EatFood();
    }

    /// <summary>
    /// 食堂接口,里面包含食堂最基本的用途
    /// </summary>
    internal interface IMess
    {
        string GetFood();
    }

    /// <summary>
    /// 浙江系菜
    /// </summary>
    internal class ZhengJiangFood : IMess
    {

        public string GetFood()
        {
            return "浙江菜";
        }
    }

    /// <summary>
    /// 四川系菜
    /// </summary>
    internal class SiChuanFood : IMess
    {

        public string GetFood()
        {
            return "四川菜";
        }
    }


    /// <summary>
    /// 四川员工
    /// </summary>
    internal class SiChuanEmployee : IEmployee
    {
        private IMess _mess;

        /// <summary>
        /// 通过构造函数注入食堂接口实例
        /// </summary>
        /// <param name="mess">食堂接口实例</param>
        public SiChuanEmployee(IMess mess)
        {
            this._mess = mess;
        }
        public void EatFood()
        {
            Console.WriteLine("四川人吃" + _mess.GetFood());
        }
    }

    /// <summary>
    /// 浙江员工
    /// </summary>
    internal class ZheJiangEmployee : IEmployee
    {
        private IMess _mess;
        /// <summary>
        /// 通过构造函数注入食堂接口实例
        /// </summary>
        /// <param name="mess">食堂接口实例</param>
        public ZheJiangEmployee(IMess mess)
        {
            this._mess = mess;
        }
        public void EatFood()
        {
            Console.WriteLine("浙江人吃" + _mess.GetFood());
        }
    }
}
