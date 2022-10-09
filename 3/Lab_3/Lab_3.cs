﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    


    class Lab_3
    {
        public class Date
        {
            public int[] buffer;
        }

        class MySet
        {
            public static void DeletePositiveElements(ref MySet first)
            {
                MySet temp = new MySet();

                for (int i = 0; i < first.items.Length; i++)
                {
                    if(first.items[i] < 0)
                    {
                        temp.Push_Back(first.items[i]);
                    }
                }

                first = temp;
            }

            public int GetFirstElement()
            {
                return this.items[0];
            }

            public static explicit operator Date(MySet first)
            {
                Date temp = new Date();

                temp.buffer = first.items;

                return temp;
            }

            public static MySet operator *(MySet first, MySet second)
            {
                MySet temp = new MySet();

                for (int i = 0; i < first.items.Length; i++)
                {
                    for (int j = 0; j < second.items.Length; j++)
                    {
                        if (first.items[i] == second.items[j])
                        {
                            temp.Push_Back(first.items[i]);
                            break;
                        }
                    }
                }

                return temp;
            }

            public static bool operator >(MySet first, MySet second)
           {
                bool check = false;

                for (int i = 0; i < first.items.Length; i++)
                {
                    for (int j = 0; j < second.items.Length; j++)
                    {
                        if (first.items[i] == second.items[j])
                        {
                            check = true;
                            break;
                        }
                    }

                    if (!check) return false;

                    check = false;
                }

                return true;
           }

            public static bool operator <(MySet first, MySet second)
            {
                if (second > first) return true;

                return false;
            }

            public void Push_Back(int a)
           {
                //базовый случай
                if(!flag)
                {
                    flag = true;

                    items[0] = a;

                    return;
                }

                ////////////////////////////////Проверка на одинаковые элементы///////

                for (int i = 0; i < this.items.Length; i++)
                {
                    if (a == this.items[i]) return;
                }

                //////////////////////////////////////////////////////////////////////
                
                //остальные случаи
                int[] newArr = new int[items.Length + 1];

                for (int i = 0; i < items.Length; i++)
                {
                    newArr[i] = items[i];
                }

                newArr[items.Length] = a;

                items = newArr;
           }

            //для добавления
            public int[] items = {0};
            public bool flag = false;
        }


        static void Main()
        {
            MySet a = new MySet();
            
            a.Push_Back(5);
            a.Push_Back(-6);
            a.Push_Back(38);
            a.Push_Back(-10);
            a.Push_Back(10);

            MySet b = new MySet();

            b.Push_Back(1);
            b.Push_Back(2);
            b.Push_Back(38);
            b.Push_Back(5);

            /////////////////////////////////////////////////////

            Console.WriteLine(a < b);

            MySet c = a * b;

            Date test = new Date();

            test = (Date)a;

            int firstElement = b.GetFirstElement();

            MySet.DeletePositiveElements(ref a);

            Console.ReadKey();
        }
    }
}