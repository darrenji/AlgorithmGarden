using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algorithms.Common
{
    //假设有n个台阶，每次跨1个或2个台阶，这n个台阶有多少种走法？
    //问题可以提炼为：f(n)，意思是给你n个台阶，通过神奇的计算，你给我多少种走法
    //不考虑那么多，先只考虑第一步
    //如果第一步跨一个台阶，后面的可能性是：f(n-1)
    //如果第一步跨两个台阶，后面的可能性是：f(n-2)
    //所以，f(n)= f(n-1) + f(n-2)
    //找出了公式，还需要考虑终止条件，或者说特例
    //当n=1, f(1) = f(0) + f(1-2),显然这个公式不太符合n-1的情况
    //所以，f(1)=1
    //当n=2,f(2) = f(2-1) + f(2-2),也就是f(2)=f(1) + f(0),因为知道2个台阶就2种走法，上面f(1)=1,于是2=1+f(0),也就是f(0)=1,理解下来就是当有0个台阶的时候有一种走法，这显然不符合逻辑
    //所以n=2的时候也指望不上这个公司，干脆：f(2)=2
    //当n=3，f(3) = f(3-1) + f(3-2),公式比较吻合
    //好了，总结下来就是：
    //f(1) = 1; //一个台阶的时候1种走法
    //f(2) = 2; //两个台阶的时候2种走法
    //f(n) = f(n-1) + f(n-2)

    public class RecursionHelper
    {
        /// <summary>
        /// 爬n个台阶多少种走法
        /// </summary>
        /// <param name="n">n个台阶</param>
        /// <returns></returns>
        public int FindPossibilitiesWhenClimb(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            return FindPossibilitiesWhenClimb(n - 1) + FindPossibilitiesWhenClimb(n - 2);
        }

        //以上的写法会有一个问题需要解决
        //f(5) = f(3) + f(4)
        //f(4) = f(3) + f(2)
        //多次用到了f(3)
        //可以把f(3)的结果放在一个散列表里
        public IDictionary<int, int> HasSolvedList { get; set; }

        //考虑重复计算的做法
        public int FindPossibilitiesWhenClimb1(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            if (HasSolvedList.Keys.Contains(n))
            {
                int temp;
                if (HasSolvedList.TryGetValue(n, out temp))
                {
                    return temp;
                }
            }

            int ret = FindPossibilitiesWhenClimb1(n - 1) + FindPossibilitiesWhenClimb1(n-2);
            HasSolvedList.Add(n, ret);
            return ret;
        }

        //不用递归的写法
        public int FindPossibilitiesWhenClimb2(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            int result = 0;
            int pre = 2; //上一种可能的数目
            int prepre = 1; //上上一种可能的数目
            for(int i=3; i <= n; i++)
            {
                //每次遍历，实际是最后一步，结算前面所有的可能
                result = pre + prepre;
                prepre = pre; //这里的上一次就变成下一次的上上一次
                pre = result; //这里的记过就变成下一次的上一次
            }
            return result;
        }
    }

    //先想第一步，找出递归公式，然后考虑特殊情况
    //递归使用得不好会造成堆栈溢出
    //调用函数得时候会把变量保存在栈里
    //确切的说法是把临时变量封装为栈帧压入内存栈
    //函数执行完毕，栈帧出栈
    //系统栈、有些虚拟机的栈空间一般不大，如果递归很深，就意味着一致有栈帧入栈，就会有栈溢出的风险

    //如何避免堆栈溢出呢？

    //假设去电影院看电影，坐在某一排，当你不知道到底是第几排？
    //然后你问前面的那个人，只要知道前面那个是第几排，我就可以知道自己第几排了
    //前面这个人也有可能也不知道是第几排，他再去问他前面的这个人，于是递归出现了，直到问到第一个人
    //f(n) = f(n-1) + 1


    public class RecursionHelper2
    {
        int depth = 0;

        public int FindRow(int n)
        {
            //每遍历一次变量自增1，防止堆栈溢出
            ++depth;

            //递归的深度和当前线程剩余的栈空间有关
            //线程栈的空间又无法事先计算
            if (depth > 100) throw new StackOverflowException("递归层次过深");

            //处理终止条件
            if (n == 1) return 1;

            return FindRow(n - 1) + 1;
        }

        //可不可以不用递归呢？
        //可以的
        public int FindRow1(int n)
        {
            int result = 1;
            for(int i=2; i <= n; i++)
            {
                result = result + 1;
            }
            return result;
        }
    }

    //递归表达起来很简洁
    //但也又不足之处：空间复杂度高，有堆栈溢出的风险，存在重复计算的可能，过多的函数调用会耗时很多

    //模拟一个推荐
    public class RecursionPerson
    {
        public int actor_id { get; set; }
        public int? referer_id { get; set; }
    }

    public class RecursionPersonHelper
    {
        private List<RecursionPerson> persons = new List<RecursionPerson>
        {
            new RecursionPerson{actor_id=1, referer_id=null},
            new RecursionPerson{actor_id=2, referer_id=1},
            new RecursionPerson{actor_id=3, referer_id=2}
        };

        public int FindRootRefererId(int actorId)
        {
            //先找到当前的actor
            var actor = persons.Find(t => t.actor_id == actorId);
            if (actor == null) return actor.actor_id;
            return FindRootRefererId(actor.referer_id.Value);
        }
    }

    //如何防止无限递归呢？
    //比如在开发的时候，人为插入一些数据，比如A推荐B，B推荐C，C推荐A，造成无限递归了
    //如何监测环的存在呢？

    //编写递归不能把自己绕进去，没必要过分关注细节
    //一步一步地想，想出公式，排除特殊条件

    //IDE的单步调试实际也是递归
    //但是递归很深的时候，就无法使用这种调试方式了，如何解决呢？
    //打印日志发现递归值，结合条件断点调试。

}
