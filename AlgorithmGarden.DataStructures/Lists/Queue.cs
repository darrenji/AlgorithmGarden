using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.DataStructures.Lists
{
    public class ArrayQueue
    {
        private string[] items;
        private int n = 0; //容量
        private int head = 0;//队列的第一个，这是一个游标，会变化
        private int tail = 0; //队列的最后一个,这是一个游标，会变化

        public ArrayQueue(int capacity)
        {
            n = capacity;
            items = new string[capacity];
        }

        public bool Enqueue(string item)
        {
            //入队列的时候要看队列的最后一个有没有超出容量
            if(tail==n) //tai表示下标，一般比n小一个，如果和n相等就代表超出了，这个条件找得很好
            {
                return false;
            }
            items[tail] = item;
            ++tail;
            return true;
        }

        /// <summary>
        /// 解决游标到最后一位无法添加的情况
        /// 进行依次搬移工作，只进行一次哦
        /// 时间复杂度感觉还是O(1)，唯一的一次搬移工作可以均摊到其它O(1)上
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Enqueue1(string item)
        {
            if(tail==n) //表示游标已经到最后一位了
            {
                //表示整个队列都已经占满了
                if (head == 0) return false; 

                for(int i= head; i<tail;i++)
                {
                    items[i - head] = items[i];
                }

                //搬完之后重新定义游标
                tail -= head;
                head = 0;
            }

            items[tail] = item;
            ++tail;
            return true;
        }

        /// <summary>
        /// 出队列，时间复杂度是O(1)
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            //考虑队列为空的时候是什么状况？
            //head这个游标和tail游标相等了
            //大多数情况，即队列不为空的时候，head的值小于tail的值
            if (head == tail) return null;
            string ret = items[head];
            ++head;
            return ret;
        }
    }

    public class CircularQueue
    {
        private string[] items;
        private int n = 0;
        private int head = 0;
        private int tail = 0;

        public CircularQueue(int capacity)
        {
            items = new string[capacity];
            n = capacity;
        }

        public bool Enqueue(string item)
        {
            //判断队列满吗？
            if ((tail + 1) % n == head) return false;
            items[tail] = item;
            tail = (tail + 1) % n;
            return true;
        }

        public string Dequeue()
        {
            if (head == tail) return null;
            string ret = items[head];
            head = (head + 1) % n;
            return ret;
        }
    }

    //假设一个队列由8个元素
    //现在a,b,c,d依次进入队列
    // 0 a head
    // 1 b
    // 2 c
    // 3 d
    // 4 tail
    // 5
    // 6
    // 7

    //这时，a,b出列
    // 0
    // 1
    // 2 c head
    // 3 d
    // 4 tail
    // 5
    // 6
    // 7

    //随着不断进入队列，tail的位置不断向下
    //随着不断出列，head的位置也不断向下
    //当tail来到7号位，即使队列中还有空闲的空间，也无法继续向队列中添加数据了
    //所以在入队的时候，当不能再添加数据的时候，需要让数据做一下搬移工作，好腾出空间给其它后续的入队项 见Enqueue1


    //TODO:基于链表的队列

    //循环队列
    //8个元素的循环队列，位置序号依次是0，1，2，3，4，5，6，7连接起来成为一个圆
    //0
    //1
    //2
    //3
    //4 h head
    //5 i
    //6 j
    //7   tail
    //现在a入栈，放入到7
    //把tail指向到0
    //0   tail
    //1
    //2
    //3
    //4 h head
    //5 i
    //6 j
    //7 a
    //现在b入栈，放入到0
    //0 b
    //1   tail
    //2
    //3
    //4 h head
    //5 i
    //6 j
    //7 a
    //这样就没有数据搬移工作了
    //在非循环队列中，队列满tail=n,队列空head=tail
    //队列满(tail+1)%n=head,队列空head=tail


    //阻塞队列
    //当对列为空的时候，从队列头取数据会被阻塞
    //当队列已满，插入数据会被阻塞
    //适合生产消费模型
    //当生产者生产数据过快，消费者来不及消费的时候，队列满着，生产者阻塞等待
    //还可以增加消费者消费队列

    //并发队列
    //线程安全的队列叫并发队列
    //最简单的做法是再enqueue,dequeue上加锁，但是这样做导致无法处理并发
    //基于数组的循环队列+CAS原子操作=高效的并发队列
    //Disruptor用到了并发队列

    //CPU的资源是有限的
    //过多的线程会导致CPU频繁在线程之间切换
    //线程池是很好的做法
    //线程池就是用队列来实现的
    //当线程池没有多余线程时，新的任务请求过来，线程池该如何处理呢？
}
