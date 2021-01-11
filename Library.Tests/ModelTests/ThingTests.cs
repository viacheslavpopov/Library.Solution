using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Template.Models;
using System;

namespace Template.Tests
{
    [TestClass]
    public class ItemTests : IDisposable
    {
        public void Dispose()
        {
        Item.ClearAll();
        }
    }
}