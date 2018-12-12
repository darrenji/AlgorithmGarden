using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Patterns.State
{

    /// <summary>
    /// 上下文保存了当前状态，并提供给外界改变状态的方法
    /// </summary>
    public class Context
    {
        private IState _state;
        public Context(IState state)
        {
            _state = state;
        }

        /// <summary>
        /// 接收外界的请求，让IState自己改变状态
        /// </summary>
        public void Request()
        {
            _state.Handle(this);
        }

        public IState State
        {
            get { return _state; }
            set { _state = value; }
        }
    }

    public interface IState
    {
        void Handle(Context context);
    }

    public class StateA : IState
    {
        /// <summary>
        /// 每一个状态的触发动作会指向下一个动作
        /// </summary>
        /// <param name="context"></param>
        public void Handle(Context context)
        {
            Console.WriteLine("state a");
            context.State = new StateB();
        }
    }

    public class StateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("state b");
            context.State = new StateA();
        }
    }
}
