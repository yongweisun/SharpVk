﻿using System;
using System.Collections.Generic;

namespace SharpVk.Generator.Emit
{
    public class ExpressionBuilder
    {
        private readonly IndentedTextWriter writer;

        public ExpressionBuilder(IndentedTextWriter writer)
        {
            this.writer = writer;
        }

        public void EmitAsIs(string expression)
        {
            this.writer.Write(expression);
        }

        public void EmitLiteral(char prefix, string literal)
        {
            this.writer.Write(prefix);
            this.writer.Write('"');
            this.writer.Write(literal);
            this.writer.Write('"');
        }

        public void EmitLiteral(string literal)
        {
            this.writer.Write('"');
            this.writer.Write(literal);
            this.writer.Write('"');
        }

        public void EmitLiteral(int literal)
        {
            this.writer.Write(literal);
        }

        public void EmitArrayInit(string elementTypeName, params Action<ExpressionBuilder>[] elements)
        {
            this.writer.WriteLine($"new {elementTypeName}[]");
            this.writer.Write("{");
            this.writer.IncreaseIndent();
            bool isFirstElement = true;
            foreach (var element in elements)
            {
                if(!isFirstElement)
                {
                    this.writer.WriteLine(",");
                }
                else
                {
                    isFirstElement = false;
                }

                element(new ExpressionBuilder(this.writer.GetSubWriter()));
            }
            this.writer.DecreaseIndent();
            this.writer.WriteLine();
            this.writer.Write("}");
        }

        public void EmitMemberInit(string name, Action<MemberInitBuilder> members)
        {
            this.writer.WriteLine($"new {name}");
            this.writer.Write("{");
            this.writer.IncreaseIndent();
            members(new MemberInitBuilder(this.writer.GetSubWriter()));
            this.writer.DecreaseIndent();
            this.writer.WriteLine();
            this.writer.Write("}");
        }

        public void EmitNew(string name, params Action<ExpressionBuilder>[] arguments)
        {
            this.writer.Write($"new {name}(");
            this.EmitArguments(arguments);
            this.writer.Write(")");
        }

        public void EmitDefault(string type)
        {
            this.writer.Write($"default({type})");
        }

        public void EmitNull()
        {
            this.writer.Write("null");
        }

        public void EmitThis()
        {
            this.writer.Write("this");
        }

        public void EmitVariable(string name)
        {
            this.writer.Write(name);
        }

        public void EmitCast(string type, Action<ExpressionBuilder> target)
        {
            this.writer.Write($"({type})");
            target(this.GetSubBuilder());
        }

        public void EmitStaticCall(string type, string method, params Action<ExpressionBuilder>[] arguments)
        {
            this.writer.Write($"{type}.{method}(");

            this.EmitArguments(arguments);

            this.writer.Write(")");
        }

        public void EmitDelegateCall(Action<ExpressionBuilder> @delegate, params Action<ExpressionBuilder>[] arguments)
        {
            @delegate(this.GetSubBuilder());

            this.writer.Write("(");

            this.EmitArguments(arguments);

            this.writer.Write(")");
        }

        public void EmitCall(Action<ExpressionBuilder> target, string method, params Action<ExpressionBuilder>[] arguments)
        {
            target(this.GetSubBuilder());

            this.writer.Write($".{method}(");

            this.EmitArguments(arguments);

            this.writer.Write(")");
        }

        public void EmitMember(Action<ExpressionBuilder> target, string member)
        {
            target(this.GetSubBuilder());

            this.writer.Write($".{member}");
        }

        public void EmitLessThan(Action<ExpressionBuilder> left, Action<ExpressionBuilder> right)
        {
            left(this.GetSubBuilder());

            this.writer.Write(" < ");

            right(this.GetSubBuilder());
        }

        public void EmitShiftLeft(Action<ExpressionBuilder> left, Action<ExpressionBuilder> right)
        {
            left(this.GetSubBuilder());

            this.writer.Write(" << ");

            right(this.GetSubBuilder());
        }

        public void EmitShiftRight(Action<ExpressionBuilder> left, Action<ExpressionBuilder> right)
        {
            left(this.GetSubBuilder());

            this.writer.Write(" >> ");

            right(this.GetSubBuilder());
        }

        public void EmitNot(Action<ExpressionBuilder> target)
        {
            this.writer.Write("!");

            target(this.GetSubBuilder());
        }

        public void EmitEnumField(string type, string field)
        {
            this.writer.Write($"{type}.{field}");
        }

        private void EmitArguments(IEnumerable<Action<ExpressionBuilder>> arguments)
        {
            EmitArguments(this.writer, arguments);
        }

        private ExpressionBuilder GetSubBuilder()
        {
            return new ExpressionBuilder(this.writer.GetSubWriter());
        }

        public static Action<ExpressionBuilder> AsIs(string expression)
        {
            return builder => builder.EmitAsIs(expression);
        }

        public static void EmitArguments(IndentedTextWriter writer, IEnumerable<Action<ExpressionBuilder>> arguments)
        {
            bool isFirstArgument = true;

            foreach (var argument in arguments)
            {
                if (isFirstArgument)
                {
                    isFirstArgument = false;
                }
                else
                {
                    writer.Write(", ");
                }

                argument(new ExpressionBuilder(writer.GetSubWriter()));
            }
        }

        public static Action<ExpressionBuilder> Literal(char prefix, string literal)
        {
            return builder => builder.EmitLiteral(prefix, literal);
        }

        public static Action<ExpressionBuilder> Literal(string literal)
        {
            return builder => builder.EmitLiteral(literal);
        }

        public static Action<ExpressionBuilder> Literal(int literal)
        {
            return builder => builder.EmitLiteral(literal);
        }

        public static Action<ExpressionBuilder> ArrayInit(string elementTypeName, params Action<ExpressionBuilder>[] elements)
        {
            return builder => builder.EmitArrayInit(elementTypeName, elements);
        }

        public static Action<ExpressionBuilder> MemberInit(string name, Action<MemberInitBuilder> members)
        {
            return builder => builder.EmitMemberInit(name, members);
        }

        public static Action<ExpressionBuilder> New(string name, params Action<ExpressionBuilder>[] arguments)
        {
            return builder => builder.EmitNew(name, arguments);
        }

        public static Action<ExpressionBuilder> Default(string type)
        {
            return builder => builder.EmitDefault(type);
        }

        public static Action<ExpressionBuilder> Null
        {
            get
            {
                return builder => builder.EmitNull();
            }
        }

        public static Action<ExpressionBuilder> This
        {
            get
            {
                return builder => builder.EmitThis();
            }
        }

        public static Action<ExpressionBuilder> Variable(string name)
        {
            return builder => builder.EmitVariable(name);
        }

        public static Action<ExpressionBuilder> Cast(string type, Action<ExpressionBuilder> target)
        {
            return builder => builder.EmitCast(type, target);
        }

        public static Action<ExpressionBuilder> StaticCall(string type, string method, params Action<ExpressionBuilder>[] arguments)
        {
            return builder => builder.EmitStaticCall(type, method, arguments);
        }

        public static Action<ExpressionBuilder> DelegateCall(Action<ExpressionBuilder> @delegate, params Action<ExpressionBuilder>[] arguments)
        {
            return builder => builder.EmitDelegateCall(@delegate, arguments);
        }

        public static Action<ExpressionBuilder> Call(Action<ExpressionBuilder> target, string method, params Action<ExpressionBuilder>[] arguments)
        {
            return builder => builder.EmitCall(target, method, arguments);
        }

        public static Action<ExpressionBuilder> Member(Action<ExpressionBuilder> target, string member)
        {
            return builder => builder.EmitMember(target, member);
        }

        public static Action<ExpressionBuilder> LessThan(Action<ExpressionBuilder> left, Action<ExpressionBuilder> right)
        {
            return builder => builder.EmitLessThan(left, right);
        }

        public static Action<ExpressionBuilder> ShiftLeft(Action<ExpressionBuilder> left, Action<ExpressionBuilder> right)
        {
            return builder => builder.EmitShiftLeft(left, right);
        }

        public static Action<ExpressionBuilder> ShiftRight(Action<ExpressionBuilder> left, Action<ExpressionBuilder> right)
        {
            return builder => builder.EmitShiftRight(left, right);
        }

        public static Action<ExpressionBuilder> Not(Action<ExpressionBuilder> target)
        {
            return builder => builder.EmitNot(target);
        }

        public static Action<ExpressionBuilder> EnumField(string type, string field)
        {
            return builder => builder.EmitEnumField(type, field);
        }
    }
}
