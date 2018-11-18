using System;
using System.Collections.Generic;

namespace AlgorithmGarden.LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Node
    {
        public int key { get; set; }
        public int data { get; set; }
        public Node previous { get; set; }
        public Node next { get; set; }
    }

    /// <summary>
    /// Least Recently Used
    /// </summary>
    public class LRUCache
    {
        private int _capacity;
        private Dictionary<int, Node> data;
        private Node head;
        private Node end;

        public LRUCache(int capaicity)
        {
            _capacity = capaicity;
            this.data = new Dictionary<int, Node>();
        }

        /// <summary>
        /// 插入节点到头部
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(Node node)
        {
            //重置需要插入的节点
            node.previous = null;
            node.next = null;

            //如果还没有头部结点，即头部节点为Null
            if(this.head==null)
            {
                this.head = node;
                this.end = node;
                return;
            }

            //如果已经有了头部节点，就把新插入的节点放到最前面
            this.head.previous = node;

            node.next = this.head;
            this.head = node;
        }

        public void RemoveNode(Node node)
        {
            //先考虑没有的情况
            if (this.head == null || node == null) return;

            //如果只剩下最后一个节点了
            if(this.head==this.end&&this.head==node)
            {
                this.head = null;
                this.end = null;
                return;
            }

            //删除头部节点
            if(node==this.head)
            {
                this.head.next.previous = null;
                this.head = this.head.next;
                return;
            }

            //删除尾部节点
            if(node==this.end)
            {
                this.end.previous.next = null;
                this.end = this.end.previous;
                return;
            }

            //其它情况
            node.previous.next = node.next;
            node.next.previous = node.previous;
        }

        /// <summary>
        /// 把一个节点先删除再放到头部
        /// </summary>
        /// <param name="node"></param>
        public void RemoveAndMovieToFirstNode(Node node)
        {
            this.RemoveNode(node);
            this.AddNode(node);
        }

        public void RemoveLastNode()
        {
            this.RemoveNode(this.end);
        }

        /// <summary>
        /// 获取到需要查找的值，并放到缓存链表的最前面
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetNode(int key)
        {
            Node n;
            if(this.data.TryGetValue(key, out n)==true)
            {
                this.RemoveAndMovieToFirstNode(n);
                return n.data;
            }
            else
            {
                return -1;

            }
            
        }

        public void SetNode(int key, int value)
        {
            Node n;
            if(this.data.TryGetValue(key, out n)==true)//如果在字典集中存在
            {
                //放到缓存链表的头部去
                this.RemoveAndMovieToFirstNode(n);
                n.data = value;
                return;
            }

            //超出范围
            if(this.data.Count>=this._capacity)
            {
                int id = this.end.key;

                //同时在字典集和缓存列表里删除
                this.RemoveLastNode();
                this.data.Remove(id);
            }

            //普通情况
            Node node = new Node();
            node.key = key;
            node.data = value;
            this.AddNode(node);
            this.data.Add(key, node);
        }
    }

  
}
