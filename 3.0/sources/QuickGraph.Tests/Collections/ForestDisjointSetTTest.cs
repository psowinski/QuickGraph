// <copyright file="ForestDisjointSetTTest.cs" company="Jonathan de Halleux">Copyright http://www.codeplex.com/quickgraph</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGraph.Collections;

namespace QuickGraph.Collections
{
    /// <summary>This class contains parameterized unit tests for ForestDisjointSet`1</summary>
    [TestClass]
    [PexClass(typeof(ForestDisjointSet<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ForestDisjointSetTTest
    {
        /// <summary>Test stub for AreInSameSet(!0, !0)</summary>
        [PexMethod(MaxConstraintSolverTime = 2, MaxConditions = 1000)]
        [PexGenericArguments(typeof(int))]
        public void AreInSameSet<T>(
            [PexAssumeUnderTest]ForestDisjointSet<T> target,
            T left,
            T right
        )
        {
            PexAssume.IsTrue(target.Contains(left));
            PexAssume.IsTrue(target.Contains(right));

            target.Union(left, right);
            Assert.IsTrue(target.AreInSameSet(left, right));
        }

        /// <summary>Test stub for Contains(!0)</summary>
        [PexMethod]
        [PexGenericArguments(typeof(int))]
        public void Contains<T>(T value)
        {
            var target = new ForestDisjointSet<T>();
            target.MakeSet(value);
            Assert.IsTrue(target.Contains(value));
        }
    }
}
