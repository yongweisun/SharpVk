﻿using SharpVk.Generator.Pipeline;
using SharpVk.Generator.Specification;
using System;

namespace SharpVk.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipeline = PipelineBuilder.Create<LoadXmlStage>()
                                            .Extend<SpecParseStage>()
                                            .Build<OutputStub>();

            pipeline.Run();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}