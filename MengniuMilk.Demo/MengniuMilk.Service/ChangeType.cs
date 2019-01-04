using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Service
{
    using System.Data;
    using System.Reflection;
    public class ConvertDatatableToList
    {

        public List<T> ConvertToList<T>(DataTable dt) where T:new ()
        {
            ////定义泛型集合
            //List<T> list = new List<T>();
            ////获取传过来模型的类型
            //Type type = typeof(T);
            ////定义一个临时变量
            //string tempName = string.Empty;
            ////遍历datatable
            //foreach(DataRow dr in dt.Rows)
            //{
            //    //定义一个新的泛型对象，也就是定义传过来的类的对象
            //    T t = new T();
            //    //获得模型的属性
            //    PropertyInfo[] propertys = t.GetType().GetProperties();
            //    foreach(PropertyInfo p in propertys)
            //    {
            //        tempName = p.Name;
            //        if(dt.Columns.Contains(tempName))
            //        {
            //            if(dr[tempName]!=DBNull.Value)
            //            {
            //                p.SetValue(t, System.ConvertDatatableToList.ConvertDatatableToList(dr[tempName], Type.GetType(p.PropertyType.ToString())), null);
            //            }
            //        }
            //    }
            //    list.Add(t);
            //}
            //return list;

           
            
            
            
            // 定义集合
            List<T> list = new List<T>();

            // 获得此模型的类型
            Type type = typeof(T);
            //定义一个临时变量
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行 
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量  
                    //检查DataTable是否包含此列（列名==对象的属性名）    
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter  
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出  
                        //取值  
                        object value = dr[tempName];


                        //如果非空，则赋给对象的属性  
                        if (value != DBNull.Value)
                        {
                            if (pi.GetMethod.ReturnParameter.ParameterType.Name == "Int32")
                            {
                                value = Convert.ToInt32(value);
                            }
                            pi.SetValue(t, value);
                        }
                    }
                }
                //对象添加到泛型集合中
                list.Add(t);
            }
            dt.Clear();
            dt.Dispose();
            return list;
        }
    }
}
