﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algorithms.Others
{
    /*
     零和游戏：一个人的所得需要以另一个人的损失为代价

     冯·诺依曼被后人称为“计算机之父”和“博弈论之父”。
     博弈论是数学和最优化理论上一个非常重要的贡献
     

     很多人宣扬所谓的宇宙丛林法则，不择手段、没有底线地从事最野蛮的商业。
     王石也称"门口的野蛮人"。
     而在自己的亲历的商业中，也目睹了以我为中心利己损人、两败俱伤的情况。
     */

    /*
     非零和游戏：一个人的所得并不需要以另一个人的损失为代价

     囚徒问题：
     一个案子里两个嫌疑犯被分开审讯
     如果一个人招供，另一个人不招供，招供的一方因为提供证据立功只需判1年徒刑，另一个人判10年
     如果两个人都招供，两人都判5年
     如果两个人都不招供，因为没有证据，两个人都会被释放

     通常两个人都会招供，即采用双输策略，这样认为自己的损失会最小。这样的前提是两个人都理性。

     其实，双输策略不见得带来最小损失，可能导致的损失会非常大。

     旅行者困境：
     两位旅客乘坐同一个航班飞机，旅行箱都丢了，两个箱子里都有一个相同的古董，价值一样。
     航公公司让两位旅客分别填古董价格，金额在2-100之间。
     如果两个人填的一样，两人获得一样得赔偿。
     如果两人填的不一样，以低的为准。另外，还会把高的那个拿出2奖励给报价低的那个人。
     假设一个人报价90，另一个报价95，报价低的拿92，报价高的拿88。
     假如两个人都充分信任都写下100，两人都得到100的赔偿。
     但是，为了让自己的利益最大化，会选择不信任，选择打小算盘。
     张三想李四写100，张三写99，最后张三能得到101，李四得到97。
     李四想张三肯定想得到更多，会写99，如果李四写98，李四最后得到100，张三得到96。
     两个人不断勾心斗角，最后来到囚徒问题的均衡点，两个人的损失一点都不少。

     与上面旅行者困境相似的是，很多家长为了让孩子赢在起跑线上，都抢先跑，结果大家都输，也累坏了孩子。

     双输策略建立在理性的基础上。但一旦面临很高的受益，在大受益的刺激下，就会出现不理性。
     比如股市或者某个公司的估值，大家都感觉高，但参与者还是会出高价，因为希望有人出更高的价。这里的不理性体现在不在意损失降到最小，而追求利益最大化。

     生活中大家太理性、太聪明，也会在不自觉地选择双输。

     在博弈中，既会有零和游戏，也会有非零和游戏。在零和游戏中，一输一赢；在非零和游戏中，在理性前提下损失可能最低，但也有可能最大；在非理性情况下，损失可能会更大。
     
     未来：
     最终是一个信任问题，在没有很多信息渠道的时候，不信任产生，都很理性，最后双输。
     如果想获得最大利益就需要合作
     懂得合作是文明最大的进步成果之一
     */
}
