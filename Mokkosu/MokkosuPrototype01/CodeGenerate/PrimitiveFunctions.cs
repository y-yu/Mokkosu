﻿using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Mokkosu.CodeGenerate
{
    static class PrimitiveFunctions
    {
        static MethodInfo _string_equal =
            CodeGeneratorCommon.SystemMethod(
                "mscorlib.dll", "System.String", "Equals",
                new Type[] { typeof(string), typeof(string) });

        static MethodInfo _string_compare =
            CodeGeneratorCommon.SystemMethod(
                "mscorlib.dll", "System.String", "Compare",
                new Type[] { typeof(string), typeof(string) });

        static ConstructorInfo _application_exception =
            CodeGeneratorCommon.SystemConstructor(
                "mscorlib.dll", "System.ApplicationException", 
                new Type[] { typeof(string) });

        static MethodInfo _console_writeln =
            CodeGeneratorCommon.SystemMethod(
                "mscorlib.dll", "System.Console", "WriteLine",
                new Type[] { typeof(object) });

        public static MethodInfo DefinePrintLn(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("println",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object) });
            var il = info.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, _console_writeln);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);
            return info;
        }

        public static MethodInfo DefineAdd(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("add",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });
            var il = info.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);
            return info;
        }

        public static MethodInfo DefineSub(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("sub",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });
            var il = info.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Sub);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);
            return info;
        }

        public static MethodInfo DefineMul(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("mul",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });
            var il = info.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Mul);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);
            return info;
        }

        public static MethodInfo DefineDiv(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("div",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });
            var il = info.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Div);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);
            return info;
        }

        public static MethodInfo DefineEq(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("eq",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });
            
            var il = info.GetILGenerator();

            var lbl1 = il.DefineLabel();
            var lbl2 = il.DefineLabel();
            var lbl3 = il.DefineLabel();
            var lbl4 = il.DefineLabel();
            var lbl5 = il.DefineLabel();
            var lbl6 = il.DefineLabel();
            var lbl7 = il.DefineLabel();
            var lbl8 = il.DefineLabel();
            var lbl9 = il.DefineLabel();
            var lbl10 = il.DefineLabel();

            // int, bool, unit
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(int));
            il.Emit(OpCodes.Brfalse, lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Beq, lbl2);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl3);
            il.MarkLabel(lbl2);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl3);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // char
            il.MarkLabel(lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(char));
            il.Emit(OpCodes.Brfalse, lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Beq, lbl5);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl6);
            il.MarkLabel(lbl5);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl6);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // double
            il.MarkLabel(lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(double));
            il.Emit(OpCodes.Brfalse, lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Beq, lbl8);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl9);
            il.MarkLabel(lbl8);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl9);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // string
            il.MarkLabel(lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(string));
            il.Emit(OpCodes.Brfalse, lbl10);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, _string_equal);
            il.Emit(OpCodes.Box, typeof(int));            
            il.Emit(OpCodes.Ret);

            // その他
            il.MarkLabel(lbl10);
            il.Emit(OpCodes.Ldstr, "比較演算型エラー");
            il.Emit(OpCodes.Newobj, _application_exception);
            il.Emit(OpCodes.Throw);

            return info;
        }

        public static MethodInfo DefineNe(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("ne",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });

            var il = info.GetILGenerator();

            var lbl1 = il.DefineLabel();
            var lbl2 = il.DefineLabel();
            var lbl3 = il.DefineLabel();
            var lbl4 = il.DefineLabel();
            var lbl5 = il.DefineLabel();
            var lbl6 = il.DefineLabel();
            var lbl7 = il.DefineLabel();
            var lbl8 = il.DefineLabel();
            var lbl9 = il.DefineLabel();
            var lbl10 = il.DefineLabel();
            var lbl11 = il.DefineLabel();
            var lbl12 = il.DefineLabel();

            // int, bool, unit
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(int));
            il.Emit(OpCodes.Brfalse, lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Beq, lbl2);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl3);
            il.MarkLabel(lbl2);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl3);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // char
            il.MarkLabel(lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(char));
            il.Emit(OpCodes.Brfalse, lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Beq, lbl5);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl6);
            il.MarkLabel(lbl5);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl6);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // double
            il.MarkLabel(lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(double));
            il.Emit(OpCodes.Brfalse, lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Beq, lbl8);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl9);
            il.MarkLabel(lbl8);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl9);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // string
            il.MarkLabel(lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(string));
            il.Emit(OpCodes.Brfalse, lbl10);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, _string_equal);
            il.Emit(OpCodes.Brtrue, lbl11);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl12);
            il.MarkLabel(lbl11);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl12);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // その他
            il.MarkLabel(lbl10);
            il.Emit(OpCodes.Ldstr, "比較演算型エラー");
            il.Emit(OpCodes.Newobj, _application_exception);
            il.Emit(OpCodes.Throw);

            return info;
        }

        public static MethodInfo DefineLt(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("lt",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });

            var il = info.GetILGenerator();

            var lbl1 = il.DefineLabel();
            var lbl2 = il.DefineLabel();
            var lbl3 = il.DefineLabel();
            var lbl4 = il.DefineLabel();
            var lbl5 = il.DefineLabel();
            var lbl6 = il.DefineLabel();
            var lbl7 = il.DefineLabel();
            var lbl8 = il.DefineLabel();
            var lbl9 = il.DefineLabel();
            var lbl10 = il.DefineLabel();
            var lbl11 = il.DefineLabel();
            var lbl12 = il.DefineLabel();

            // int, bool, unit
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(int));
            il.Emit(OpCodes.Brfalse, lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Blt, lbl2);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl3);
            il.MarkLabel(lbl2);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl3);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // char
            il.MarkLabel(lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(char));
            il.Emit(OpCodes.Brfalse, lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Blt, lbl5);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl6);
            il.MarkLabel(lbl5);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl6);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // double
            il.MarkLabel(lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(double));
            il.Emit(OpCodes.Brfalse, lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Blt, lbl8);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl9);
            il.MarkLabel(lbl8);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl9);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // string
            il.MarkLabel(lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(string));
            il.Emit(OpCodes.Brfalse, lbl10);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, _string_compare);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Blt, lbl11);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl12);
            il.MarkLabel(lbl11);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl12);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // その他
            il.MarkLabel(lbl10);
            il.Emit(OpCodes.Ldstr, "比較演算型エラー");
            il.Emit(OpCodes.Newobj, _application_exception);
            il.Emit(OpCodes.Throw);

            return info;
        }

        public static MethodInfo DefineGt(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("gt",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });

            var il = info.GetILGenerator();

            var lbl1 = il.DefineLabel();
            var lbl2 = il.DefineLabel();
            var lbl3 = il.DefineLabel();
            var lbl4 = il.DefineLabel();
            var lbl5 = il.DefineLabel();
            var lbl6 = il.DefineLabel();
            var lbl7 = il.DefineLabel();
            var lbl8 = il.DefineLabel();
            var lbl9 = il.DefineLabel();
            var lbl10 = il.DefineLabel();
            var lbl11 = il.DefineLabel();
            var lbl12 = il.DefineLabel();

            // int, bool, unit
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(int));
            il.Emit(OpCodes.Brfalse, lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Bgt, lbl2);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl3);
            il.MarkLabel(lbl2);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl3);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // char
            il.MarkLabel(lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(char));
            il.Emit(OpCodes.Brfalse, lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Bgt, lbl5);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl6);
            il.MarkLabel(lbl5);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl6);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // double
            il.MarkLabel(lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(double));
            il.Emit(OpCodes.Brfalse, lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Bgt, lbl8);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl9);
            il.MarkLabel(lbl8);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl9);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // string
            il.MarkLabel(lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(string));
            il.Emit(OpCodes.Brfalse, lbl10);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, _string_compare);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Bgt, lbl11);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Br, lbl12);
            il.MarkLabel(lbl11);
            il.Emit(OpCodes.Ldc_I4_1);
            il.MarkLabel(lbl12);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // その他
            il.MarkLabel(lbl10);
            il.Emit(OpCodes.Ldstr, "比較演算型エラー");
            il.Emit(OpCodes.Newobj, _application_exception);
            il.Emit(OpCodes.Throw);

            return info;
        }

        public static MethodInfo DefineLe(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("le",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });

            var il = info.GetILGenerator();

            var lbl1 = il.DefineLabel();
            var lbl2 = il.DefineLabel();
            var lbl3 = il.DefineLabel();
            var lbl4 = il.DefineLabel();
            var lbl5 = il.DefineLabel();
            var lbl6 = il.DefineLabel();
            var lbl7 = il.DefineLabel();
            var lbl8 = il.DefineLabel();
            var lbl9 = il.DefineLabel();
            var lbl10 = il.DefineLabel();
            var lbl11 = il.DefineLabel();
            var lbl12 = il.DefineLabel();

            // int, bool, unit
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(int));
            il.Emit(OpCodes.Brfalse, lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Bgt, lbl2);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl3);
            il.MarkLabel(lbl2);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl3);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // char
            il.MarkLabel(lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(char));
            il.Emit(OpCodes.Brfalse, lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Bgt, lbl5);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl6);
            il.MarkLabel(lbl5);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl6);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // double
            il.MarkLabel(lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(double));
            il.Emit(OpCodes.Brfalse, lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Bgt, lbl8);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl9);
            il.MarkLabel(lbl8);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl9);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // string
            il.MarkLabel(lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(string));
            il.Emit(OpCodes.Brfalse, lbl10);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, _string_compare);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Bgt, lbl11);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl12);
            il.MarkLabel(lbl11);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl12);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // その他
            il.MarkLabel(lbl10);
            il.Emit(OpCodes.Ldstr, "比較演算型エラー");
            il.Emit(OpCodes.Newobj, _application_exception);
            il.Emit(OpCodes.Throw);

            return info;
        }

        public static MethodInfo DefineGe(TypeBuilder type_builder)
        {
            var info = type_builder.DefineMethod("ge",
                MethodAttributes.Static, typeof(object),
                new Type[] { typeof(object), typeof(object) });

            var il = info.GetILGenerator();

            var lbl1 = il.DefineLabel();
            var lbl2 = il.DefineLabel();
            var lbl3 = il.DefineLabel();
            var lbl4 = il.DefineLabel();
            var lbl5 = il.DefineLabel();
            var lbl6 = il.DefineLabel();
            var lbl7 = il.DefineLabel();
            var lbl8 = il.DefineLabel();
            var lbl9 = il.DefineLabel();
            var lbl10 = il.DefineLabel();
            var lbl11 = il.DefineLabel();
            var lbl12 = il.DefineLabel();

            // int, bool, unit
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(int));
            il.Emit(OpCodes.Brfalse, lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(int));
            il.Emit(OpCodes.Blt, lbl2);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl3);
            il.MarkLabel(lbl2);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl3);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // char
            il.MarkLabel(lbl1);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(char));
            il.Emit(OpCodes.Brfalse, lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(char));
            il.Emit(OpCodes.Blt, lbl5);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl6);
            il.MarkLabel(lbl5);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl6);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // double
            il.MarkLabel(lbl4);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(double));
            il.Emit(OpCodes.Brfalse, lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Unbox_Any, typeof(double));
            il.Emit(OpCodes.Blt, lbl8);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl9);
            il.MarkLabel(lbl8);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl9);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // string
            il.MarkLabel(lbl7);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Isinst, typeof(string));
            il.Emit(OpCodes.Brfalse, lbl10);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, _string_compare);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Blt, lbl11);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Br, lbl12);
            il.MarkLabel(lbl11);
            il.Emit(OpCodes.Ldc_I4_0);
            il.MarkLabel(lbl12);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Ret);

            // その他
            il.MarkLabel(lbl10);
            il.Emit(OpCodes.Ldstr, "比較演算型エラー");
            il.Emit(OpCodes.Newobj, _application_exception);
            il.Emit(OpCodes.Throw);

            return info;
        }
    }


}