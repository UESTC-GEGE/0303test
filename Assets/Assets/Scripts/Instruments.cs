using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Instruments
{
    public class Eppendorf
    {
        public string name;     //EP管显示名称
        public List<string> content = new List<string>();   //EP管内容物名称
        //酶活力初始化，若为-1则不是酶or蛋白，0-100之间则为酶or蛋白
        public float enzyme_activity = -1;
        //酶活力下降率
        public float activity_downrate = 0.01f;
    }
    public class Reagent
    {
        public string name;     //试剂名称

    }
    public class Testtube
    {
        public string name;     //试管显示名称
        public List<string> content = new List<string>();   //试管内容物名称
        //酶活力初始化，若为-1则不是酶or蛋白，0-100之间则为酶or蛋白
        public float enzyme_activity = -1;
        //酶活力下降率
        public float activity_downrate = 0.01f;
    }

    public class ListCompareClass   //列表对比。 
    {
        public static bool ListCompare(List<string> L1, List<string>L2)
        {
            int count = 0;
            if (L1.Count == L2.Count)
            {
                foreach (var item in L2)
                {
                    if (L1.Contains(item))
                    {
                        count += 1;
                    }
                }
                if(L1.Count == count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}