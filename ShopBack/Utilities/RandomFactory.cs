using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.Utilities
{
    /// <summary>
    /// 随机生成唯一的字符串
    /// </summary>
    public static class RandomFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intLength">字符串的长度</param>
        /// <param name="boolNumber">是否有数字</param>
        /// <param name="boolSign">是否有符号</param>
        /// <param name="boolSmallWord">是否有小写字符</param>
        /// <param name="boolBigWord">是否有大写字符</param>
        /// <param name="extensiveCodes">已经存在的Codes</param>
        /// <returns></returns>
        public static string GetRandomizer(int intLength, bool boolNumber = true, bool boolSign = true, bool boolSmallWord = true, bool boolBigWord = true, ICollection<string> extensiveCodes = null)
        {
            //定义  
            Random ranA = new Random();
            int intResultRound = 0;
            int intA = 0;
            string strB = "";

            do
            {
                while (intResultRound < intLength)
                {
                    //生成随机数A，表示生成类型  
                    //1=数字，2=符号，3=小写字母，4=大写字母  

                    intA = ranA.Next(1, 5);

                    //如果随机数A=1，则运行生成数字  
                    //生成随机数A，范围在0-10  
                    //把随机数A，转成字符  
                    //生成完，位数+1，字符串累加，结束本次循环  

                    if (intA == 1 && boolNumber)
                    {
                        intA = ranA.Next(0, 10);
                        strB = intA.ToString() + strB;
                        intResultRound = intResultRound + 1;
                        continue;
                    }

                    //如果随机数A=2，则运行生成符号  
                    //生成随机数A，表示生成值域  
                    //1：33-47值域，2：58-64值域，3：91-96值域，4：123-126值域  

                    if (intA == 2 && boolSign == true)
                    {
                        intA = ranA.Next(1, 5);

                        //如果A=1  
                        //生成随机数A，33-47的Ascii码  
                        //把随机数A，转成字符  
                        //生成完，位数+1，字符串累加，结束本次循环  

                        if (intA == 1)
                        {
                            intA = ranA.Next(33, 48);
                            strB = ((char)intA).ToString() + strB;
                            intResultRound = intResultRound + 1;
                            continue;
                        }

                        //如果A=2  
                        //生成随机数A，58-64的Ascii码  
                        //把随机数A，转成字符  
                        //生成完，位数+1，字符串累加，结束本次循环  

                        if (intA == 2)
                        {
                            intA = ranA.Next(58, 65);
                            strB = ((char)intA).ToString() + strB;
                            intResultRound = intResultRound + 1;
                            continue;
                        }

                        //如果A=3  
                        //生成随机数A，91-96的Ascii码  
                        //把随机数A，转成字符  
                        //生成完，位数+1，字符串累加，结束本次循环  

                        if (intA == 3)
                        {
                            intA = ranA.Next(91, 97);
                            strB = ((char)intA).ToString() + strB;
                            intResultRound = intResultRound + 1;
                            continue;
                        }

                        //如果A=4  
                        //生成随机数A，123-126的Ascii码  
                        //把随机数A，转成字符  
                        //生成完，位数+1，字符串累加，结束本次循环  

                        if (intA == 4)
                        {
                            intA = ranA.Next(123, 127);
                            strB = ((char)intA).ToString() + strB;
                            intResultRound = intResultRound + 1;
                            continue;
                        }

                    }

                    //如果随机数A=3，则运行生成小写字母  
                    //生成随机数A，范围在97-122  
                    //把随机数A，转成字符  
                    //生成完，位数+1，字符串累加，结束本次循环  

                    if (intA == 3 && boolSmallWord == true)
                    {
                        intA = ranA.Next(97, 123);
                        strB = ((char)intA).ToString() + strB;
                        intResultRound = intResultRound + 1;
                        continue;
                    }

                    //如果随机数A=4，则运行生成大写字母  
                    //生成随机数A，范围在65-90  
                    //把随机数A，转成字符  
                    //生成完，位数+1，字符串累加，结束本次循环  

                    if (intA == 4 && boolBigWord == true)
                    {
                        intA = ranA.Next(65, 89);
                        strB = ((char)intA).ToString() + strB;
                        intResultRound = intResultRound + 1;
                        continue;
                    }
                }
            } while (extensiveCodes != null && extensiveCodes.Any(q => q == strB));

            return strB;
        }
    }
}
