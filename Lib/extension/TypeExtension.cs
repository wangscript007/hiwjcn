﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lib.extension
{
    /// <summary>
    /// BaseType是类
    /// GetInterfaces是接口
    /// IsGenericType是泛型
    /// GetGenericTypeDefinition()获取泛型类型比如Consumer<string>
    /// </summary>
    public static class TypeExtension
    {
        public static List<Type> FindTypesByBaseType<T>(this Assembly a)
        {
            return a.GetTypes().Where(x => x.BaseType != null && x.BaseType == typeof(T)).ToList();
        }

        /// <summary>
        /// 是否可以赋值给
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsAssignableTo_<T>(this Type t)
        {
            return typeof(T).IsAssignableFrom(t);
        }

        /// <summary>
        /// 非抽象类
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsNormalClass(this Type t)
        {
            return t.IsClass && !t.IsAbstract;
        }

        /// <summary>
        /// 是指定的泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsGenericType_<T>(this Type t)
        {
            return t.IsGenericType_(typeof(T));
        }

        /// <summary>
        /// 是指定的泛型
        /// </summary>
        /// <param name="t"></param>
        /// <param name="tt"></param>
        /// <returns></returns>
        public static bool IsGenericType_(this Type t, Type tt)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == tt;
        }
    }
}
