﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Maths
{
    /*
    余数

    今天是星期一，20天后是星期几？
    --20/7余6，所以20天后是星期天。

    有100条数据，每页18条，总共多少页？

    为什么发明余数？
    --让数在一个边界内。
    --把余数是一样的归类到一起，就有了"同余定理"。
    --a和b除以正整数m得到的余数相同，a和b对于模m同余。
    --所有的偶数余0，所有的奇数余1

    哈希Hash,散列
    --将任意长度的输入通过哈希算法压缩成固定长度
    --数据库中的索引就是哈希值

    如何把100条数据放到100个不连续内存空间？
    --f(x)=要存的数值 mod 有限存储空间的大小
    --f(x)=x mod 100
    --得到的余数从1到99，把余1的放到第一个空间里，把余99的放到第99个空间里
    --还可以增加散列的随机程度：f(x)=(x+MAX) mode 100
    --更加随机，就像洗牌的应用场景

    加密算法中引入MAX随机数，增强保密程度
    --每一位加上一个MAX随机数
    --每一位除以7得到的余数放在每一位上
    --把123位置顺序颠倒
    */
}