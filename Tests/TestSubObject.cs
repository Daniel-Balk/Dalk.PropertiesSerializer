﻿using System;

namespace Tests
{
    public class TestSubObject
    {
        public TestSubObject()
        {

        }
        public int TestInt { get; set; } = 101;
        public string TestString { get; set; } = "aaa";
        public bool TestBool { get; set; } = true;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}